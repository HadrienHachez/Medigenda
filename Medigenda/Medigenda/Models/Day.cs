using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Popups;
using System.IO;
namespace Medigenda
{
    public class Day : PropertyChangeBase
    {
        private DateTime date_time;
        private ObservableCollection<WorkerInfoByDay> infobyday;
        private ObservableCollection<Service> listofavailableservices = new ObservableCollection<Service>();
        private ObservableCollection<WorkerSchedule> listofavailableschedule = new ObservableCollection<WorkerSchedule>();
        public SQLite.Net.SQLiteConnection Database;
        public string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "medigendaLocalDB.sqlite");

        public Day(DateTime date)
        {
            Database = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            this.date_time = date;
            this.InfoByDay = GetWorkerListing();
            this.ListOfAvailableService = GetServiceListing();
            this.ListOfAvailableSchedule = GetScheduleListing();
            OpenContentDialogBox = new RelayCommand(OpenContentDialogBoxExecute);
           
        }


        #region Methods
        public void GotToWork(Worker worker, WorkerSchedule schedule)
        {
            foreach (WorkerInfoByDay wo in this.InfoByDay)
            {
                if ((wo.Worker == worker) && (wo.CurrentDate == this.Date_time))
                {
                    wo.WorkedToday = schedule;

                    //updateColor
                    wo.BackgroundButtonColor = wo.GetColor;
                }
            }
        }

        public void AddWork(object sender,RoutedEventArgs e)
        {
           
           foreach(WorkerInfoByDay woex in InfoByDay)
            {
            TimeSpan first = new TimeSpan (23,59,0);
            TimeSpan end = new TimeSpan(0,0,0);
            foreach (Service service in ContentDialogBox.ListOfService)
            {
                foreach (Shift shift in service.ShiftListing)
                {
                    foreach(Worker wo in shift.Workers)
                    {
                    
                            if (wo == woex.Worker)
                            {
                                if (shift.Start_hour < first)
                                {
                                    first = shift.Start_hour;
                                }
                                if (shift.End_hour > end)
                                {
                                   end = shift.End_hour;
                                }
                            }
                    }
                }
                   
                }
            foreach (WorkerSchedule workschedule in ListOfAvailableSchedule)
                {
                    if ((first == workschedule.Start_hour) && (end == workschedule.End_hour))

                    {
                        
                        GotToWork(woex.Worker, workschedule);
                    }
                    
                }


            }
            
            ContentDialogBox.Hide();
        }

        #endregion

