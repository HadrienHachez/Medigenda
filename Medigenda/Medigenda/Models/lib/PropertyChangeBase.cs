using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


//Source of this class : https://github.com/RikardoPons/UniversalFormsToolkit
namespace Medigenda
{
    public class PropertyChangeBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
