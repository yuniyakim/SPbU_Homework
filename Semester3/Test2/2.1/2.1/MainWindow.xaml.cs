using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Board board = new Board();
        private bool isFirstPlayer = true;
        private int amountOfMoves = 0;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = board;
        }

        /// <summary>
        /// Click on cell
        /// </summary>
        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            var cell = (sender as Button).DataContext as Cell;
            cell.Mark = isFirstPlayer ? "X" : "O";
            isFirstPlayer = !isFirstPlayer;

            var row = Grid.GetRow(sender as Button); // Doesn't work here
            var column = Grid.GetColumn(sender as Button);// And here
            var index = (row == 1 ? column : (row == 2 ? column + 3 : column + 6));
            board.GetCell(index).Mark = cell.Mark;

            ++amountOfMoves;

            if (board.HasAnyoneWon() || amountOfMoves == 9)
            {
                Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
        }
    }
}
