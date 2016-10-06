using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDropResearch.DragAndDrop;

namespace DragAndDropResearch.ViewModels
{
    internal class CollectionViewModel : ObservableCollection<ItemViewModel>, IDropTarget
    {
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
            ItemViewModel item;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    item = (ItemViewModel) e.NewItems[0];
                    item.Collection = this;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    item = (ItemViewModel) e.OldItems[0];
                    item.Collection = null;
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    throw new NotSupportedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected override void InsertItem(int index, ItemViewModel item)
        {
            if (!Contains(item))
            {
                base.InsertItem(index, item);
            }
        }

        public Type Type { get; } = typeof (ItemViewModel);

        public void Drop(object item)
        {
            Add((ItemViewModel) item);
        }
    }
}
