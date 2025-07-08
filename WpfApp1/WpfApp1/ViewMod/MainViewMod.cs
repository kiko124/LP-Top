
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;

using WpfApp1.Models;

namespace WpfApp1.ViewMod
{
    internal class MainViewMod : INotifyPropertyChanged
    {
        private readonly ColorMod _currentColor = new ColorMod();
        private Color _displayColor;
        private string _hexCode = "#000000";
        public byte Alpha
        {
            get => _currentColor.Alpfa;
            set
            {
                if (_currentColor.Alpfa != value)
                {
                    _currentColor.Alpfa = value;
                    OnPropertyChanged(nameof(Alpha));
                    UpdateColor();
                }
            }
        }

        public byte Red
        {
            get => _currentColor.Red;
            set
            {
                if (_currentColor.Red != value)
                {
                    _currentColor.Red = value;
                    OnPropertyChanged(nameof(Red));
                    UpdateColor();
                }
            }
        }

        public byte Green
        {
            get => _currentColor.Green;
            set
            {
                if (_currentColor.Green != value)
                {
                    _currentColor.Green = value;
                    OnPropertyChanged(nameof(Green));
                    UpdateColor();
                }
            }
        }

        public byte Blue
        {
            get => _currentColor.Blue;
            set
            {
                if (_currentColor.Blue != value)
                {
                    _currentColor.Blue = value;
                    OnPropertyChanged(nameof(Blue));
                    UpdateColor();
                }
            }
        }

        public Color DisplayColor
        {
            get => _displayColor;
            private set
            {
                if (_displayColor != value)
                {
                    _displayColor = value;
                    OnPropertyChanged();
                }
            }
        }

        public string HexCode
        {
            get => _hexCode;
            private set
            {
                if (_hexCode != value)
                {
                    _hexCode = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<SaveColorVM> SavedColors { get; }
            = new ObservableCollection<SaveColorVM>();

        public ICommand AddColorCommand { get; }
        public ICommand DeleteColorCommand { get; }

        public MainViewMod()
        {
            AddColorCommand = new RelayCommand( _ => AddColor());
            DeleteColorCommand = new RelayCommand(DeleteColor);
            UpdateColor();
        }

        private void UpdateColor()
        {
            DisplayColor = _currentColor.ToColor();
            HexCode = _currentColor.ToHex();
        }

        private void AddColor()
        {
            SavedColors.Add(new SaveColorVM(
                hex: HexCode,
                color: DisplayColor,
                deleteCommand: new RelayCommand(DeleteColor)
            ));
        }

        private void DeleteColor(object parameter)
        {
            if (parameter is SaveColorVM color)
                SavedColors.Remove(color);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
    

