using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using DragAndDropResearch.Helpers;

namespace DragAndDropResearch
{
    internal class FrameworkElementDragBehavior : Behavior<FrameworkElement>
    {
        private Cursor _cursor;

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.MouseLeftButtonDown += AssociatedObjectOnMouseLeftButtonDown;
            AssociatedObject.PreviewGiveFeedback += AssociatedObjectOnPreviewGiveFeedback;
        }

        private void AssociatedObjectOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _cursor = CursorHelper.ConvertToCursor(AssociatedObject, e.GetPosition(AssociatedObject));
            AssociatedObject.Visibility = Visibility.Hidden;
            DragDrop.DoDragDrop(AssociatedObject, AssociatedObject.DataContext, DragDropEffects.Move);
            AssociatedObject.Visibility = Visibility.Visible;
            _cursor = null;
        }

        private void AssociatedObjectOnPreviewGiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            Mouse.SetCursor(_cursor);
            e.Handled = true;
        }
    }
}
