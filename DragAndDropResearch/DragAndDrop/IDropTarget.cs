using System;

namespace DragAndDropResearch.DragAndDrop
{
    interface IDropTarget
    {
        Type Type { get; }
        void Drop(object item);
    }
}
