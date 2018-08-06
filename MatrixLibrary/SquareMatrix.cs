using System;
using System.Collections.Generic;

namespace MatrixLibrary
{
    /// <summary>
    /// Square matrix class.
    /// </summary>
    /// <typeparam name="T">Element of matrix.</typeparam>
    public class SquareMatrix<T> : Matrix<T>
    {
        #region Constants

        private const int DefaultSize = 4;

        #endregion

        #region Fields

        /// <summary>
        /// SZ-array of all matrix elements.
        /// </summary>
        private readonly T[] inner;

        #endregion

        #region Constructors

        public SquareMatrix(int size = DefaultSize)
            : base(size)
        {
            this.inner = new T[size * size];
        }

        public SquareMatrix(T[,] array) : this(array.GetLength(0))
        {
            this.ValidateMatrix(array);

            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    this.inner[i + j * this.Size] = array[i, j];
                }
            }
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
            return this.inner[i + j * this.Size];
        }

        protected override void SetValue(int i, int j, T value)
        {
            this.inner[i + j * this.Size] = value;
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
        }

        #endregion
    }
}