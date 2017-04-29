using Windows.UI.Xaml.Controls;


namespace Medigenda
{

    public sealed partial class ManageActivities : Page
    {
        public ManageActivities()
        {
            this.InitializeComponent();
            this.DataContext = new ManageActivitiesViewModel();
        }
    }
}
