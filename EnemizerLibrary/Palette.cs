using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace EnemizerLibrary
{
    public class Palette : INotifyPropertyChanged
    {
        public static readonly string[] PaletteColorNames =
        {
            "Transparent",
            "White",
            "Belt / Yellow",
            "Skin Shade",
            "Skin",
            "Outline",
            "Hat Trim / Orange",
            "Mouth / Red",
            "Hair",
            "Tunic Shade",
            "Tunic",
            "Hat Shade",
            "Hat",
            "Hands",
            "Sleeves",
            "Water"
        };

        public Palette(int size = 16)
        {
            this.PaletteColor = new Color[size];

            for (var i = 0; i < this.PaletteColor.Length; i++)
            {
                this.PaletteColor[i] = Color.FromArgb(i * 15, i * 15, i * 15);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        Color[] PaletteColor { get; set; }
        byte[] RawPalette { get; set; }

        public Color[] PaletteColors { get => PaletteColor; }

        public Color this[int i]
        {
            get
            {
                if (this.PaletteColor.Length < i)
                {
                    throw new IndexOutOfRangeException("Invalid palette index");
                }

                return this.PaletteColor[i];
            }
            set
            {
                if (this.PaletteColor.Length < i)
                {
                    throw new IndexOutOfRangeException("Invalid palette index");
                }

                if (value != this.PaletteColor[i])
                {
                    this.PaletteColor[i] = value;

                    this.UpdateRawFromPalette();

                    NotifyPropertyChanged();
                }
            }
        }

        public int Length
        {
            get => this.PaletteColor.Length;
        }

        public byte[] GetRawPalette()
        {
            return this.RawPalette;
        }

        public void SetRawPalette(byte[] rawpalette)
        {
            this.RawPalette = new byte[rawpalette.Length];
            Array.Copy(rawpalette, this.RawPalette, rawpalette.Length);

            UpdatePaletteFromRaw();
        }

        void UpdatePaletteFromRaw()
        {
            var startIndex = 0;
            var length = RawPalette.Length == 30 ? 16 : RawPalette.Length / 2;
            this.PaletteColor = new Color[length];

            if (RawPalette.Length == 30)
            {
                this.PaletteColor[0] = Color.FromArgb(0, 0, 0);
                startIndex = 1;
            }

            for (var i = startIndex; i < this.PaletteColor.Length; i++)
            {
                this.PaletteColor[i] = SpriteUtilities.GetColorFromBytes(this.RawPalette[(i - startIndex) * 2], this.RawPalette[(i - startIndex) * 2 + 1]);
            }
        }

        void UpdateRawFromPalette()
        {
            this.RawPalette = new byte[this.PaletteColor.Length * 2];

            for (var i = 0; i < this.PaletteColor.Length; i++)
            {
                var rawBytes = SpriteUtilities.GetBytesFromColor(this.PaletteColor[i]);

                this.RawPalette[i * 2] = rawBytes[0];
                this.RawPalette[i * 2 + 1] = rawBytes[1];
            }
        }
    }
}
