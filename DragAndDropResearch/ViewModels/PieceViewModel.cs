using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDropResearch.DragAndDrop;
using DragAndDropResearch.MicroMvvm;
using DragAndDropResearch.Pieces;

namespace DragAndDropResearch.ViewModels
{
    internal class PieceViewModel : ObservableObject, IDragTarget
    {
        private SquareViewModel _square;
        public event Action<object> AfterDrag;
        public event Action<object> BeforeDrag;
        public event Action<IDropTarget> BeforeDrop;
        public event Action<object> AfterDrop; 

        public PieceViewModel(bool isBlack)
        {
            IsBlack = isBlack;
            Impl = new PawnImpl(isBlack);
        }

        public bool IsBlack { get; }

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

        public PieceImpl Impl { get; }

        void IDragTarget.AfterDrag(object sender)
        {
            AfterDrag?.Invoke(sender);
        }

        void IDragTarget.AfterDrop(object sender)
        {
            AfterDrop?.Invoke(sender);
        }

        void IDragTarget.BeforeDrag(object sender)
        {
            BeforeDrag?.Invoke(sender);
        }

        bool IDragTarget.BeforeDrop(IDropTarget dropTarget)
        {
            var square = dropTarget as SquareViewModel;
            if (!AvailableSquares().Contains(square)) return false;
            BeforeDrop?.Invoke(dropTarget);
            return true;
        }

        public SquareViewModel[] AvailableSquares()
        {
            return Impl.AvailableSquares(Square.Board, Square.Column, Square.Row)
                .Where(square => square != null)
                .ToArray();
        }
    }
}