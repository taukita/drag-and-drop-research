using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDropResearch.ViewModels;

namespace DragAndDropResearch.Pieces
{
    internal class PawnImpl : PieceImpl
    {
        public PawnImpl(bool isBlack) : base(isBlack)
        {
        }

        protected override string NameImpl => "Pawn";

        public override IEnumerable<SquareViewModel> AvailableSquares(ChessboardViewModel board, int column, int row)
        {
            yield return board[column, row + (IsBlack ? -1 : 1)];
            if (row == (IsBlack ? 6 : 1))
            {
                yield return board[column, row + (IsBlack ? -2 : 2)];
            }
            var square = board[column - 1, row + (IsBlack ? -1 : 1)];
            if (square?.Piece != null && square.Piece.IsBlack != IsBlack)
            {
                yield return square;
            }
            square = board[column + 1, row + (IsBlack ? -1 : 1)];
            if (square?.Piece != null && square.Piece.IsBlack != IsBlack)
            {
                yield return square;
            }
        }
    }
}
