using AutoGenerateForm.Attributes;


namespace Medigenda

{
    public class Person : PropertyChangeBase
    {
        private string first_name, last_name;
        private int id;


        public Person(string first, string last, int id)
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
            get { return this.first_name; }
            set { this.first_name = value;
                   NotifyPropertyChanged(); }
        }

        [AutoGenerateProperty]
        [Display("Lastname")]
        [PropertyOrder(2)]
        public string Last_name
        {
            get { return this.last_name; }
            set { this.last_name = value;
                NotifyPropertyChanged();
            }
        }

        [AutoGenerateProperty]
        [Display("ID")]
        [PropertyOrder(1)]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        #endregion
    }
}
