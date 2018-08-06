using System;

namespace MatrixLibrary
{
    // у меня есть подозрения, что всё это очень плохой код 
    public static class MatrixExtension
    {
        public static Matrix<T> Add<T>(this Matrix<T> lhs, Matrix<T> rhs)
        {
            if (lhs.Size != rhs.Size)
            {
                throw new InvalidOperationException();
            }

            return Add((dynamic)lhs, (dynamic)rhs);
        }

        private static void Addition<T>(Matrix<T> result, Matrix<T> lhs, Matrix<T> rhs)
        {
            for (int i = 0; i < result.Size; i++)
            {
                for (int j = 0; j < result.Size; j++)
                {
                    result[i, j] = (dynamic)lhs[i, j] + rhs[i, j];
                }
            }
        }

        private static SquareMatrix<T> Add<T>(SquareMatrix<T> lhs, Matrix<T> rhs)
        {
            var result = new SquareMatrix<T>(lhs.Size);

            Addition(result, lhs, rhs);

            return result;
        }

        private static SymmetricMatrix<T> Add<T>(SymmetricMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            var result = new SymmetricMatrix<T>(lhs.Size);

            Addition(result, lhs, rhs);

            return result;
        }

        private static SquareMatrix<T> Add<T>(SymmetricMatrix<T> lhs, SquareMatrix<T> rhs) => Add(rhs, lhs);

        private static SymmetricMatrix<T> Add<T>(SymmetricMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            var result = new SymmetricMatrix<T>(lhs.Size);

            Addition(result, lhs, rhs);

            return result;
        }

        private static DiagonalMatrix<T> Add<T>(DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            var result = new DiagonalMatrix<T>(lhs.Size);

            for (int i = 0; i < result.Size; i++)
            {
                for (int j = 0; j < result.Size; j++)
                {
                    if (i == j)
                    {
                        result[i, j] = (dynamic)lhs[i, j] + rhs[i, j];
                    }
                }
            }

            return result;
        }

        private static SymmetricMatrix<T> Add<T>(DiagonalMatrix<T> lhs, SymmetricMatrix<T> rhs) => Add(rhs, lhs);

        private static SquareMatrix<T> Add<T>(DiagonalMatrix<T> lhs, SquareMatrix<T> rhs) => Add(rhs, lhs);
    }
}
