﻿using System;
using System.Drawing;
using System.Text;

namespace EnemizerLibrary
{
    public class Sprite
    {
        public const string OpenFileDialogFilter = "Sprite File (*.spr;*.zspr)|*.spr;*.zspr|ZSprite File (*.zspr)|*.zspr|Legacy Sprite File (*.spr)|*.spr|All Files (*.*)|*.*";
        public const string SaveFileDialogFilter = "ZSprite File (*.zspr)|*.zspr|All Files (*.*)|*.*";

        /*
        header flag (4 bytes) = ZSPR
        version (1 byte)
        checksum (4 byte) = 2 bytes + complement 2 bytes
        pixel data offset (4 bytes)
        pixel data length (2 bytes)
        palette data offset (4 bytes)
        palette data length (2 bytes)
        type (2 bytes)
        reserved (6 bytes)
        display text (x bytes) (unicode, null terminated)
        author (x bytes) (unicode, null terminated)
        author rom display (x bytes) (ascii, null terminated)
        sprite data (0x7000 bytes for character sprites)
        palette data (0x78 + 4 bytes [gloves] for character sprites) (remember to add extra bytes for gloves)
        */

        public string Header { get; protected set; } = "ZSPR";
        protected const int HeaderOffset = 0;
        protected const int HeaderLength = 4;

        public byte Version { get; protected set; } = 1;
        protected const int VersionOffset = HeaderOffset + HeaderLength;
        protected const int VersionLength = 1;
        protected const int CurrentVersion = 1;

        public uint CheckSum { get; protected set; }
        protected const int ChecksumOffset = VersionOffset + VersionLength;
        protected const int ChecksumLength = 4;

        public bool HasValidChecksum { get; protected set; }

        public uint PixelDataOffset { get; protected set; }
        protected const int PixelDataOffsetOffset = ChecksumOffset + ChecksumLength;
        protected const int PixelDataOffsetLength = 4;

        public ushort PixelDataLength { get; protected set; }
        protected const int PixelDataLengthOffset = PixelDataOffsetOffset + PixelDataOffsetLength;
        protected const int PixelDataLengthLength = 2;

        public uint PaletteDataOffset { get; protected set; }
        protected const int PaletteDataOffsetOffset = PixelDataLengthOffset + PixelDataLengthLength;
        protected const int PaletteDataOffsetLength = 4;

        public ushort PaletteDataLength { get; protected set; }
        protected const int PaletteDataLengthOffset = PaletteDataOffsetOffset + PaletteDataOffsetLength;
        protected const int PaletteDataLengthLength = 2;

        public ushort SpriteType { get; protected set; }
        protected const int SpriteTypeOffset = PaletteDataLengthOffset + PaletteDataLengthLength;
        protected const int SpriteTypeLength = 2;

        public byte[] Reserved { get; protected set; } = new byte[ReservedLength];
        protected const int ReservedOffset = SpriteTypeOffset + SpriteTypeLength;
        protected const int ReservedLength = 6;

        protected string displayText;
        protected byte[] displayBytes;

        public string DisplayText
        {
            get => displayText;
            set
            {
                displayText = value;
                displayBytes = Encoding.Unicode.GetBytes(displayText + '\0');
                displayBytesLength = (uint)displayBytes.Length;

                RecalculatePixelAndPaletteOffset();
            }
        }

        protected const uint DisplayTextOffset = ReservedOffset + ReservedLength;
        protected uint displayBytesLength = 0;

        protected string author;
        protected byte[] authorBytes;
        public string Author
        {
            get => author;
            set
            {
                author = value;
                authorBytes = Encoding.Unicode.GetBytes(author + '\0');
                authorBytesLength = (uint)authorBytes.Length;

                RecalculatePixelAndPaletteOffset();
            }
        }
        protected uint authorBytesLength = 0;

        protected string authorRomDisplay;
        protected byte[] authorRomDisplayBytes;
        public string AuthorRomDisplay
        {
            get => authorRomDisplay;
            set
            {
                if (value.Length > 20)
                {
                    value = value.Substring(0, 20);
                }
                authorRomDisplay = value;

                authorRomDisplayBytes = Encoding.ASCII.GetBytes(authorRomDisplay + '\0');
                authorRomDisplayBytesLength = (uint)authorRomDisplayBytes.Length;

                RecalculatePixelAndPaletteOffset();
            }
        }
        protected uint authorRomDisplayBytesLength;
        public const int AuthorRomDisplayMaxLength = 20;

        protected byte[] pixelData;
        public byte[] PixelData
        {
            get => pixelData;
            set
            {
                pixelData = value;

                RecalculatePixelAndPaletteOffset();
            }
        }