        #region GetDataMethod
        public ObservableCollection<Service> GetServiceListing()
        {
            //Remove and Update when DB is available
            Shift MT1 = new Shift(new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), 2, 3);
            Shift SA1 = new Shift(new TimeSpan(13, 0, 0), new TimeSpan(17, 0, 0), 2, 3);
            Shift TT = new Shift(new TimeSpan(7, 30, 0), new TimeSpan(12, 0, 0), 1, 1);
            Shift MT2 = new Shift(new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), 3, 4);
            Shift SA2 = new Shift(new TimeSpan(13, 0, 0), new TimeSpan(17, 0, 0), 3, 4);
            Shift MT3 = new Shift(new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), 2, 2);
            Shift SA3 = new Shift(new TimeSpan(13, 0, 0), new TimeSpan(17, 0, 0), 2, 2);
            Shift SS = new Shift(new TimeSpan(17, 0, 0), new TimeSpan(20, 0, 0), 2, 2);
            Shift MTW = new Shift(new TimeSpan(7, 30, 0), new TimeSpan(19, 0, 0), 1, 1);
            Shift SAW = new Shift(new TimeSpan(9, 0, 0), new TimeSpan(20, 30, 0), 1, 1);
            foreach (OpenWeekDay openday in MTW.Opening_Day)
            {
                openday.IsOpen = false;
                if((openday.Day == DayOfWeek.Saturday ) || (openday.Day == DayOfWeek.Sunday))
                        {
                    openday.IsOpen = true;
                        }
            }
            foreach (OpenWeekDay openday in SAW.Opening_Day)
            {
                openday.IsOpen = false;
                if ((openday.Day == DayOfWeek.Saturday) || (openday.Day == DayOfWeek.Sunday))
                {
                    openday.IsOpen = true;
                }
            }

            Service CT = new Service("Scanner");
            Service Radio = new Service("Radio");
            Service URG = new Service("Urgence");
            Radio.ShiftListing.Add(TT);
            Radio.ShiftListing.Add(MT1);
            Radio.ShiftListing.Add(SA1);  
            CT.ShiftListing.Add(MT2);
            CT.ShiftListing.Add(SA2);
            URG.ShiftListing.Add(MT3);
            URG.ShiftListing.Add(SA3);
            URG.ShiftListing.Add(SS);
            URG.ShiftListing.Add(MTW);
            URG.ShiftListing.Add(SAW);

            ObservableCollection<Service> List = new ObservableCollection<Service>{CT,URG,Radio};



            //Check if shift isOpen
            ObservableCollection<Service> MyList = new ObservableCollection<Service> ();
            foreach (Service service in List)
            {
                Service servicetoadd = new Service(service.Service_name);
                MyList.Add(servicetoadd);
                foreach (Shift shift in service.ShiftListing)
                {
                    foreach(OpenWeekDay open in shift.Opening_Day)
                    {
                        if((open.IsOpen == true) && (open.Day == this.Date_time.DayOfWeek)) 
                        {
                            MyList[MyList.IndexOf(servicetoadd)].ShiftListing.Add(shift);
                        }
                    }
                }
                if (servicetoadd.ShiftListing.Count == 0)
                {
                    MyList.Remove(servicetoadd);
                }
            }
            return MyList;
        }


        public ObservableCollection<WorkerInfoByDay> GetWorkerListing()
        {

            ObservableCollection<WorkerInfoByDay> FromDB = new ObservableCollection<WorkerInfoByDay>();
            var WorkerDB = Database.Table<WorkerTable>();
            foreach (WorkerTable WorkerFromDB in WorkerDB)
            {
                Worker currentworker = new Worker(WorkerFromDB.Firstname, WorkerFromDB.Lastname);
                //currentworker.AddTima(WorkerFromDB.Tima);
                //currentworker.AddSkills(WorkerFromDB.Skills);
                currentworker.Id = WorkerFromDB.Id;
                FromDB.Add(new WorkerInfoByDay(currentworker,this.Date_time));
            }
            return FromDB;
            

        }


        public ObservableCollection<WorkerSchedule> GetScheduleListing()
        {
            //Remove and Update when DB is available
            return new ObservableCollection<WorkerSchedule>
        {
            new WorkerSchedule(new TimeSpan(8,0,0),new TimeSpan(17,0,0),"M","#99ff99"),
            new WorkerSchedule(new TimeSpan(13,0,0),new TimeSpan(20,0,0),"Sa","#ffff99"),
            new WorkerSchedule(new TimeSpan(7,30,0),new TimeSpan(19,0,0),"SaW","#ff9999"),
            new WorkerSchedule(new TimeSpan(9,0,0),new TimeSpan(20,30,0),"Sa","#ff7777"),
            new WorkerSchedule(new TimeSpan(7,30,0),new TimeSpan(17,0,0),"Sa","#77ff77")
        };

        }
        #endregion

        #region Property
        public ObservableCollection<WorkerSchedule> ListOfAvailableSchedule
        {
            get
            {
                return this.listofavailableschedule;
            }
            set
            {
                this.listofavailableschedule = value;
            }
        }



        public ObservableCollection<Service> ListOfAvailableService
        {
            get
            {
                return this.listofavailableservices;
            }
            set
            {
                this.listofavailableservices = value;
            }
        }

        public ObservableCollection<WorkerInfoByDay> InfoByDay
        {
            get
            {
                return this.infobyday;
            }
            set
            {
                this.infobyday = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime Date_time
        {
            get { return this.date_time; }
        }

        #endregion

        #region GuiProperty
        private FillTheService contentdialogbox = new FillTheService();

        public FillTheService ContentDialogBox
        {
            get { return contentdialogbox; }
            set { this.contentdialogbox = value; }
        }

        public RelayCommand OpenContentDialogBox { get; set; }
        private async void OpenContentDialogBoxExecute()
        {
            ContentDialogBox = new FillTheService();
            foreach (WorkerInfoByDay Info in InfoByDay)
            {
                if ((Info.IsPresent) && (Info.WorkedToday == null))
                {
                    ContentDialogBox.Available.Add(Info.Worker);
                }
            }
            foreach (Service Serv in ListOfAvailableService)
                {
                ContentDialogBox.ListOfService.Add(Serv);
                }
            ContentDialogBox.ListOfService = ListOfAvailableService;
            ContentDialogBox.myButton.Click += AddWork;
            await ContentDialogBox.ShowAsync();
        }

        #endregion

    }
}
