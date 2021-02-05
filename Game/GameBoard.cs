using Minesweeper.Data;
using Minesweeper.Persistence;
using System;
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
            App.GameWindow.FillGameGrid(_height, _width);
        }

        public Tile[] GetAdjacentTiles(ushort rowCoordinate, ushort columnCoordinate)
        {
            //TODO
            return null;
        }

    }
}
