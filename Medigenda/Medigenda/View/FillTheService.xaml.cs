using System;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.DataTransfer;



// Pour plus d'informations sur le modèle d'élément Boîte de dialogue de contenu, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Medigenda
{
    public sealed partial class FillTheService : ContentDialog
    {

        public Button myButton = new Button();
        public FillTheService()
        {
            this.InitializeComponent();
            this.Available = new ObservableCollection<Worker>();
            this.ListOfService = new ObservableCollection<Service>();
            AvailableWorker.ItemsSource = this.Available;
            Service.ItemsSource = this.ListOfService;
            this.myButton = TheButton;
            
        }


       

        public ObservableCollection<Service> ListOfService { get; set;}
        public ObservableCollection<Worker> Available {get; set;}

        

        private void ListPerson_DragItemsStarting(object sender, Windows.UI.Xaml.Controls.DragItemsStartingEventArgs e)
        {
            var items = new StringBuilder();
            foreach (Worker item in e.Items)
            {
                if (items.Length > 0) items.AppendLine();
                //Get Name as ID to identify Person
                items.Append(item.Last_name);
            }
            e.Data.SetText(items.ToString());
            //Icon When Drag
            e.Data.RequestedOperation = DataPackageOperation.Move;
            //Save Source of the dragAndDrop Action
            e.Data.Properties.Add("SourceList", sender as ListView);
        }

        private void ListPerson_DragOver(object sender, DragEventArgs e)
        {

            e.AcceptedOperation = DataPackageOperation.Move;

        }


        private async void ListPerson_Dropped(object sender, DragEventArgs e)
        {
            object ListViewObject;
            //Get the Source of the dragAndDrop Action
            e.Data.Properties.TryGetValue("SourceList", out ListViewObject);
            var mylistview = ListViewObject as ListView;
            var source = mylistview.ItemsSource as ObservableCollection<Worker>;

            //Get the Target of the dragAndDrop Action
            var destination = sender as ListView;
            var target = destination?.ItemsSource as ObservableCollection<Worker>;

            //Get the Person who is dropped
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                var def = e.GetDeferral();
                var s = await e.DataView.GetTextAsync();
                var ids = s.Split('\n');
                Worker persontomove = null;
                if (ids.Length > 0)
                {


                    foreach (string id in ids)
                    {
                        foreach (Worker item in source)
                        {
                            if (item.Last_name == id)
                            {
                                persontomove = item;
                            }
                        }
                    }



                    //Add Person into Target
                    //target.Add(persontomove);
                    //Remove Person from Source
                    source.Remove(persontomove);
                }
                e.AcceptedOperation = DataPackageOperation.Move;
                def.Complete();
            }
        }

        private async void ListPerson_Copy(object sender, DragEventArgs e)
        {
            object ListViewObject;
            //Get the Source of the dragAndDrop Action
            e.Data.Properties.TryGetValue("SourceList", out ListViewObject);
            var mylistview = ListViewObject as ListView;
            var source = mylistview.ItemsSource as ObservableCollection<Worker>;

            //Get the Target of the dragAndDrop Action
            var destination = sender as ListView;
            var target = destination?.ItemsSource as ObservableCollection<Worker>;

            //Get the Person who is dropped
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                var def = e.GetDeferral();
                var s = await e.DataView.GetTextAsync();
                var ids = s.Split('\n');
                Worker persontomove = null;
                if (ids.Length > 0)
                {


                    foreach (string id in ids)
                    {
                        foreach (Worker item in source)
                        {
                            if (item.Last_name == id)
                            {
                                persontomove = item;
                            }
                        }
                    }



                    //Add Person into Target
                    target.Add(persontomove);
                    //Remove Person from Source
                    source.Remove(persontomove);
                }
                e.AcceptedOperation = DataPackageOperation.Move;
                def.Complete();
            }
        }


    }
}
