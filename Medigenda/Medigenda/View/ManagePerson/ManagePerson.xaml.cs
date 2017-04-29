using Windows.UI.Xaml.Controls;

namespace Medigenda
{
    public sealed partial class ManagePerson : Page
    {
        public ManagePerson()
        {
            this.InitializeComponent();
            this.DataContext = new ManagePersonViewModel();
        }
    }
}
