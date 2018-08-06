using NUnit.Framework;

namespace MatrixLibrary.Tests
{
    [TestFixture]
    public class MatrixTests
    {
        private readonly int[,] sq = new int[,] { { 1, 2, 3 },
                                                  { 4, 5, 6 },
                                                  { 7, 8, 9 } };

        private readonly int[,] diag = new int[,] { { 1, 0, 0 }, 
                                                    { 0, 1, 0 }, 
                                                    { 0, 0, 1 } };

        private readonly int[,] symm = new int[,] { { 1, 7, 3 }, 
                                                    { 7, 4, -5 }, 
                                                    { 3, -5, 6 } };

        [Test]
        public void Add_Square_Tests()
        {
            SquareMatrix<int> lhs = new SquareMatrix<int>(sq);

            SquareMatrix<int> rhs1 = new SquareMatrix<int>(diag);
            DiagonalMatrix<int> rhs2 = new DiagonalMatrix<int>(diag);
            SymmetricMatrix<int> rhs3 = new SymmetricMatrix<int>(diag);

            int[,] expected = new int[,] { { 2, 2, 3 },
                                           { 4, 6, 6 },
                                           { 7, 8, 10 } };

            CollectionAssert.AreEqual(new SquareMatrix<int>(expected), lhs.Add(rhs1));
            CollectionAssert.AreEqual(new SquareMatrix<int>(expected), lhs.Add(rhs2));
            CollectionAssert.AreEqual(new SquareMatrix<int>(expected), lhs.Add(rhs3));
        }

        [Test]
        public void Add_Diagonal_Tests()
        {
            DiagonalMatrix<int> lhs = new DiagonalMatrix<int>(diag);

            SquareMatrix<int> rhs1 = new SquareMatrix<int>(diag);
            DiagonalMatrix<int> rhs2 = new DiagonalMatrix<int>(diag);
            SymmetricMatrix<int> rhs3 = new SymmetricMatrix<int>(diag);

            int[,] expected = new int[,] { { 2, 0, 0 },
                                           { 0, 2, 0 },
                                           { 0, 0, 2 } };

            CollectionAssert.AreEqual(new SquareMatrix<int>(expected), lhs.Add(rhs1));
            CollectionAssert.AreEqual(new DiagonalMatrix<int>(expected), lhs.Add(rhs2));
            CollectionAssert.AreEqual(new SymmetricMatrix<int>(expected), lhs.Add(rhs3));
        }

        [Test]
        public void Add_Symmetric_Tests()
        {
            SymmetricMatrix<int> lhs = new SymmetricMatrix<int>(symm);

            SquareMatrix<int> rhs1 = new SquareMatrix<int>(diag);
            DiagonalMatrix<int> rhs2 = new DiagonalMatrix<int>(diag);
            SymmetricMatrix<int> rhs3 = new SymmetricMatrix<int>(diag);

            int[,] expected = new int[,]  { { 2, 7, 3 },
                                            { 7, 5, -5 },
                                            { 3, -5, 7 } };
        
            CollectionAssert.AreEqual(new SquareMatrix<int>(expected), lhs.Add(rhs1));
            CollectionAssert.AreEqual(new SymmetricMatrix<int>(expected), lhs.Add(rhs2));
            CollectionAssert.AreEqual(new SymmetricMatrix<int>(expected), lhs.Add(rhs3));
        }
    }
}