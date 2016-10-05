using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace DragAndDropResearch
{
    internal class FrameworkElementDragBehavior : Behavior<FrameworkElement>
    {
        private bool _isTaken;

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.MouseLeftButtonDown += (sender, args) => _isTaken = true;
            AssociatedObject.MouseLeftButtonUp += (sender, args) => _isTaken = false;
            AssociatedObject.MouseLeave += AssociatedObjectOnMouseLeave;
        }

        private void AssociatedObjectOnMouseLeave(object sender, MouseEventArgs mouseEventArgs)
        {
            if (_isTaken)
            {
                var data = new DataObject();
                data.SetData(AssociatedObject.DataContext);
                DragDrop.DoDragDrop(AssociatedObject, data, DragDropEffects.Move);
            }
            _isTaken = false;
        }
    }
}
