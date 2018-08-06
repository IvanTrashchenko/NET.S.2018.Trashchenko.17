using System;

namespace MatrixLibrary
{
    public class MatrixEventArgs : EventArgs
    {
        public MatrixEventArgs(int i, int j)
        {
            this.Row = i;
            this.Column = j;
        }

        public int Column { get; }

        public int Row { get; }
    }
}