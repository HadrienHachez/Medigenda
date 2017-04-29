namespace Medigenda
{
    public class Tima
    {
        private string name;
        private float factor;


        public Tima(string name, float factor)
        {
            this.Name = name;
            this.Factor = factor;
        }

        public string Name
        {
            get { return this.name;}
            set { this.name = value; }
        }

        public float Factor
        {
            get { return this.factor; }
            set { this.factor = value; }
        }
    }
}
