using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SystemZarządzaniaKolekcjonerstwem.Models
{
    public class CollectionKinds : INotifyPropertyChanged
    {
        private int appears;

        public string Kind { get; set; }

        public int Appears
        {
            get { return appears; }
            set
            {
                if (appears != value)
                {
                    appears = value;
                    NotifyPropertyChanged(nameof(Appears));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

