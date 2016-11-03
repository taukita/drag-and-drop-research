using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDropResearch.ViewModels;

namespace DragAndDropResearch.Pieces
{
    internal class RookImpl : PieceImpl
    {
        public RookImpl(bool isBlack) : base(isBlack)
        {
        }

        protected override string NameImpl => "Rook";

        public override IEnumerable<SquareViewModel> AvailableSquares(ChessboardViewModel board, int column, int row)
        {
            var runner = new Runner(board, column, row, IsBlack, c => c, r => r + 1);
            var square = runner.Next();
            while (square != null)
            {
                yield return square;
                square = runner.Next();
            }
            runner = new Runner(board, column, row, IsBlack, c => c, r => r - 1);
            square = runner.Next();
            while (square != null)
            {
                yield return square;
                square = runner.Next();
            }
            runner = new Runner(board, column, row, IsBlack, c => c + 1, r => r);
            square = runner.Next();
            while (square != null)
            {
                yield return square;
                square = runner.Next();
            }
            runner = new Runner(board, column, row, IsBlack, c => c - 1, r => r);
            square = runner.Next();
            while (square != null)
            {
                yield return square;
                square = runner.Next();
            }
        }

        private class Runner
        {
            private readonly ChessboardViewModel _board;
            private int _column;
            private int _row;
            private bool _finished;
            private readonly Func<int, int> _updateColumn;
            private readonly Func<int, int> _updateRow;
            private readonly bool _isBlack;

            public Runner(ChessboardViewModel board, int column, int row, bool isBlack, Func<int, int> updateColumn, Func<int, int> updateRow)
            {
                _board = board;
                _column = column;
                _row = row;
                _updateColumn = updateColumn;
                _updateRow = updateRow;
                _isBlack = isBlack;
            }

            public SquareViewModel Next()
            {
                if (_finished) return null;
                _column = _updateColumn(_column);
                _row = _updateRow(_row);
                var square = _board[_column, _row];
                _finished = square == null || square.Piece != null;
                return square?.Piece?.IsBlack == _isBlack ? null : square;
            }
        }
    }
}
