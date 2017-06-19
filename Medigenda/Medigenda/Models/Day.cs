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
            ObservableCollection<Service> FromDBService = new ObservableCollection<Service>();
            var ServiceDB = Database.Table<ServiceTable>();
            var ShiftDB = Database.Table<ShiftTable>();
            foreach (ServiceTable ServiceFromDB in ServiceDB)
            {
                Service currentservice = new Service(ServiceFromDB.Name);
                foreach (ShiftTable ShiftFromDB in ShiftDB)
                {
                    if (ServiceFromDB.Id == ShiftFromDB.FKService)
                    {
                        Shift currentshift = new Shift(TimeSpan.ParseExact(ShiftFromDB.Start_hour, "c", null), TimeSpan.ParseExact(ShiftFromDB.End_hour, "c", null), ShiftFromDB.Minwo, ShiftFromDB.Optwo);
                        if (ShiftFromDB.mon == 1) { currentshift.Opening_Day[0].IsOpen = true; }
                        if (ShiftFromDB.tue == 1) { currentshift.Opening_Day[1].IsOpen = true; }
                        if (ShiftFromDB.wed == 1) { currentshift.Opening_Day[2].IsOpen = true; }
                        if (ShiftFromDB.thu == 1) { currentshift.Opening_Day[3].IsOpen = true; }
                        if (ShiftFromDB.fri == 1) { currentshift.Opening_Day[4].IsOpen = true; }
                        if (ShiftFromDB.sat == 1) { currentshift.Opening_Day[5].IsOpen = true; }
                        if (ShiftFromDB.sun == 1) { currentshift.Opening_Day[6].IsOpen = true; }
                        currentservice.ShiftListing.Add(currentshift);
                    }

                }
                FromDBService.Add(currentservice);
            }



            //Check if shift isOpen
            ObservableCollection<Service> MyList = new ObservableCollection<Service> ();
            foreach (Service service in FromDBService)
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
                Worker currentworker = new Worker(WorkerFromDB.Firstname, WorkerFromDB.Lastname,WorkerFromDB.Id);
                //currentworker.AddTima(WorkerFromDB.Tima);
                //currentworker.AddSkills(WorkerFromDB.Skills);
                FromDB.Add(new WorkerInfoByDay(currentworker,this.Date_time));
            }
            return FromDB;
            

        }


        public ObservableCollection<WorkerSchedule> GetScheduleListing()
        {


            ObservableCollection<WorkerSchedule> FromDB = new ObservableCollection<WorkerSchedule>();
            var WorkerDB = Database.Table<WorkerScheduleTable>();
            foreach (WorkerScheduleTable WorkerFromDB in WorkerDB)
            {

                WorkerSchedule currentworker = new WorkerSchedule(TimeSpan.ParseExact(WorkerFromDB.BeginHour, "c", null), TimeSpan.ParseExact(WorkerFromDB.EndHour, "c", null), WorkerFromDB.Output, WorkerFromDB.Color, WorkerFromDB.Id);
                FromDB.Add(currentworker);
            }
            return FromDB;

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
