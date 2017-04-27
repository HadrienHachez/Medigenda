using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

// Pour plus d'informations sur le modèle d'élément Boîte de dialogue de contenu, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Medigenda
{
    public sealed partial class FillTheService : ContentDialog
    {
        public FillTheService()
        {
            this.InitializeComponent();
            this.Available = new ObservableCollection<Worker>();
            this.ListOfService = new ObservableCollection<Service>();
            AvailableWorker.ItemsSource = this.Available;
            Service.ItemsSource = this.ListOfService;
        }

       

        public ObservableCollection<Service> ListOfService { get; set;}
        public ObservableCollection<Worker> Available {get; set;}
        

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
