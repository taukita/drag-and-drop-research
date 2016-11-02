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
            if (dragEventArgs.Data.GetDataPresent(typeof (DragDropInfo)))
            {
                var dragDropInfo = (DragDropInfo) dragEventArgs.Data.GetData(typeof (DragDropInfo));
                var data = dragDropInfo?.Value;
                (data as IDragTarget)?.AfterDrag(data);
                var dropTarget = AssociatedObject.DataContext as IDropTarget;
                if (dropTarget != null && data?.GetType() == dropTarget.Type)
                {
                    if ((data as IDragTarget)?.BeforeDrop(dropTarget) == true)
                    {
                        dropTarget.Drop(data);
                    }
                    dragEventArgs.Handled = true;
                }
            }
        }
    }
}
