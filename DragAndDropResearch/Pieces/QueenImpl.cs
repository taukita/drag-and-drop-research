using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDropResearch.ViewModels;

namespace DragAndDropResearch.Pieces
{
    internal class QueenImpl : PieceImpl
    {
        public QueenImpl(bool isBlack) : base(isBlack)
        {
        }

        protected override string NameImpl => "Queen";

        public override IEnumerable<SquareViewModel> AvailableSquares(ChessboardViewModel board, int column, int row)
        {
            return AvailableSquares(board, column, row, c => c, r => r + 1)
                .Concat(AvailableSquares(board, column, row, c => c, r => r - 1))
                .Concat(AvailableSquares(board, column, row, c => c + 1, r => r))
                .Concat(AvailableSquares(board, column, row, c => c - 1, r => r))
                .Concat(AvailableSquares(board, column, row, c => c + 1, r => r + 1))
                .Concat(AvailableSquares(board, column, row, c => c + 1, r => r - 1))
                .Concat(AvailableSquares(board, column, row, c => c - 1, r => r + 1))
                .Concat(AvailableSquares(board, column, row, c => c - 1, r => r - 1));
        }
    }
}
