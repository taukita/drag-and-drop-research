using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragAndDropResearch.DragAndDrop
{
    internal class DragDropInfo
    {
        public DragDropInfo(object value)
        {
            Value = value;
        }

        public object Value { get; }
    }
}
