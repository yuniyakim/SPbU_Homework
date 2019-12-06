using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace _2._1
{
    /// <summary>
    /// Board class
    /// </summary>
    public class Board
    {
        public int Rows { get; } = 3;
        public int Columns { get; } = 3;
        private ObservableCollection<Cell> cells;

        /// <summary>
        /// Board's cells
        /// </summary>
        public ObservableCollection<Cell> Cells
        {
            get
            {
                if (cells == null)
                {
                    //for (var i =0; i < Rows*Columns; ++i)
                    //{

                    //}
                    cells = new ObservableCollection<Cell>(Enumerable.Range(0, Rows * Columns).Select(i => new Cell(i)));
                }
                return cells;
            }
        }

        /// <summary>
        /// Gets cell wwith given index
        /// </summary>
        /// <param name="index">Given index</param>
        /// <returns></returns>
        public Cell GetCell(int index)
        {
            var cellsArray = Cells.ToArray();
            return cellsArray[index - 1];
        }

        /// <summary>
        /// Defines whether cells are filled with the same mark
        /// </summary>
        /// <param name="index1">First cell's index</param>
        /// <param name="index2">Second cell's index</param>
        /// <param name="index3">Third cell's index</param>
        /// <param name="mark">Mark that cells must be filled with</param>
        /// <returns>True if it's filled with the same mark, false otherwise</returns>
        private bool IsLineWithMark(int index1, int index2, int index3, string mark)
        {
            var cellsArray = Cells.ToArray();
            return (cellsArray[index1 - 1].Mark == mark && cellsArray[index2 - 1].Mark == mark && cellsArray[index3 - 1].Mark == mark);
        }

        /// <summary>
        /// Defines whether cells are filled with the same mark without input mark
        /// </summary>
        /// <param name="index1">First cell's index</param>
        /// <param name="index2">Second cell's index</param>
        /// <param name="index3">Third cell's index</param>
        /// <returns>True if it's filled with the same mark, false otherwise</returns>
        private bool IsLine(int index1, int index2, int index3)
        {
            var cellsArray = Cells.ToArray();
            return (cellsArray[index1 - 1].Mark == null || cellsArray[index2 - 1].Mark == null || cellsArray[index3 - 1].Mark == null) ? false :
            IsLineWithMark(index1, index2, index3, cellsArray[index1 - 1].Mark);
        }

        /// <summary>
        /// Defines whether anyone has won
        /// </summary>
        /// <returns>True if someone has won, false otherwise</returns>
        public bool HasAnyoneWon()
        {
            return IsLine(1, 2, 3) || IsLine(4, 5, 6) || IsLine(7, 8, 9)
                || IsLine(1, 4, 7) || IsLine(2, 5, 8) || IsLine(3, 6, 9)
                || IsLine(1, 5, 9) || IsLine(3, 5, 7);
        }
    }
}
