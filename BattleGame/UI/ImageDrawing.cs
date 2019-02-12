using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleGame.UI
{
    class ImageDrawing
    {
        public static Bitmap DrawInfrastructure(string toDraw, string location)
        {
            Bitmap myBitmap = new Bitmap(@location);
            Graphics g = Graphics.FromImage(myBitmap);

            RectangleF rectf = new RectangleF(655, 460, 535, 90); //rectf for My Text
            //g.DrawRectangle(new Pen(Color.Red, 2), 655, 460, 535, 90); 
            /*
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; */
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(toDraw, new System.Drawing.Font("Tahoma", 32, FontStyle.Bold), Brushes.Black, rectf, sf);
            return myBitmap;
        }
    }
}
