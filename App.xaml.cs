using Minesweeper.Game;
using Minesweeper.Persistence;
using Minesweeper.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static GameWindow GameWindow { get; private set; }
        public static GameBoard GameBoard { get; private set; }
        public static Configuration Configuration { get; private set; }

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            Configuration = new Configuration();
            GameWindow = new GameWindow();
            GameBoard = new GameBoard();
            GameWindow.Show();
        }
    }
}
