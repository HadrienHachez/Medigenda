using AutoGenerateForm.Attributes;
using System.Collections.ObjectModel;

namespace Medigenda
{
    public class Worker : Person
    {
        //Skills of a Worker are saved in a List where the a boolean give if the worker has this skill.
        private ObservableCollection<HaveSkills> skills = new ObservableCollection<HaveSkills>();
        private Tima tima;

        //Available tima for the Worker - It's Legal, not mutabale
        private ObservableCollection<Tima> availableTima = new ObservableCollection<Tima> {
            new Tima("Full-Time", 1),
            new Tima("4/5", 4 / 5),
            new Tima("3/4", 3 / 4),
            new Tima("3/5", 3 / 5),
            new Tima("Half-Time", 1 / 2),
            new Tima("2/5", 2 / 5),
            new Tima("1/5", 1 / 5)
        };


        public Worker(string first, string last,int id) : base(first, last,id)
        {
            this.tima = this.availableTima[0];
            this.skills = GenAvailableSkills();
         }

        #region Methods

        public ObservableCollection<HaveSkills> GenAvailableSkills()
        {

            //Remove and update when DB is Available
            //Needed for test
            return new ObservableCollection<HaveSkills>
            { 
            new HaveSkills(new Service("CT-Scan")),
            new HaveSkills(new Service("Radio")),
            new HaveSkills(new Service("IRM")),
            new HaveSkills(new Service("Mammo")),
            new HaveSkills(new Service("URG"))
            };
        }



        #endregion

        #region Properties
        [AutoGenerateProperty]
        [DisplayMemberPathCollection("Name")]
        [SelectedItemCollection("Tima")]
        [Display("Time Schedule")]
        [PropertyOrder(4)]
        public ObservableCollection<Tima> AvailableTima
        {
            get { return this.availableTima; }
            set { this.availableTima = value;}
        }


        public Tima Tima
        {
            get { return this.tima; }
            set { this.tima = value;}
        }
        

        public ObservableCollection<HaveSkills> Skills
        {
            get { return this.skills;}
            set { this.skills = value; }
        }

        #endregion

    }

}
