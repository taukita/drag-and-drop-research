using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDropResearch.MicroMvvm;

namespace DragAndDropResearch.ViewModels
{
    internal class PieceViewModel : ObservableObject
    {
        private SquareViewModel _square;

        public SquareViewModel Square
        {
            get
            {
                return _square;
            }
            set
            {
                if (_square != value)
                {
                    var square = _square;
                    _square = null;
                    if (square != null)
                    {
                        square.Piece = null;
                    }
                    _square = value;
                    if (_square != null)
                    {
                        _square.Piece = this;
                    }
                    RaisePropertyChanged();
                }
            }
        }
    }
}
