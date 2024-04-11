using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace SystemZarządzaniaKolekcjonerstwem.Models
{
	public class UserCollection : INotifyPropertyChanged
    {
		public string Kind { get; set; }
        private string title;
        private string status;
        private string additionalName { get; set; }
        private string additionalValue { get; set; }
        private int rate;
        private int price;

        public string AdditionalName
        {
            get { return additionalName; }
            set
            {
                if (additionalName != value)
                {
                    additionalName = value;
                    NotifyPropertyChanged(nameof(AdditionalName));
                }
            }
        }

        public string AdditionalValue
        {
            get { return additionalValue; }
            set
            {
                if(additionalValue != value)
                {
                    additionalValue = value;
                    NotifyPropertyChanged(nameof(AdditionalValue));
                }
            }
        }

        public int Price
        {
            get { return price; }

            set
            {
                if (price != value)
                {
                    price = value;
                    NotifyPropertyChanged(nameof(Price));
                }
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    NotifyPropertyChanged(nameof(Title));
                }
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    NotifyPropertyChanged(nameof(Status));
                }
            }
        }

        public int Rate
        {
            get { return rate; }
            set
            {
                if(rate != null)
                {
                    rate = value;
                    NotifyPropertyChanged(nameof(Rate));
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