        public void Set4bppPixelData(byte[] pixels)
        {
            this.pixelData = pixels;

            RecalculatePixelAndPaletteOffset();
        }

        protected byte[] paletteData;
        public byte[] PaletteData
        {
            get => paletteData;
            set
            {
                paletteData = value;

                RecalculatePixelAndPaletteOffset();
                RebuildPalette();
            }
        }

        public Color[] Palette { get; protected set; }
        public virtual void SetPalette(Color[] palette)
        {
            this.Palette = palette;

            RebuildPaletteData();
        }

        public Sprite()
        {
            Version = 1;
            CheckSum = 0xFFFF0000;
            PixelDataLength = 0x7000;
            PaletteDataLength = 0x78;
            SpriteType = 0;
            DisplayText = "Unknown";
            Author = "Unknown";
            AuthorRomDisplay = "Unknown";
            PixelData = new byte[PixelDataLength];
            PaletteData = new byte[PaletteDataLength];

            RebuildPalette();
        }

        public Sprite(byte[] rawData)
        {
            if (rawData.Length == 0x7078)
            {
                // old headerless sprite file
                Version = 0;
                CheckSum = 0;
                SpriteType = 1;
                DisplayText = "";
                Author = "";
                AuthorRomDisplay = "";
                PixelData = new byte[0x7000];
                Array.Copy(rawData, PixelData, 0x7000);
                PaletteData = new byte[0x78];
                Array.Copy(rawData, 0x7000, PaletteData, 0, 0x78);

                PixelDataLength = 0x7000;
                PaletteDataLength = 0x78;

                RebuildPalette();

                return;
            }

            if (rawData.Length < HeaderLength + VersionLength + ChecksumLength + PixelDataOffsetLength + PixelDataLengthLength + PaletteDataOffsetLength + PaletteDataLengthLength)
            {
                throw new Exception("Invalid sprite file. Too short.");
            }

            if (!IsZSprite(rawData))
            {
                throw new Exception("Invalid sprite file. Wrong header.");
            }

            Version = rawData[VersionOffset];

            CheckSum = BytesToUInt(rawData, ChecksumOffset);

            PixelDataOffset = BytesToUInt(rawData, PixelDataOffsetOffset);
            PixelDataLength = BytesToUShort(rawData, PixelDataLengthOffset);

            PaletteDataOffset = BytesToUInt(rawData, PaletteDataOffsetOffset);
            PaletteDataLength = BytesToUShort(rawData, PaletteDataLengthOffset);

            if (PaletteDataLength % 2 != 0)
            {
                throw new Exception("Invalid sprite file. Palette size must be even.");
            }

            SpriteType = BytesToUShort(rawData, SpriteTypeOffset);

            Array.Copy(rawData, ReservedOffset, Reserved, 0, ReservedLength);

            var endOfDisplay = GetNullTerminatorUnicodeLocation(rawData, DisplayTextOffset);
            var displayLength = endOfDisplay - DisplayTextOffset;
            if (displayLength > 0)
            {
                var displayTextBytes = new byte[displayLength];
                Array.Copy(rawData, DisplayTextOffset, displayTextBytes, 0, displayLength);
                DisplayText = Encoding.Unicode.GetString(displayTextBytes);
            }
            else
            {
                DisplayText = "";
            }

            var authorTextOffset = endOfDisplay + 2;
            var endOfAuthor = GetNullTerminatorUnicodeLocation(rawData, authorTextOffset);
            var authorLength = endOfAuthor - authorTextOffset;
            if (authorLength > 0)
            {
                var authorTextBytes = new byte[authorLength];
                Array.Copy(rawData, authorTextOffset, authorTextBytes, 0, authorLength);
                Author = Encoding.Unicode.GetString(authorTextBytes);
            }
            else
            {
                Author = "";
            }

            var authorRomDisplayTextOffset = endOfAuthor + 2;
            var endOfAuthorRomDisplay = GetNullTerminatorAsciiLocation(rawData, authorRomDisplayTextOffset);
            var authorRomDisplayLength = endOfAuthorRomDisplay - authorRomDisplayTextOffset;
            if (authorRomDisplayLength > 0)
            {
                var authorRomDisplayTextBytes = new byte[authorRomDisplayLength];
                Array.Copy(rawData, authorRomDisplayTextOffset, authorRomDisplayTextBytes, 0, authorRomDisplayLength);
                AuthorRomDisplay = Encoding.ASCII.GetString(authorRomDisplayTextBytes);
            }
            else
            {
                AuthorRomDisplay = "";
            }

            PixelData = new byte[PixelDataLength];
            Array.Copy(rawData, PixelDataOffset, PixelData, 0, PixelDataLength);
            PaletteData = new byte[PaletteDataLength];
            Array.Copy(rawData, PaletteDataOffset, PaletteData, 0, PaletteDataLength);

            RebuildPalette();

            HasValidChecksum = IsCheckSumValid();
        }

