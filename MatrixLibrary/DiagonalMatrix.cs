using System;
using System.Collections.Generic;

namespace MatrixLibrary
{
    /// <summary>
    /// Diagonal matrix class.
    /// </summary>
    /// <typeparam name="T">Element of matrix.</typeparam>
    public class DiagonalMatrix<T> : Matrix<T>
    {
        #region Constants

        private const int DefaultSize = 4;

        #endregion

        #region Fields

        /// <summary>
        /// SZ-array which contains only the elements of the main diagonal of the matrix. 
        /// </summary>
        private readonly T[] inner;

        #endregion

        #region Constructors

        public DiagonalMatrix(int size = DefaultSize)
            : base(size)
        {
            this.inner = new T[size];
        }

        public DiagonalMatrix(T[,] array)
            : this(array.GetLength(0))
        {
            this.ValidateMatrix(array);

            for (int i = 0; i < this.Size; i++)
            {
                this.inner[i] = array[i, i];
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
            if (i != j)
            {
                return default(T);
            }
            else
            {
                return this.inner[i];
            }
        }

        protected override void SetValue(int i, int j, T value)
        {
            if (i != j)
            {
                throw new InvalidOperationException();
            }

            this.inner[i] = value;
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
                    if (i != j && !EqualityComparer<T>.Default.Equals(array[i, j], default(T)))
                    {
                        throw new ArgumentException(nameof(array));
                    }
                }
            }
        }

        #endregion
    }
}
