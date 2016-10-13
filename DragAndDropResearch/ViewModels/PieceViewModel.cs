using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDropResearch.DragAndDrop;
using DragAndDropResearch.MicroMvvm;

namespace DragAndDropResearch.ViewModels
{
    internal class PieceViewModel : ObservableObject, IDragTarget
    {
        private SquareViewModel _square;

        public SquareViewModel Square
        {
            get
            {
                return _square;
            }
            set
            {
                if (_square != value)
                {
                    var square = _square;
                    _square = null;
                    if (square != null)
                    {
                        square.Piece = null;
                    }
                    _square = value;
                    if (_square != null)
                    {
                        _square.Piece = this;
                    }
                    RaisePropertyChanged();
                }
            }
        }

        public event Action<object> AfterDrag;
        public event Action<object> BeforeDrag;
        public event Action<IDropTarget> OnDrop;

        void IDragTarget.AfterDrag(object sender)
        {
            AfterDrag?.Invoke(sender);
        }

        void IDragTarget.BeforeDrag(object sender)
        {
            BeforeDrag?.Invoke(sender);
        }

        void IDragTarget.OnDrop(IDropTarget dropTarget)
        {
            OnDrop?.Invoke(dropTarget);
        }
    }
}
