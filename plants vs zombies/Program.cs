using System;

namespace Plants_vs_Zombies
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Plants_vs_Zombies())
                game.Run();
        }
    }
#endif
}