        public uint GetNullTerminatorUnicodeLocation(byte[] rawData, uint offset)
        {
            for (var i = offset; i < rawData.Length; i += 2)
            {
                if (rawData[i] == 0 && i + 1 < rawData.Length && rawData[i + 1] == 0)
                {
                    return i;
                }
            }

            return offset;
        }

        public uint GetNullTerminatorAsciiLocation(byte[] rawData, uint offset)
        {
            for (var i = offset; i < rawData.Length; i++)
            {
                if (rawData[i] == 0) return i;
            }

            return offset;
        }

        public bool IsZSprite(byte[] rawData)
        {
            if (rawData.Length < 4 || rawData[0] != 'Z' || rawData[1] != 'S' || rawData[2] != 'P' || rawData[3] != 'R')
            {
                return false;
            }

            return true;
        }

        public byte[] ToByteArray()
        {
            return ToByteArray(false);
        }

        protected byte[] ToByteArray(bool skipChecksum)
        {
            this.RebuildPaletteData();

            if (false == skipChecksum)
            {
                UpdateChecksum();
            }

            Version = CurrentVersion; // update the version

            var ret = new byte[HeaderLength + VersionLength + ChecksumLength + PixelDataOffsetLength + PixelDataLengthLength + PaletteDataOffsetLength + PaletteDataLengthLength + SpriteTypeLength + ReservedLength + displayBytesLength + authorBytesLength + authorRomDisplayBytesLength + PixelDataLength + PaletteDataLength];

            var i = 0;
            ret[i++] = (byte)Header[0];
            ret[i++] = (byte)Header[1];
            ret[i++] = (byte)Header[2];
            ret[i++] = (byte)Header[3];

            ret[i++] = Version;

            // check sum
            var checksum = BitConverter.GetBytes(CheckSum);
            ret[i++] = checksum[0];
            ret[i++] = checksum[1];
            ret[i++] = checksum[2];
            ret[i++] = checksum[3];

            var pixelDataOffset = BitConverter.GetBytes(PixelDataOffset);
            ret[i++] = pixelDataOffset[0];
            ret[i++] = pixelDataOffset[1];
            ret[i++] = pixelDataOffset[2];
            ret[i++] = pixelDataOffset[3];

            var pixelDataLength = BitConverter.GetBytes(PixelDataLength);
            ret[i++] = pixelDataLength[0];
            ret[i++] = pixelDataLength[1];

            var paletteDataOffset = BitConverter.GetBytes(PaletteDataOffset);
            ret[i++] = paletteDataOffset[0];
            ret[i++] = paletteDataOffset[1];
            ret[i++] = paletteDataOffset[2];
            ret[i++] = paletteDataOffset[3];

            var paletteDataLength = BitConverter.GetBytes(PaletteDataLength);
            ret[i++] = paletteDataLength[0];
            ret[i++] = paletteDataLength[1];

            var spriteType = BitConverter.GetBytes(SpriteType);
            ret[i++] = spriteType[0];
            ret[i++] = spriteType[1];

            ret[i++] = Reserved[0];
            ret[i++] = Reserved[1];
            ret[i++] = Reserved[2];
            ret[i++] = Reserved[3];
            ret[i++] = Reserved[4];
            ret[i++] = Reserved[5];

            for (var x = 0; x < displayBytes.Length; x++)
            {
                ret[i++] = displayBytes[x];
            }

            for (var x = 0; x < authorBytes.Length; x++)
            {
                ret[i++] = authorBytes[x];
            }

            for (var x = 0; x < authorRomDisplayBytes.Length; x++)
            {
                ret[i++] = authorRomDisplayBytes[x];
            }

            for (var x = 0; x < PixelData.Length; x++)
            {
                ret[i++] = PixelData[x];
            }

            for (var x = 0; x < PaletteData.Length; x++)
            {
                ret[i++] = PaletteData[x];
            }

            return ret;
        }

        protected uint BytesToUInt(byte[] bytes, int offset)
        {
            return BitConverter.ToUInt32(bytes, offset);
        }

        protected ushort BytesToUShort(byte[] bytes, int offset)
        {
            return BitConverter.ToUInt16(bytes, offset);
        }

