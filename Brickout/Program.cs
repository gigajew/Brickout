using System;

namespace Brickout
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        public static Game1 MyGame;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MyGame = new Game1();
            MyGame.Run();
            MyGame.Dispose();
        }
    }
}
