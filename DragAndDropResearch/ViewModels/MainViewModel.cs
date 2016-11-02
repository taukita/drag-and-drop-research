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
            Chessboard = ChessboardViewModel.CreateFull();
        }

        public ChessboardViewModel Chessboard { get; }
    }
}
