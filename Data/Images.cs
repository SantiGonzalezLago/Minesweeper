using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Minesweeper.Data
{
    public class Images
    {
        public static readonly ImageSource Flag = Convert(Properties.Resources.Flag);
        public static readonly ImageSource NoFlag = Convert(Properties.Resources.NoFlag);
        public static readonly ImageSource QuestionMark = Convert(Properties.Resources.QuestionMark);

        public static readonly ImageSource MineExploded = Convert(Properties.Resources.MineExploded);
        public static readonly ImageSource MineUnexploded = Convert(Properties.Resources.MineUnexploded);
        public static readonly ImageSource MineWrong = Convert(Properties.Resources.MineWrong);

        public static readonly ImageSource[] Revealed = {
            Convert(Properties.Resources.Revealed0),
            Convert(Properties.Resources.Revealed1),
            Convert(Properties.Resources.Revealed2),
            Convert(Properties.Resources.Revealed3),
            Convert(Properties.Resources.Revealed4),
            Convert(Properties.Resources.Revealed5),
            Convert(Properties.Resources.Revealed6),
            Convert(Properties.Resources.Revealed7),
            Convert(Properties.Resources.Revealed8)
        };

        private static ImageSource Convert(Bitmap bitmap)
        {
            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            var bitmapData = bitmap.LockBits(
                rect,
                ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            try
            {
                var size = (rect.Width * rect.Height) * 4;

                return BitmapSource.Create(
                    bitmap.Width,
                    bitmap.Height,
                    bitmap.HorizontalResolution,
                    bitmap.VerticalResolution,
                    PixelFormats.Bgra32,
                    null,
                    bitmapData.Scan0,
                    size,
                    bitmapData.Stride);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
        }
    }
}
