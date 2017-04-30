using AutoGenerateForm.Attributes;
using System.IO;

namespace Medigenda

{
    public class Person : PropertyChangeBase
    {
        private string first_name, last_name;
        private int id;
        private SQLite.Net.SQLiteConnection Database = 
            new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), 
                Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Medigenda.sqlite"));

        public Person(string first, string last)
        {
            this.First_name = first;
            this.Last_name = last;
            this.Id = id;
        }



      
        #region Property
        [AutoGenerateProperty]
        [Display("Firstname")]
        [PropertyOrder(3)]
        public string First_name
        {
            get { return this.first_name;}
            set { this.first_name = value;
                Database.Execute(string.Format("UPDATE WorkerTable SET Firstname='{0}' WHERE ID = {1};", value, this.Id));
                NotifyPropertyChanged(); }
        }

        [AutoGenerateProperty]
        [Display("Lastname")]
        [PropertyOrder(2)]
        public string Last_name
        {
            get { return this.last_name; }
            set { this.last_name = value;
                Database.Execute(string.Format("UPDATE WorkerTable SET Lastname='{0}' WHERE ID = {1};", value, this.Id));
                NotifyPropertyChanged();
            }
        }

        [AutoGenerateProperty]
        [Display("ID")]
        [PropertyOrder(1)]
        [IsEnabledProperty(false)]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        #endregion
    }
}
