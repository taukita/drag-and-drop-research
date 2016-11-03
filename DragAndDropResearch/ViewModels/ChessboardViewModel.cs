using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragAndDropResearch.ViewModels
{
    internal class ChessboardViewModel : ICollection<SquareViewModel>
    {
        private readonly List<SquareViewModel> _list = new List<SquareViewModel>();
        private SquareViewModel _activeSquare;

        private ChessboardViewModel()
        {
            for (var row = 7; row > -1; row--)
            {
                for (var column = 0; column < 8; column++)
                {
                    _list.Add(new SquareViewModel(column, row, this));
                }
            }
        }

        public SquareViewModel this[int column, int row]
        {
            get
            {
                return _list.FirstOrDefault(square => square.Column == column && square.Row == row);
            }
        }

        public SquareViewModel this[string index]
        {
            get
            {
                var column = "ABCDEFGH".IndexOf(char.ToUpper(index[0]));
                var row = "123456789".IndexOf(index[1]);
                return this[column, row];
            }
        }

        private SquareViewModel ActiveSquare
        {
            get
            {
                return _activeSquare;
            }
            set
            {
                if (_activeSquare != value)
                {
                    if (ActiveSquare != null)
                    {
                        ActiveSquare.IsActive = false;
                    }
                    _activeSquare = value;
                    if (ActiveSquare != null)
                    {
                        ActiveSquare.IsActive = true;
                    }
                }
            }
        }

        public IEnumerator<SquareViewModel> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(SquareViewModel item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(SquareViewModel item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(SquareViewModel[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(SquareViewModel item)
        {
            throw new NotSupportedException();
        }

        public int Count { get; } = 64;
        public bool IsReadOnly { get; } = true;

        public static ChessboardViewModel CreateEmpty()
        {
            return new ChessboardViewModel();
        }

        public static ChessboardViewModel CreateFull()
        {
            var result = new ChessboardViewModel();

            result["A2"].Piece = result.Attach(new PieceViewModel(false));
            result["B2"].Piece = result.Attach(new PieceViewModel(false));
            result["C2"].Piece = result.Attach(new PieceViewModel(false));
            result["D2"].Piece = result.Attach(new PieceViewModel(false));
            result["E2"].Piece = result.Attach(new PieceViewModel(false));
            result["F2"].Piece = result.Attach(new PieceViewModel(false));
            result["G2"].Piece = result.Attach(new PieceViewModel(false));
            result["H2"].Piece = result.Attach(new PieceViewModel(false));

            result["A7"].Piece = result.Attach(new PieceViewModel(true));
            result["B7"].Piece = result.Attach(new PieceViewModel(true));
            result["C7"].Piece = result.Attach(new PieceViewModel(true));
            result["D7"].Piece = result.Attach(new PieceViewModel(true));
            result["E7"].Piece = result.Attach(new PieceViewModel(true));
            result["F7"].Piece = result.Attach(new PieceViewModel(true));
            result["G7"].Piece = result.Attach(new PieceViewModel(true));
            result["H7"].Piece = result.Attach(new PieceViewModel(true));

            return result;
        }

        private PieceViewModel Attach(PieceViewModel piece)
        {
            piece.BeforeDrag += PieceOnBeforeDrag;
            piece.AfterDrop += PieceOnAfterDrop;
            return piece;
        }

        private void PieceOnAfterDrop(object sender)
        {
            ActiveSquare = null;
        }

        private void PieceOnBeforeDrag(object sender)
        {
            var piece = (PieceViewModel) sender;
            ActiveSquare = piece.Square;
        }
    }
}