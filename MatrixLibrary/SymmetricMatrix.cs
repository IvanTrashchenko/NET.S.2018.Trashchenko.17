using System;
using System.Collections.Generic;

namespace MatrixLibrary
{
    /// <summary>
    /// Symmetric matrix class.
    /// </summary>
    /// <typeparam name="T">Element of matrix.</typeparam>
    public class SymmetricMatrix<T> : Matrix<T>
    {
        #region Constants

        private const int DefaultSize = 4;

        #endregion

        #region Fields

        /// <summary>
        /// SZ-array which contains only elements on one side of the main diagonal of the matrix. (~1/2 of matrix)
        /// </summary>
        private readonly T[] inner;

        #endregion

        #region Constructors

        public SymmetricMatrix(int size = DefaultSize)
            : base(size)
        {
            this.inner = new T[this.CalculateInnerSize(size)];
        }

        public SymmetricMatrix(T[,] array)
            : this(array.GetLength(0))
        {
            this.ValidateMatrix(array);

            List<T> innerList = new List<T>();

            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    innerList.Add(array[i, j]);
                }
            }

            this.inner = innerList.ToArray();
        }

        #endregion

        #region Matrix members

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.inner)
            {
                yield return item;
            }
        }

        protected override T GetValue(int i, int j)
        {
            if (j > i)
            {
                this.Swap(ref i, ref j);
            }

            int k = 0;
            if (i > 1)
            {
                k = 2 * (i - 2) + 1;
            }

            return this.inner[i + j + k];
        }

        protected override void SetValue(int i, int j, T value)
        {
            int k = 0;
            if (i > 1)
            {
                k = 2 * (i - 2) + 1;
            }

            this.inner[i + j + k] = value;
        }

        #endregion

        #region Methods

        protected void ValidateMatrix(T[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.GetLength(0) != array.GetLength(1))
            {
                throw new ArgumentException(nameof(array));
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (!EqualityComparer<T>.Default.Equals(array[i, j], array[j, i]))
                    {
                        throw new ArgumentException(nameof(array));
                    }
                }
            }
        }

        protected int CalculateInnerSize(int matrixSize)
        {
            int result = 0;
            for (int i = matrixSize; i > 0; i--)
            {
                result += i;
            }

            return result;
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        
        #endregion
    }
}
