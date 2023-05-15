using System;
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
            Console.WriteLine($"Ходит игрок {game.chek}");
            while (game.score != 100)
            {
                string num = Console.ReadLine();
                Console.WriteLine(game.Start(num));
            }
        }
    }
}
