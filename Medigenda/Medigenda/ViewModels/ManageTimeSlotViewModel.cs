using System.Collections.ObjectModel;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using Windows.UI.Popups;
using System;

namespace Medigenda
{ 
    public class ManageTimeSlotViewModel:PropertyChangeBase
    {
    private ObservableCollection<WorkerSchedule> WorkerSchedulelisting;
    public SQLite.Net.SQLiteConnection Database;
    public string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "medigendaLocalDB.sqlite");
    public RelayCommand AddButton { get; set; }
    public RelayCommand DeleteButton { get; set; }
    public RelayCommand SaveButton { get; set; }
    private WorkerSchedule selectedWorkerSchedule;



    public ManageTimeSlotViewModel()
    {
        Database = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        Debug.WriteLine(path);
        Database.CreateTable<WorkerScheduleTable>();
        AddButton = new RelayCommand(AddButtonExecute);
        DeleteButton = new RelayCommand(DeleteButtonExecute);
        SaveButton = new RelayCommand(SaveButtonExecute);
        this.WorkerSchedulelisting = GetWorkerScheduleListing();
            SelectedWorkerSchedule = WorkerScheduleListing[0];

    }

    #region Methods
    public ObservableCollection<WorkerSchedule> GetWorkerScheduleListing()
    {
        
        ObservableCollection<WorkerSchedule> FromDB = new ObservableCollection<WorkerSchedule>();
        var WorkerDB = Database.Table<WorkerScheduleTable>();
        foreach (WorkerScheduleTable WorkerFromDB in WorkerDB)
        {

            WorkerSchedule currentworker = new WorkerSchedule(TimeSpan.ParseExact(WorkerFromDB.BeginHour, "c",null), TimeSpan.ParseExact(WorkerFromDB.EndHour, "c", null), WorkerFromDB.Output,WorkerFromDB.Color,WorkerFromDB.Id);
            FromDB.Add(currentworker);
        }
        return FromDB;
    }

    public void AddButtonExecute()
    {
        TimeSpan begin = new TimeSpan(0, 0, 0);
        TimeSpan end = new TimeSpan(23, 59, 59);
        string output = "N";
        string color = "#000000";  
        WorkerScheduleTable currentWorker = new WorkerScheduleTable();
        currentWorker.BeginHour = begin.ToString("c"); ;
        currentWorker.EndHour = end.ToString("c");
        currentWorker.Output = output;
        currentWorker.Color = color;
        Database.Insert(currentWorker);
        var current = Database.Query<WorkerScheduleTable>("SELECT * FROM WorkerTable Where Id = (SELECT MAX(Id) FROM WorkerTable);");        
        WorkerSchedulelisting.Add(new WorkerSchedule(begin, end, output, color,current[0].Id));
        
    }

    private void SaveButtonExecute()
    {
        update();
            Database.Execute(string.Format("UPDATE WorkerScheduleTable SET BeginHour='{0}' WHERE Id = {1};", SelectedWorkerSchedule.Start_hour, SelectedWorkerSchedule.Id));
            Database.Execute(string.Format("UPDATE WorkerScheduleTable SET EndHour='{0}' WHERE Id = {1};", SelectedWorkerSchedule.End_hour, SelectedWorkerSchedule.Id));
            Database.Execute(string.Format("UPDATE WorkerScheduleTable SET Color='{0}' WHERE Id = {1};", SelectedWorkerSchedule.Color, SelectedWorkerSchedule.Id));
            Database.Execute(string.Format("UPDATE WorkerScheduleTable SET Output='{0}' WHERE Id = {1};", SelectedWorkerSchedule.Output, SelectedWorkerSchedule.Id));
        }

    public void DeleteButtonExecute()
    {
        Database.Execute(string.Format("DELETE FROM WorkerScheduleTable Where Id = {0}", SelectedWorkerSchedule.Id));
        this.WorkerScheduleListing.Remove(SelectedWorkerSchedule);
    }


    private void update()
    {
        MessageDialog Ok = new MessageDialog("DB mise à jour");
        Ok.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
        Ok.ShowAsync();
    }
    #endregion

    #region Property
    public WorkerSchedule SelectedWorkerSchedule
    {
        get { return selectedWorkerSchedule; }
        set
        {
            selectedWorkerSchedule = value;
            //Database.Execute(string.Format("UPDATE WorkerTable SET Firstname='{0}' WHERE ID = {1};", SelectedWorker.First_name, SelectedWorker.Id));
            //Database.Execute(string.Format("UPDATE WorkerTable SET Lastname='{0}' WHERE ID = {1};", SelectedWorker.Last_name, SelectedWorker.Id));
            NotifyPropertyChanged();
        }
    }

    public ObservableCollection<WorkerSchedule> WorkerScheduleListing
        {
        get
        {
            return this.WorkerSchedulelisting;
        }
        set
        {
            this.WorkerSchedulelisting = value;
            NotifyPropertyChanged();
        }
    }
    #endregion


}
}