        protected void RecalculatePixelAndPaletteOffset()
        {
            PixelDataOffset = DisplayTextOffset + displayBytesLength + authorBytesLength + authorRomDisplayBytesLength;
            PaletteDataOffset = PixelDataOffset + PixelDataLength;
        }

        protected void UpdateChecksum()
        {
            var checksum = new byte[] { 0x00, 0x00, 0xFF, 0xFF };
            CheckSum = BitConverter.ToUInt32(checksum, 0);

            var bytes = this.ToByteArray(true);
            var sum = 0;
            for (var i = 0; i < bytes.Length; i++)
            {
                sum += bytes[i];
            }

            checksum[0] = (byte)(sum & 0xFF);
            checksum[1] = (byte)((sum >> 8) & 0xFF);

            var complement = (sum & 0xFFFF) ^ 0xFFFF;
            checksum[2] = (byte)(complement & 0xFF);
            checksum[3] = (byte)((complement >> 8) & 0xFF);

            CheckSum = BitConverter.ToUInt32(checksum, 0);
        }

        public bool IsCheckSumValid()
        {
            var storedChecksum = BitConverter.GetBytes(CheckSum);
            var checksum = new byte[] { 0x00, 0x00, 0xFF, 0xFF };

            var bytes = this.ToByteArray(true);
            var sum = 0;
            for (var i = 0; i < bytes.Length; i++)
            {
                sum += bytes[i];
            }

            checksum[0] = (byte)(sum & 0xFF);
            checksum[1] = (byte)((sum >> 8) & 0xFF);

            var complement = (sum & 0xFFFF) ^ 0xFFFF;
            checksum[2] = (byte)(complement & 0xFF);
            checksum[3] = (byte)((complement >> 8) & 0xFF);

            return (storedChecksum[0] == checksum[0]
                && storedChecksum[1] == checksum[1]
                && storedChecksum[2] == checksum[2]
                && storedChecksum[3] == checksum[3]);
        }

        protected virtual void RebuildPalette()
        {
            var numberOfPalettes = PaletteData.Length / 2;
            Palette = new Color[numberOfPalettes];

            for (var i = 0; i < numberOfPalettes; i++)
            {
                Palette[i] = SpriteUtilities.GetColorFromBytes(PaletteData[i * 2], PaletteData[i * 2 + 1]);
            }
        }

        protected void RebuildPaletteData()
        {
            if (this.Palette.Length != 60)
            {
                paletteData = new byte[this.Palette.Length * 2];
            }
            else
            {
                paletteData = new byte[this.Palette.Length * 2 + 4];
                // F652 7603
                paletteData[120] = 0xF6;
                paletteData[121] = 0x52;
                paletteData[122] = 0x76;
                paletteData[123] = 0x03;
            }
            this.PaletteDataLength = (ushort)paletteData.Length;

            for (var i = 0; i < this.Palette.Length; i++)
            {
                var bytes = SpriteUtilities.GetBytesFromColor(this.Palette[i]);
                paletteData[i * 2] = bytes[0];
                paletteData[i * 2 + 1] = bytes[1];
            }

            if (this.Palette.Length == 62 && this.Palette[60] == Color.Black)
            {
                paletteData[120] = 0xF6;
                paletteData[121] = 0x52;
                paletteData[122] = 0x76;
                paletteData[123] = 0x03;
            }
        }
    }

    public static class SpriteUtilities
    {
        public static Color GetColorFromBytes(ushort s)
        {
            var b = (int)(((s & 0x7C00) >> 10) << 3);
            var g = (int)(((s & 0x03E0) >> 5) << 3);
            var r = (int)(((s & 0x001F) >> 0) << 3);

            return Color.FromArgb(r, g, b);
        }

        public static Color GetColorFromBytes(byte b1, byte b2)
        {
            var combined = (ushort)((ushort)b1 | ((ushort)b2 << 8));

            return GetColorFromBytes(combined);
        }

        public static ushort GetUShortFromColor(Color c)
        {
            var b = (byte)((c.B >> 3) & 0x1F);
            var g = (byte)((c.G >> 3) & 0x1F);
            var r = (byte)((c.R >> 3) & 0x1F);
            var combined = (ushort)((b << 10) | (g << 5) | (r));
            return combined;
        }

        public static byte[] GetBytesFromColor(Color c)
        {
            var ret = new byte[2];

            var combined = GetUShortFromColor(c);
            ret[0] = (byte)(combined & 0xFF);
            ret[1] = (byte)((combined >> 8) & 0xFF);
            return ret;
        }
    }
}
