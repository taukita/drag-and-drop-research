using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace DragAndDropResearch.DragAndDrop
{
    internal class FrameworkElementDragBehavior : Behavior<FrameworkElement>
    {
        private DragAdorner _dragAdorner;
        private AdornerLayer _adornerLayer;

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.MouseLeftButtonDown += AssociatedObjectOnMouseLeftButtonDown;
            AssociatedObject.PreviewGiveFeedback += AssociatedObjectOnPreviewGiveFeedback;
        }

        private void AssociatedObjectOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _adornerLayer = AdornerLayer.GetAdornerLayer(AssociatedObject);
            var p = e.GetPosition(AssociatedObject);

            _dragAdorner = new DragAdorner(AssociatedObject, p);
            _adornerLayer.Add(_dragAdorner);

            AssociatedObject.Visibility = Visibility.Hidden;

            var dragTarget = AssociatedObject.DataContext as IDragTarget;

            dragTarget?.BeforeDrag(dragTarget);

            DragDrop.DoDragDrop(AssociatedObject, new DragDropInfo(AssociatedObject.DataContext), DragDropEffects.Move);

            dragTarget?.AfterDrop(dragTarget);

            AssociatedObject.Visibility = Visibility.Visible;

            _adornerLayer.Remove(_dragAdorner);
            _dragAdorner = null;
        }

        private void AssociatedObjectOnPreviewGiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            _dragAdorner.Location = CorrectGetPosition(AssociatedObject);
            _dragAdorner.InvalidateVisual();
            e.Handled = true;
        }

        private static Point CorrectGetPosition(Visual relativeTo)
        {
            var w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return relativeTo.PointFromScreen(new Point(w32Mouse.X, w32Mouse.Y));
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Win32Point
        {
            // ReSharper disable FieldCanBeMadeReadOnly.Local
            public int X;
            public int Y;
            // ReSharper enable FieldCanBeMadeReadOnly.Local
        };

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(ref Win32Point pt);
    }
}
