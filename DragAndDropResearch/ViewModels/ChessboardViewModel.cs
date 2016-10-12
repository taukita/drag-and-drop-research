using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragAndDropResearch.ViewModels
{
    internal class ChessboardViewModel : ICollection<SquareViewModel>
    {
        readonly List<SquareViewModel> _list = new List<SquareViewModel>();

        public ChessboardViewModel()
        {
            var piece1 = new PieceViewModel();
            var piece2 = new PieceViewModel();
            for (var row = 7; row > -1; row--)
            {
                for (var column = 0; column < 8; column++)
                {
                    _list.Add(new SquareViewModel(column, row) {Piece = piece1});
                    piece1 = piece2;
                    piece2 = null;
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
    }
}
