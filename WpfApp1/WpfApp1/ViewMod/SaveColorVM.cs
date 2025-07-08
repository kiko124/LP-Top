using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp1.ViewMod
{
    internal class SaveColorVM
    {
        public string Hex { get; }

        public Color Color { get; }
        public RelayCommand DeleteCommand {  get; }

        public SaveColorVM(string hex, Color color, RelayCommand deleteCommand)
        {
            Hex = hex;
            Color = color;
            DeleteCommand = deleteCommand;
        }
    }
}
