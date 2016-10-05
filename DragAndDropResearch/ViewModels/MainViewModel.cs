using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragAndDropResearch.ViewModels
{
    internal class MainViewModel
    {
        public MainViewModel()
        {
            Collection1 = new CollectionViewModel {new ItemViewModel()};
            Collection2 = new CollectionViewModel();
        }

        public CollectionViewModel Collection1 { get; }
        public CollectionViewModel Collection2 { get; }
    }
}
