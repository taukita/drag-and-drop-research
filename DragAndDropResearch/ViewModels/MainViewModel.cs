using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragAndDropResearch.ViewModels
{
    internal class MainViewModel
    {
        public MainViewModel()
        {
            Square1 = new SquareViewModel(1, 1) {Piece = new PieceViewModel()};
            Square2 = new SquareViewModel(1, 1);
        }

        public SquareViewModel Square1 { get; }
        public SquareViewModel Square2 { get; }
    }
}
