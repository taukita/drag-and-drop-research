using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragAndDropResearch.DragAndDrop
{
    interface IDragTarget
    {
        void AfterDrag(object sender);
        void BeforeDrag(object sender);
        void OnDrop(IDropTarget dropTarget);
    }
}
