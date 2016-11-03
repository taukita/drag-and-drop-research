using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDropResearch.Pieces;
using DragAndDropResearch.ViewModels;
using NUnit.Framework;

namespace DragAndDropResearch.Tests
{
    [TestFixture]
    internal class PawnTests
    {
        [Test]
        public void WhitePawnFromB2ShouldMoveToB3OrB4()
        {
            var board = ChessboardViewModel.CreateEmpty();
            board["B2"].Piece = new PieceViewModel(new PawnImpl(false));

            var availableSquares = board["B2"].Piece.AvailableSquares();
            Assert.AreEqual(2, availableSquares.Length);
            Assert.IsTrue(availableSquares.Any(square => square.Name == "B3"));
            Assert.IsTrue(availableSquares.Any(square => square.Name == "B4"));
        }

        [Test]
        public void WhitePawnFromB3ShouldMoveToB4()
        {
            var board = ChessboardViewModel.CreateEmpty();
            board["B3"].Piece = new PieceViewModel(new PawnImpl(false));

            var availableSquares = board["B3"].Piece.AvailableSquares();
            Assert.AreEqual(1, availableSquares.Length);
            Assert.IsTrue(availableSquares.Any(square => square.Name == "B4"));
        }
    }
}
