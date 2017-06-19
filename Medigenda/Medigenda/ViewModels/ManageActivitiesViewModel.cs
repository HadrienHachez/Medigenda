using System;
using System.Collections.ObjectModel;
using System.IO;
using Windows.UI.Popups;

namespace Medigenda
{
    class ManageActivitiesViewModel : PropertyChangeBase
    {
       
        private ObservableCollection<Service> activitieslisting;
        public SQLite.Net.SQLiteConnection Database;
        public string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "medigendaLocalDB.sqlite");
        public RelayCommand AddButton { get; set; }
        public RelayCommand SaveButton { get; set; }
        public RelayCommand DeleteButton { get; set; }
        private Service selectedactivity;
        private Shift selectedshift;
        

        public ManageActivitiesViewModel()
        {
            AddButton = new RelayCommand(AddButtonExecute);
            DeleteButton = new RelayCommand(DeleteButtonExecute);
            SaveButton = new RelayCommand(SaveButtonExecute);
            Database = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            Database.CreateTable<ServiceTable>();
            Database.CreateTable<ShiftTable>();
            this.ActivitiesListing = GetActivitiesListing();
            SelectedActivity = ActivitiesListing[0];
        }


        #region Methods
        public ObservableCollection<Service> GetActivitiesListing()
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
                        if (ShiftFromDB.mon == 1) { currentshift.Opening_Day[0].IsOpen = true; } else { currentshift.Opening_Day[0].IsOpen = false; }
                        if (ShiftFromDB.tue == 1) { currentshift.Opening_Day[1].IsOpen = true; } else { currentshift.Opening_Day[1].IsOpen = false; }
                        if (ShiftFromDB.wed == 1) { currentshift.Opening_Day[2].IsOpen = true; } else { currentshift.Opening_Day[2].IsOpen = false; }
                        if (ShiftFromDB.thu == 1) { currentshift.Opening_Day[3].IsOpen = true; } else { currentshift.Opening_Day[3].IsOpen = false; }
                        if (ShiftFromDB.fri == 1) { currentshift.Opening_Day[4].IsOpen = true; } else { currentshift.Opening_Day[4].IsOpen = false; }
                        if (ShiftFromDB.sat == 1) { currentshift.Opening_Day[5].IsOpen = true; } else { currentshift.Opening_Day[5].IsOpen = false; }
                        if (ShiftFromDB.sun == 1) { currentshift.Opening_Day[6].IsOpen = true; } else { currentshift.Opening_Day[6].IsOpen = false; }
                        currentshift.Id = ShiftFromDB.Id;
                        currentservice.ShiftListing.Add(currentshift);
                    }
                    
                }
                FromDBService.Add(currentservice);
            }
            return FromDBService;

        }

        private void SaveButtonExecute()
        {
            update();
            Database.Execute(string.Format("UPDATE ShiftTable SET Start_hour='{0}' WHERE ID = {1};", SelectedShift.Start_hour.ToString("c"), SelectedShift.Id));
            Database.Execute(string.Format("UPDATE ShiftTable SET End_hour='{0}' WHERE ID = {1};", SelectedShift.End_hour.ToString("c"), SelectedShift.Id));
            Database.Execute(string.Format("UPDATE ShiftTable SET Minwo='{0}' WHERE ID = {1};", SelectedShift.Min_workers, SelectedShift.Id));
            Database.Execute(string.Format("UPDATE ShiftTable SET Optwo='{0}' WHERE ID = {1};", SelectedShift.Opt_workers, SelectedShift.Id));
            if (SelectedShift.Opening_Day[0].IsOpen == true)
            {
                Database.Execute(string.Format("UPDATE ShiftTable SET mon = 1 WHERE ID = {0};", SelectedShift.Id));
            }
            else
            {
                Database.Execute(string.Format("UPDATE ShiftTable SET mon = 0 WHERE ID = {0};", SelectedShift.Id));
            }
            
            if (SelectedShift.Opening_Day[1].IsOpen == true)
            {
                Database.Execute(string.Format("UPDATE ShiftTable SET tue = 1 WHERE ID = {0};", SelectedShift.Id));
            }
            else
            {
                Database.Execute(string.Format("UPDATE ShiftTable SET tue = 0 WHERE ID = {0};", SelectedShift.Id));
            }
            if (SelectedShift.Opening_Day[2].IsOpen == true)
            {
                Database.Execute(string.Format("UPDATE ShiftTable SET wed = 1 WHERE ID = {0};", SelectedShift.Id));
            }
            else
            {
                Database.Execute(string.Format("UPDATE ShiftTable SET wed = 0 WHERE ID = {0};", SelectedShift.Id));
            }
            if (SelectedShift.Opening_Day[3].IsOpen == true)
            {
                Database.Execute(string.Format("UPDATE ShiftTable SET thu = 1 WHERE ID = {0};", SelectedShift.Id));
            }
            else
            {
                Database.Execute(string.Format("UPDATE ShiftTable SET thu = 0 WHERE ID = {0};", SelectedShift.Id));
            }
            if (SelectedShift.Opening_Day[4].IsOpen == true)
            {
                Database.Execute(string.Format("UPDATE ShiftTable SET fri = 1 WHERE ID = {0};", SelectedShift.Id));
            }
            else
            {
                Database.Execute(string.Format("UPDATE ShiftTable SET fri = 0 WHERE ID = {0};", SelectedShift.Id));
            }
            if (SelectedShift.Opening_Day[5].IsOpen == true)
            {
                Database.Execute(string.Format("UPDATE ShiftTable SET sat = 1 WHERE ID = {0};", SelectedShift.Id));
            }
            else
            {
                Database.Execute(string.Format("UPDATE ShiftTable SET sat = 0 WHERE ID = {0};", SelectedShift.Id));
            }
            if (SelectedShift.Opening_Day[6].IsOpen == true)
            {
                Database.Execute(string.Format("UPDATE ShiftTable SET sun = 1 WHERE ID = {0};", SelectedShift.Id));
            }
            else
            {
                Database.Execute(string.Format("UPDATE ShiftTable SET sun = 0 WHERE ID = {0};", SelectedShift.Id));
            }
        }

        private void update()
        {
            MessageDialog Ok = new MessageDialog("DB mise à jour");
            Ok.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
            Ok.ShowAsync();
        }

        public void AddButtonExecute()
        {
            ShiftTable currentShift= new ShiftTable();
            currentShift.Start_hour = (new TimeSpan(0,0,0)).ToString("c");
            currentShift.End_hour = (new TimeSpan(23, 59, 0)).ToString("c");
            currentShift.Minwo = 0;
            currentShift.Optwo = 0;
            var Service = Database.Query<ServiceTable>("SELECT * FROM ServiceTable WHERE NAME= '" + SelectedActivity.Service_name + "';");
            currentShift.FKService = Service[0].Id;
            Database.Insert(currentShift);
            SelectedActivity.ShiftListing.Add(new Shift(new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 0), 0, 0));
        }

        public void DeleteButtonExecute()
        {
            update();
            Database.Execute(string.Format("DELETE FROM ShiftTable Where Id = {0}", SelectedShift.Id));
            this.SelectedActivity.ShiftListing.Remove(SelectedShift);

        }

        #endregion

        #region Property
        public ObservableCollection<Service> ActivitiesListing
        {
            get {
                return this.activitieslisting; }
            set
            {
                this.activitieslisting = value;
                NotifyPropertyChanged();
            }
        }



        public Service SelectedActivity
        {
            get {
                return selectedactivity;}
            set
            {
                selectedactivity = value;
                NotifyPropertyChanged();
            }
        }


        public Shift SelectedShift
        {
            get { return selectedshift;}
            set
            {
                selectedshift = value;
                NotifyPropertyChanged();
            }
        }
        #endregion


    }
}
