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
    }
}
