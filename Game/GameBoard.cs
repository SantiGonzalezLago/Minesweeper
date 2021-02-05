using Minesweeper.Data;
using Minesweeper.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Game
{
    public class GameBoard
    {
        public byte Difficulty { get; set; }
        private ushort _width;
        private ushort _height;
        private ushort _mines;

        private Tile[,] _tiles;

        public GameBoard()
        {
            Difficulty = App.Configuration.Difficulty;
            StartGame();
        }

        public void StartGame(byte difficulty)
        {
            Difficulty = difficulty;
            StartGame();
        }

        private void StartGame()
        {
            if (Difficulty != Data.Difficulty.Custom)
            {
                _width = Data.Difficulty.Width[Difficulty];
                _height = Data.Difficulty.Height[Difficulty];
                _mines = Data.Difficulty.Mines[Difficulty];
            }
            else
            {
                _width = App.Configuration.WidthCustom;
                _height = App.Configuration.HeightCustom;
                _mines = App.Configuration.MinesCustom;
            }
            CreateBoard();
            FillWithMines();
            App.GameWindow.FillGameGrid(_height, _width);
        }

        private void CreateBoard()
        {
            _tiles = new Tile[_height, _width];
            for (ushort row = 0; row < _height; row++)
            {
                for (ushort col = 0; col < _width; col++)
                {
                    _tiles[row, col] = new Tile(row, col);
                }
            }
        }

        private void FillWithMines()
        {
            for (int i = 0; i < _mines; i++)
            {
                Tile candidate;
                bool mineAdded = false;
                do
                {
                    candidate = GetRandomTile();
                    if (!candidate.Mine)
                    {
                        candidate.Mine = true;
                        mineAdded = true;
                    }
                } while (mineAdded);
            }
        }

        private Tile GetRandomTile()
        {
            Random rnd = new Random();
            int row = rnd.Next(0, _height);
            int col = rnd.Next(0, _width);
            return _tiles[row, col];
        }

        public Tile[] GetAdjacentTiles(ushort row, ushort col)
        {
            List<Tile> adjacentTiles = new List<Tile>();
            if (row > 0 && col > 0)
                adjacentTiles.Add(_tiles[row - 1, col - 1]);
            if (row > 0)
                adjacentTiles.Add(_tiles[row - 1, col]);
            if (row > 0 && col < _width - 1)
                adjacentTiles.Add(_tiles[row - 1, col + 1]);
            if (col < _width - 1)
                adjacentTiles.Add(_tiles[row, col + 1]);
            if (row < _height - 1 && col < _width - 1)
                adjacentTiles.Add(_tiles[row + 1, col + 1]);
            if (row < _height - 1)
                adjacentTiles.Add(_tiles[row + 1, col]);
            if (row < _height - 1 && col > 0)
                adjacentTiles.Add(_tiles[row + 1, col - 1]);
            if (col > 0)
                adjacentTiles.Add(_tiles[row, col - 1]);
            return adjacentTiles.ToArray();
        }

        public void Reveal(ushort row, ushort col)
        {
            _tiles[row, col].Reveal();
        }

        public void RevealAdjacent(ushort row, ushort col)
        {
            _tiles[row, col].RevealAdjacent();
        }

        public void ChangeFlag(ushort row, ushort col)
        {
            _tiles[row, col].ChangeFlag();
        }
    }
}
