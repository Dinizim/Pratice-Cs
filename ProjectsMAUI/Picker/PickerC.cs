using System;
using System.ComponentModel;
using Microsoft.Maui.Graphics;

namespace Picker
{
    public partial class Picker : INotifyPropertyChanged
    {
        public Picker()
        {
            ColorName = "028";
        }

        private string colorName;

        public string ColorName
        {
            get => colorName;
            set
            {
                colorName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ColorSelected));
                OnPropertyChanged(nameof(ColorName));
                OnPropertyChanged(nameof(BoxColor));
            }
        }

        public Color BoxColor => Color.FromHex(colorName);
        public string ColorSelected => colorName;

        // USA ESSA MERDA PARA FUNCIONAR A INTERFACE
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
