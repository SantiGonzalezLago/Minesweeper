using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Data
{
    public abstract class Difficulty
    {
        public const byte Begginer = 0;
        public const byte Intermediate = 1;
        public const byte Expert = 2;
        public const byte Custom = 3;

        //Position 0 is for Begginer, 1 for Intermediate, 2 for Expert
        public static readonly ushort[] Mines = { 10, 40, 99 };
        public static readonly ushort[] Height = { 9, 16, 16 };
        public static readonly ushort[] Width = { 9, 16, 30 };
    }
}
