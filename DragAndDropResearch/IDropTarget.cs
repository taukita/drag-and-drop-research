using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragAndDropResearch
{
    interface IDropTarget
    {
        Type Type { get; }
        void Drop(object item);
    }
}
