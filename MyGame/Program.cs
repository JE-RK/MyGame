using System;
using GameLibrary;
namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {   
            Game game = new Game();
            Console.WriteLine("Введите имя первого игрока");
            string p1_name = Console.ReadLine();
            Console.WriteLine("Введите имя второго игрока");
            string p2_name = Console.ReadLine();
            game.CreatePlayers(p1_name, p2_name);
            Console.WriteLine("Игроки созданы");
            Console.WriteLine("Первым ходит игрок " + game.Chek);
            while (game.EndGame())
            {
                string lineread = Console.ReadLine();
                
                if (lineread == "/exit")
                {
                    game.GameClosing();
                }
                else
                {
                    int num = int.Parse(lineread);
                    Console.WriteLine(game.NextStep(num));
                }
               
            }
        }
    }
}
