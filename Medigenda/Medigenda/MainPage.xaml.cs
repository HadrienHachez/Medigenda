using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Core;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel;
using AutoGenerateForm.Uwp;
using AutoGenerateForm.Attributes;




// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Medigenda
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {

            this.DataContext = this;
            this.InitializeComponent();
            for (int i = 0; i < 20; i++)
            {
                comments_tags.Add("Tag no: " + i);
            }

            for (int i = 1; i < DateTime.DaysInMonth(2017, 5); i++)
            {
                May.Add(new DateTime(2017, 5, i));
            }

            //Needed To Bind some Data throught Xaml.cs and Xaml files
            this.DataContext = this;
            //Person BW = new Person("Wéry", "Benoit");
            //Person TS = new Person("Selleslagh", "Tom");
            //Person AH = new Person("Heinen", "Anélie");
            //this.SomePerson.Add(BW);
            //this.SomePerson.Add(TS);
            //this.SomePerson.Add(AH);
            //LikesListView3.ItemsSource = Scan;
        }

        public List<string> comments_tags = new List<string>();
        public List<DateTime> May = new List<DateTime>();
        ObservableCollection<int> Test { get; set; } = new ObservableCollection<int>();
        //ObservableCollection<Person> SomePerson { get; set; } = new ObservableCollection<Person>();
        //ObservableCollection<Person> Radio { get; set; } = new ObservableCollection<Person>();
        //ObservableCollection<Person> Scan { get; set; } = new ObservableCollection<Person>();

        #region Property

        #endregion

        //Methods

        //Menu
        private void GotoManagePerson(object sender, RoutedEventArgs e) { this.Frame.Navigate(typeof(ManagePerson), e); }
        private void GotoManageActivities(object sender, RoutedEventArgs e) { this.Frame.Navigate(typeof(ManageActivities), e); }
        private void GotoManageTimeSlots(object sender, RoutedEventArgs e) { this.Frame.Navigate(typeof(ManageTimeSlots), e); }



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

    }
}
