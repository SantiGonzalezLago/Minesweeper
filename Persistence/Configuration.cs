using Minesweeper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Persistence
{
    //TODO Por ahora utiliza valores por defecto, en el futuro deberá leer y escribir un archivo
    public class Configuration
    {
        public byte Difficulty { get; set; }
        public ushort WidthCustom { get; set; }
        public ushort HeightCustom { get; set; }
        public ushort MinesCustom { get; set; }
        public bool RelevantFirstClick { get; set; }

        public Configuration()
        {
            Difficulty = Data.Difficulty.Begginer;
            WidthCustom = 9;
            HeightCustom = 9;
            MinesCustom = 10;
            RelevantFirstClick = true;
        }
    }
}
