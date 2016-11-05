using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDropResearch.ViewModels;

namespace DragAndDropResearch.Pieces
{
    internal abstract class PieceImpl
    {
        protected PieceImpl(bool isBlack)
        {
            IsBlack = isBlack;
        }

        public bool IsBlack { get; }

        public string Name
        {
            get
            {
                var color = IsBlack ? "Black" : "White";
                return $"{color}{NameImpl}";
            }
        }

        protected abstract string NameImpl { get; }

        public abstract IEnumerable<SquareViewModel> AvailableSquares(ChessboardViewModel board, int column, int row);

        protected IEnumerable<SquareViewModel> AvailableSquares(
            ChessboardViewModel board, int column, int row,
            Func<int, int> updateColumn, Func<int, int> updateRow)
        {
            var c = column;
            var r = row;
            var finished = false;
            while (!finished)
            {
                c = updateColumn(c);
                r = updateRow(r);
                var square = board[c, r];
                finished = square == null || square.Piece != null;
                if (square?.Piece?.IsBlack != IsBlack)
                {
                    yield return square;
                }
            }
        }

        protected SquareViewModel Check(SquareViewModel square)
        {
            return square?.Piece?.IsBlack != IsBlack ? square : null;
        }
    }
}
