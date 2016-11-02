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
        private bool _isActive;
        
        public SquareViewModel(int column, int row, ChessboardViewModel board)
        {
            Column = column;
            Row = row;
            Board = board;
        }

        public int Column { get; }
        public int Row { get; }

        public string Name => $"{"ABCDEFGH"[Column]}{"12345678"[Row]}";

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

        public ChessboardViewModel Board { get; }

        public Type Type => typeof (PieceViewModel);

        public bool IsBlack => Row%2 == 0 ? Column%2 == 1 : Column%2 == 0;

        public void Drop(object item)
        {
            Piece = (PieceViewModel) item;
        }

        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
