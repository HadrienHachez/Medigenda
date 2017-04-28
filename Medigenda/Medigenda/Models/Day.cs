using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;

namespace Medigenda
{
    public class Day : PropertyChangeBase
    {
        private DateTime date_time;
        private ObservableCollection<WorkerInfoByDay> infobyday;
        private ObservableCollection<Service> listofavailableservices = new ObservableCollection<Service>();
        private ObservableCollection<WorkerSchedule> listofavailableschedule = new ObservableCollection<WorkerSchedule>();
       

        public Day(DateTime date)
        {
            this.date_time = date;
            this.InfoByDay = GetWorkerListing();
            this.ListOfAvailableService = GetServiceListing();
            this.ListOfAvailableSchedule = GetScheduleListing();
            OpenContentDialogBox = new RelayCommand(OpenContentDialogBoxExecute);
        }


        public WorkingDay getWorkingDay(Worker work)
        {
            return null;
        }


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
            TimeSpan first = new TimeSpan (0,0,0);
            TimeSpan end = new TimeSpan(23,59,00);
            foreach (Service service in ContentDialogBox.ListOfService)
            {
                foreach (Shift shift in service.ShiftListing)
                {
                    foreach(Worker wo in shift.Workers)
                    {
                    
                            if (wo == woex.Worker)
                            {
                                if (shift.Start_hour > first)
                                {
                                    first = shift.Start_hour;
                                }
                                if (shift.End_hour < end)
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

        #region GetDataMethod
        public ObservableCollection<Service> GetServiceListing()
        {
            //Remove and Update when DB is available
            Service CT = new Service(new ServiceName("CT"));
            CT.ShiftListing.Add(new Shift("8:00", "17:00", 2, 3,CT.Service_name));
            CT.ShiftListing.Add(new Shift("16:00", "22:00", 2, 3, CT.Service_name));
            
            ObservableCollection<Service> List = new ObservableCollection<Service>
            {
                 new Service(new ServiceName("Radio")),
                 new Service(new ServiceName("Mammo")),
            };
            List.Add(CT);
            return List;
        }


        public ObservableCollection<WorkerInfoByDay> GetWorkerListing()
        {
            //Remove and Update when DB is available
            return new ObservableCollection<WorkerInfoByDay>
            {
                 new WorkerInfoByDay(new Worker("Benoit", "Wéry", 14256),this.Date_time),
                 new WorkerInfoByDay(new Worker("Tom", "Selleslagh", 14161),this.Date_time),
                 new WorkerInfoByDay(new Worker("Marcin", "Krasowsky", 42),this.Date_time),
                 new WorkerInfoByDay(new Worker("Hadrien", "Hachez", 44),this.Date_time)
            };

        }


        public ObservableCollection<WorkerSchedule> GetScheduleListing()
        {
            //Remove and Update when DB is available
            return new ObservableCollection<WorkerSchedule>
        {
            new WorkerSchedule(new TimeSpan(8,0,0),new TimeSpan(17,0,0),"M","#99ff99"),
            new WorkerSchedule(new TimeSpan(16,0,0),new TimeSpan(22,0,0),"Sa","#ffff99")
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
                if (Info.IsPresent)
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
