using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDropResearch.ViewModels;

namespace DragAndDropResearch.Pieces
{
    internal class KingImpl : PieceImpl
    {
        public KingImpl(bool isBlack) : base(isBlack)
        {
        }

        protected override string NameImpl => "King";

        public override IEnumerable<SquareViewModel> AvailableSquares(ChessboardViewModel board, int column, int row)
        {
            yield return Check(board[column - 1, row - 1]);
            yield return Check(board[column - 1, row]);
            yield return Check(board[column - 1, row + 1]);

            yield return Check(board[column, row - 1]);
            yield return Check(board[column, row + 1]);

            yield return Check(board[column + 1, row - 1]);
            yield return Check(board[column + 1, row]);
            yield return Check(board[column + 1, row + 1]);
        }
    }
}
