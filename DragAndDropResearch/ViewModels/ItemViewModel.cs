using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDropResearch.MicroMvvm;

namespace DragAndDropResearch.ViewModels
{
    internal class ItemViewModel : ObservableObject
    {
        private CollectionViewModel _collection;

        public CollectionViewModel Collection
        {
            get
            {
                return _collection;
            }
            set
            {
                if (_collection != value)
                {
                    var collection = _collection;
                    _collection = null;
                    collection?.Remove(this);
                    _collection = value;
                    if (_collection != null && !_collection.Contains(this))
                    {
                        _collection.Add(this);
                    }
                    RaisePropertyChanged();
                }
            }
        }
    }
}
