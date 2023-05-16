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
            game.FirstMove();
            if (game.player1.chek)
            {
                Console.WriteLine($"Ходит игрок {game.player1.name}");
            }
            else
            {
                Console.WriteLine($"Ходит игрок {game.player2.name}");
            }
            while (game.score != 100)
            {
                string num = Console.ReadLine();
                Console.WriteLine(game.Start(num));
            }
        }
    }
}
