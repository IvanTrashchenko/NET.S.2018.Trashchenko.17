using System;
using System.Collections;
using System.Collections.Generic;

namespace MatrixLibrary
{
    /// <summary>
    /// Class of abstract square matrix.
    /// </summary>
    /// <typeparam name="T">Element of matrix.</typeparam>
    public abstract class Matrix<T> : IEnumerable<T>
    {
        #region Constants

        /// <summary>
        /// Default size of matrix.
        /// </summary>
        private const int DefaultSize = 4;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the matrix class.
        /// </summary>
        /// <param name="size">Size of matrix.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when size value is less than 2.</exception>
        protected Matrix(int size = DefaultSize)
        {
            if (size < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }

            this.Size = size;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Event, which occurs after after the element is changed.
        /// </summary>
        public event EventHandler<MatrixEventArgs> ElementChange = delegate { };

        /// <summary>
        /// Size of matrix property.
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="i">Row.</param>
        /// <param name="j">Column.</param>
        /// <returns>Element of specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when endex is out of range.</exception>
        public T this[int i, int j]
        {
            get
            {
                if (i >= this.Size || i < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(i));
                }

                if (j >= this.Size || j < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(j));
                }

                return this.GetValue(i, j);
            }

            set
            {
                if (i >= this.Size || i < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(i));
                }

                if (j >= this.Size || j < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(j));
                }

                this.SetValue(i, j, value);

                this.OnElementChanged(new MatrixEventArgs(i, j));
            }
        }

        #endregion

        #region IEnumerable members

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts matrix to its multidimensional array representation.
        /// </summary>
        /// <returns>Multidimensional array.</returns>
        public T[,] ToMultiArray()
        {
            T[,] result = new T[this.Size, this.Size];

            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    result[i, j] = this[i, j];
                }
            }

            return result;
        }

        protected abstract T GetValue(int i, int j);

        protected abstract void SetValue(int i, int j, T value);

        protected virtual void OnElementChanged(MatrixEventArgs e)
        {
            this.ElementChange?.Invoke(this, e);
        }

        #endregion
    }
}