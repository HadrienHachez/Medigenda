using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.DataTransfer;
using System.Collections.ObjectModel;
using System.Text;




// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Medigenda
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public ObservableCollection<Worker> WorkerListing { get; set; } = new ObservableCollection<Worker>();
        List<DateTime> May = new List<DateTime>();


        #region Menu
        private void GotoManagePerson(object sender, RoutedEventArgs e) { this.Frame.Navigate(typeof(ManagePerson), e); }
        private void GotoManageActivities(object sender, RoutedEventArgs e) { this.Frame.Navigate(typeof(ManageActivities), e); }
        private void GotoManageTimeSlots(object sender, RoutedEventArgs e) { this.Frame.Navigate(typeof(ManageTimeSlots), e); }
        #endregion

        public MainPage()
        {

            //Needed To Bind some Data throught Xaml.cs and Xaml files
            
            this.InitializeComponent();
            this.DataContext = new MainPageViewModel();

            #region As long as the database is not available

            #endregion
        }

        
        #region DragAndDropProprty
        //DragAndDrop trought two ListViews
        private void ListPerson_DragItemsStarting(object sender, Windows.UI.Xaml.Controls.DragItemsStartingEventArgs e)
        {
            var items = new StringBuilder();
            foreach (Worker item in e.Items)
            {
                if (items.Length > 0) items.AppendLine();
                //Get Name as ID to identify Person
                //items.Append(item.Name);
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
                            /*if (item.Name == id)
                            {
                                persontomove = item;
                            }*/
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
        #endregion
    }
}
