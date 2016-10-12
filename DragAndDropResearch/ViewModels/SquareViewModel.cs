using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDropResearch.DragAndDrop;
using DragAndDropResearch.MicroMvvm;

namespace DragAndDropResearch.ViewModels
{
    internal class SquareViewModel : ObservableObject, IDropTarget
    {
        private PieceViewModel _piece;

        public SquareViewModel(int column, int row)
        {
            Column = column;
            Row = row;
        }

        public int Column { get; private set; }
        public int Row { get; private set; }

        public PieceViewModel Piece
        {
            get
            {
                return _piece;
            }
            set
            {
                if (_piece != value)
                {
                    var piece = _piece;
                    _piece = null;
                    if (piece != null)
                    {
                        piece.Square = null;
                    }
                    _piece = value;
                    if (_piece != null)
                    {
                        _piece.Square = this;
                    }
                    RaisePropertyChanged();
                }
            }
        }

        public Type Type => typeof (PieceViewModel);

        public bool IsBlack => Row%2 == 0 ? Column%2 == 1 : Column%2 == 0;

        public void Drop(object item)
        {
            Piece = (PieceViewModel) item;
        }
    }
}
