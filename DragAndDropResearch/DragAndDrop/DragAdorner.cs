using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DragAndDropResearch.DragAndDrop
{
    internal class DragAdorner : Adorner
    {
        private readonly Brush _brush;
        private Point _offset;
        private Point _location;

        public DragAdorner(UIElement adornedElement, Point offset) : base(adornedElement)
        {
            _offset = offset;
            _brush = GetBrushFromElement(adornedElement);
            IsHitTestVisible = false;
        }

        public Point Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                InvalidateVisual();
            }
        }

        protected override void OnRender(DrawingContext dc)
        {
            var p = new Point(Location.X, Location.Y);
            p.Offset(-_offset.X, -_offset.Y);
            dc.DrawRectangle(_brush, null, new Rect(p, RenderSize));
        }

        private static Brush GetBrushFromElement(Visual adornedElement)
        {
            var bounds = VisualTreeHelper.GetDescendantBounds(adornedElement);
            const double dpi = 96d;

            var rtb = new RenderTargetBitmap((int)bounds.Width, (int)bounds.Height, dpi, dpi, PixelFormats.Default);

            var dv = new DrawingVisual();
            using (var dc = dv.RenderOpen())
            {
                var vb = new VisualBrush(adornedElement);
                dc.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
            }

            rtb.Render(dv);

            var pngStream = new MemoryStream();
            var png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(rtb));
            png.Save(pngStream);

            pngStream.Position = 0;

            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = pngStream;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();

            return new ImageBrush(bitmapImage);
        }
    }
}
