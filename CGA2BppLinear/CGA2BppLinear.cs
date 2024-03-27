using System;
using System.Drawing;
using CharactorLib.Common;
using CharactorLib.Format;

namespace CGA2BppLinear
{
    public class CGA2BppLinearFormat : FormatBase
    {
        public CGA2BppLinearFormat()
        {
            base.FormatText = "[8][8]";
            base.Name = "2BPP CGA Linear";
            base.Extension = ".ovl";

            base.ColorBit = 2;
            base.ColorNum = 4;
            base.Width = 128;
            base.Height = 128;
            base.CharWidth = 8;
            base.CharHeight = 8;

            base.Readonly = false;
            base.IsSupportMirror = true;
            base.IsSupportRotate = true;
            base.IsCompressed = false;
            base.EnableAdf = true;

            base.Author = "gzip";
            base.Url = "https://github.com/gzip/cs-yychr-plugins";
        }

        /*
            sourceData: contains image data in source format (ROM)
            addr: contains source address
            bytemap: contains image data in YYCHR internal format
            px: contains the x coordinate of the current pixel
            py: contains the y coordinate of the current pixel
        */

        // convert from source format (ROM) to YYCHR graphics, one tile at a time
        public override void ConvertMemToChr(Byte[] sourceData, int addr, Bytemap bytemap, int px, int py)
        {
            for (int x = 0; x < CharWidth; x++)
            {
                for (int y = 0; y < CharHeight; y++)
                {
                    int pixel = 0x00;
                    int byteIndex = y * CharWidth / 4 + (x < 4 ? 0 : 1);
                    int b = sourceData[addr + byteIndex];

                    // get pixel address for requested coordinates in YYCHR bitmap
                    Point p = base.GetAdvancePixelPoint(px + x, py + y);
                    int bytemapAddr = bytemap.GetPointAddress(p.X, p.Y);

                    switch (x % 4)
                    {
                        case 0: pixel = (b & 0b11000000) >> 6; break;
                        case 1: pixel = (b & 0b00110000) >> 4; break;
                        case 2: pixel = (b & 0b00001100) >> 2; break;
                        case 3: pixel =  b & 0b00000011; break;
                    }

                    // write pixel to YYCHR bitmap
                    bytemap.Data[bytemapAddr] = (byte) pixel;
                }
            }
        }

        // convert from YYCHR graphics to source format (ROM), one tile at a time
        public override void ConvertChrToMem(Byte[] sourceData, int addr, Bytemap bytemap, int px, int py)
        {
            for (int x = 0; x < CharWidth; x++)
            {
                for (int y = 0; y < CharHeight; y++)
                {
                    // get pixel from YYCHR bitmap
                    Point p = base.GetAdvancePixelPoint(px + x, py + y);
                    int bytemapAddr = bytemap.GetPointAddress(p.X, p.Y);
                    int pixel = bytemap.Data[bytemapAddr];

                    // calculate the byte index for this pixel
                    int byteIndex = y * CharWidth / 4 + (x < 4 ? 0 : 1);

                    // start fresh if it's a new byte, otherwise grab the existing data
                    int b = x % 4 == 0 ? 0x00 : sourceData[addr + byteIndex];

                    switch (x % 4)
                    {
                        case 0: b |= (pixel << 6); break;
                        case 1: b |= (pixel << 4); break;
                        case 2: b |= (pixel << 2); break;
                        case 3: b |= (pixel); break;
                    }

                    // write pixel to YYCHR bytemap
                    sourceData[addr + byteIndex] = (byte) b;
                }
            }
        }
    }
}
