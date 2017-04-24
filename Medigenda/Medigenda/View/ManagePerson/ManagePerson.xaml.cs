using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;
using Windows.ApplicationModel.DataTransfer;
using AutoGenerateForm.Uwp;
using AutoGenerateForm.Attributes;
using Medigenda;
using Windows.UI.Popups;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

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
