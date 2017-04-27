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

namespace Medigenda
{
    public class Day : PropertyChangeBase
    {
        private DateTime date_time;
        private ObservableCollection<WorkerInfoByDay> infobyday;
        private ObservableCollection<Service> listofavailableservices = new ObservableCollection<Service>();
      

        public Day(DateTime date)
        {
            this.date_time = date;
            this.InfoByDay = GetWorkerListing();
            this.ListOfAvailableService = GetServiceListing();
            OpenContentDialogBox = new RelayCommand(OpenContentDialogBoxExecute);
        }


        public WorkingDay getWorkingDay(Worker work)
        {
            return null;
        }




        #region GetDataMethod
        public ObservableCollection<Service> GetServiceListing()
        {
            //Remove and Update when DB is available
            Service CT = new Service(new ServiceName("CT"));
            CT.createShift("8:15", "23:59", 2, 3,CT.Service_name);
            CT.createShift("13:00", "20:00", 2, 3, CT.Service_name);
            CT.ShiftListing[0].addWorker(new Worker("Tom", "Tom", 44));
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
                 new WorkerInfoByDay(new Worker("Tom", "Sellelsagh", 14161),this.Date_time),
                 new WorkerInfoByDay(new Worker("Marcin", "Krasowsky", 42),this.Date_time),
                 new WorkerInfoByDay(new Worker("Hadrien", "Hachez", 44),this.Date_time)

            };

        }

        #endregion



        #region Property

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
            await ContentDialogBox.ShowAsync();
        }

        #endregion

    }
}
