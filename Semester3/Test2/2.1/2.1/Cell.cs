using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace _2._1
{
    /// <summary>
    /// Cell class
    /// </summary>
    public class Cell : INotifyPropertyChanged
    {
        private string mark;
        private bool canSelect = true;
        public int Index { get; private set; }

        public Cell(int index)
        {
            Index = index;
        }

        /// <summary>
        /// Cell's mark
        /// </summary>
        public string Mark
        {
            get => mark;
            set
            {
                mark = value;
                if (value != null)
                {
                    CanSelect = false;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(mark)));
            }
        }

        /// <summary>
        /// Defines wheter or not this cell can be selected
        /// </summary>
        public bool CanSelect
        {
            get => canSelect;
            set
            {
                canSelect = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(canSelect)));
            }
        }

        /// <summary>
        /// Property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
