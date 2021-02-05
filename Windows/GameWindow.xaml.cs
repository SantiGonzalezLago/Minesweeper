using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Minesweeper.Windows
{
    public partial class GameWindow : Window
    {
        private Image[,] _tiles;
        private ColumnDefinition[] _cols;
        private RowDefinition[] _rows;

        public GameWindow()
        {
            InitializeComponent();
        }

        public void FillGameGrid(ushort height, ushort width)
        {
            //Borrado del grid anterior
            GameGrid.Children.Clear();
            GameGrid.ColumnDefinitions.Clear();
            GameGrid.RowDefinitions.Clear();

            //Creación de filas
            _rows = new RowDefinition[height];
            for (int i = 0; i < height; i++)
            {
                _rows[i] = new RowDefinition();
                GameGrid.RowDefinitions.Add(_rows[i]);
            }

            //Creación de columnas
            _cols = new ColumnDefinition[width];
            for (int i = 0; i < width; i++)
            {
                _cols[i] = new ColumnDefinition();
                GameGrid.ColumnDefinitions.Add(_cols[i]);

            }

            //Creación de tiles
            _tiles = new Image[height, width];
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    _tiles[row, col] = new Image();
                    _tiles[row, col].Source = Data.Images.NoFlag;
                    Grid.SetRow(_tiles[row, col], row);
                    Grid.SetColumn(_tiles[row, col], col);
                    GameGrid.Children.Add(_tiles[row, col]);
                }
            }
        }


    }
}
