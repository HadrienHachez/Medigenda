using System.Collections.ObjectModel;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using Windows.UI.Popups;

namespace Medigenda
{
    public class ManagePersonViewModel : PropertyChangeBase
    {
        private ObservableCollection<Worker> workerlisting;
        public SQLite.Net.SQLiteConnection Database;
        public string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "medigendaLocalDB.sqlite");
        public RelayCommand AddButton { get; set; }
        public RelayCommand DeleteButton { get; set; }
        public RelayCommand SaveButton { get; set; }
        private Worker selectedWorker;
        
        

        public ManagePersonViewModel()
        { 
            Database = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            Debug.WriteLine(path);
            Database.CreateTable<WorkerTable>();
            AddButton = new RelayCommand(AddButtonExecute);
            DeleteButton = new RelayCommand(DeleteButtonExecute);
            SaveButton = new RelayCommand(SaveButtonExecute);
            this.WorkerListing = GetWorkerListing();
            SelectedWorker = WorkerListing[0];

        }

        #region Methods
        public ObservableCollection<Worker> GetWorkerListing()
        {

            ObservableCollection<Worker> FromDB = new ObservableCollection<Worker>();
            var WorkerDB = Database.Table<WorkerTable>();
            foreach (WorkerTable WorkerFromDB in WorkerDB)
            {
                Worker currentworker = new Worker(WorkerFromDB.Firstname, WorkerFromDB.Lastname,WorkerFromDB.Id);
                //currentworker.AddTima(WorkerFromDB.Tima);
                //currentworker.AddSkills(WorkerFromDB.Skills);
                FromDB.Add(currentworker);
            }
            return FromDB; 
        }

        public void AddButtonExecute()
        {
            WorkerTable currentWorker = new WorkerTable();
            currentWorker.Lastname = "Worker";
            currentWorker.Firstname = "New";
            Database.Insert(currentWorker);
            
            var current = Database.Query<WorkerTable>("SELECT * FROM WorkerTable Where id = (SELECT MAX(Id) FROM WorkerTable);");
                
               
           
               
            WorkerListing.Add(new Worker(currentWorker.Firstname,currentWorker.Lastname,current[0].Id));
        }

        private void SaveButtonExecute()
        {
            update();
            Database.Execute(string.Format("UPDATE WorkerTable SET Firstname='{0}' WHERE ID = {1};", SelectedWorker.First_name, SelectedWorker.Id));
            Database.Execute(string.Format("UPDATE WorkerTable SET Lastname='{0}' WHERE ID = {1};", SelectedWorker.Last_name, SelectedWorker.Id));

        }

        public void DeleteButtonExecute()
        {
            Database.Execute(string.Format("DELETE FROM WorkerTable Where Id = {0}", SelectedWorker.Id));
            this.WorkerListing.Remove(SelectedWorker);
        }


        private void update()
        {
            MessageDialog Ok = new MessageDialog("DB mise à jour");
            Ok.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
            Ok.ShowAsync();
        }
        #endregion

        #region Property
        public Worker SelectedWorker
        {
            get {   return selectedWorker;}
            set {
                selectedWorker = value;
                //Database.Execute(string.Format("UPDATE WorkerTable SET Firstname='{0}' WHERE ID = {1};", SelectedWorker.First_name, SelectedWorker.Id));
                //Database.Execute(string.Format("UPDATE WorkerTable SET Lastname='{0}' WHERE ID = {1};", SelectedWorker.Last_name, SelectedWorker.Id));
                NotifyPropertyChanged();}
        }

        public ObservableCollection<Worker> WorkerListing
        {
            get
            {
                return this.workerlisting;
            }
            set
            {
                this.workerlisting = value;
                NotifyPropertyChanged();
            }
        }
        #endregion
    }
}
