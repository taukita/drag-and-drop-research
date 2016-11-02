using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragAndDropResearch.ViewModels;
using NUnit.Framework;

namespace DragAndDropResearch.Tests
{
    [TestFixture]
    internal class PieceAndSquareTests
    {
        [Test]
        public void OnePieceOneSquareTest()
        {
            var piece = new PieceViewModel(true);
            var square = new SquareViewModel(0, 0, null);

            Assert.AreEqual(null, piece.Square);
            Assert.AreEqual(null, square.Piece);

            piece.Square = square;

            Assert.AreEqual(square, piece.Square);
            Assert.AreEqual(piece, square.Piece);

            piece.Square = null;

            Assert.AreEqual(null, piece.Square);
            Assert.AreEqual(null, square.Piece);

            square.Piece = piece;

            Assert.AreEqual(square, piece.Square);
            Assert.AreEqual(piece, square.Piece);

            square.Piece = null;

            Assert.AreEqual(null, piece.Square);
            Assert.AreEqual(null, square.Piece);
        }
    }
}
