using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp1.Models
{
    internal class ColorMod
    {
        public Byte Alpfa { get; set; } = 255;
        public Byte Red { get; set; }
        public Byte Green { get; set; }
        public Byte Blue { get; set; }

        public Color ToColor() => Color.FromArgb(Alpfa, Red, Blue, Green);
        public string ToHex() => $"#{Alpfa:X2}{Red:X2}{Green:X2}{Blue:X2}";
    }
}
