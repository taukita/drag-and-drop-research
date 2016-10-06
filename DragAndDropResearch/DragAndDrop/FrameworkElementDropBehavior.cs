using System.Windows;
using System.Windows.Interactivity;

namespace DragAndDropResearch.DragAndDrop
{
    internal class FrameworkElementDropBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.AllowDrop = true;
            AssociatedObject.DragEnter += (s, e) => e.Handled = true;
            AssociatedObject.DragOver += (s, e) => e.Handled = true;
            AssociatedObject.DragLeave += (s, e) => e.Handled = true;
            AssociatedObject.Drop += AssociatedObjectOnDrop;
        }

        private void AssociatedObjectOnDrop(object sender, DragEventArgs dragEventArgs)
        {
            var dropTarget = AssociatedObject.DataContext as IDropTarget;
            if (dropTarget != null && dragEventArgs.Data.GetDataPresent(dropTarget.Type))
            {
                dropTarget.Drop(dragEventArgs.Data.GetData(dropTarget.Type));
                dragEventArgs.Handled = true;
            }
        }
    }
}
