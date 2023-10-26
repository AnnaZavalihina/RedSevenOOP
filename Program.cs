using System.Text.RegularExpressions;
namespace RedSevenOOP
{
    internal class Program 
    {
        public static readonly GameService gService = new GameService();
        public static void Main() 
        {
            gService.ConsoleOptions();
            while (true)
            {
                gService.PlayGame();
            }
        }
    }
}