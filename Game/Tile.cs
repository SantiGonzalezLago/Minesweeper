using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Game
{
    public class Tile
    {
        public const byte StatusRevealed = 0;
        public const byte StatusNoFlag = 1;
        public const byte StatusFlag = 2;
        public const byte StatusQuestionMark = 3;

        public ushort RowCoordinate { get; set; }
        public ushort ColumnCoordinate { get; set; }
        public bool Mine { get; set; }
        public byte Status { get; private set; }

        private Tile[] _adjacentTiles;
        private Tile[] AdjacentTiles
        {
            get
            {
                if (_adjacentTiles == null)
                {
                    _adjacentTiles = App.GameBoard.GetAdjacentTiles(RowCoordinate, ColumnCoordinate);
                }
                return _adjacentTiles;
            }
        }

        private sbyte _adjacentMines = -1;
        public byte AdjacentMines
        {
            get
            {
                if (_adjacentMines < 0)
                {
                    _adjacentMines = 0;
                    foreach (Tile tile in AdjacentTiles)
                    {
                        if (tile.Mine) _adjacentMines++;
                    }
                }
                return (byte) _adjacentMines;
            }
        }


        public Tile(ushort rowCoordinate, ushort columnCoordinate)
        {
            RowCoordinate = rowCoordinate;
            ColumnCoordinate = columnCoordinate;
        }

        public void Reveal()
        {

        }

        public void RevealAdjacent()
        {
            foreach (Tile tile in AdjacentTiles)
            {
                tile.Reveal();
            }
        }

        public byte ChangeFlag()
        {
            switch (Status)
            {
                case StatusNoFlag:
                    Status = StatusFlag;
                    break;
                case StatusFlag:
                    Status = StatusQuestionMark;
                    break;
                case StatusQuestionMark:
                    Status = StatusNoFlag;
                    break;
            }
            return Status;
        }
    }
}
