using System;
using GameLibrary;
namespace MyGame
{
    class Program
    {
        static void GameDisplay(Game game)
        {

            if (!game.EndGame())
            {
                Console.WriteLine($"Счет: {game.Score}\n");
            }
            else
            {
                Console.WriteLine($"Счет:  {game.Score}\n");
                Console.WriteLine("Выиграл - " + game.Last);
            }
        }
        static void Main(string[] args)
        {   
            Game game = new Game();
            while (true)
            {
                if (!game.EndGame())
                {
                    while (game.Chek == null)
                    {
                        try
                        {
                            Console.WriteLine("Enter, чтобы играть с игроком\nКоманда /bot, чтобы играть с компьютером\n ");
                            string lineread = Console.ReadLine();
                            if (lineread == "/bot")
                            {
                                Console.WriteLine("Введите имя первого игрока");
                                string p1_name = Console.ReadLine();
                                game.CreatePlayers(new ConsolePlayer(p1_name, game));
                            }
                            else
                            {
                                Console.WriteLine("Введите имя первого игрока");
                                string p1_name = Console.ReadLine();
                                Console.WriteLine("Введите имя второго игрока");
                                string p2_name = Console.ReadLine();
                                game.CreatePlayers(new ConsolePlayer(p1_name, game), new ConsolePlayer(p2_name, game));
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Попробуйте еще раз");
                        }
                    }
                    Console.WriteLine("Игра началась, чтобы выйти - \"/exit\"");
                    
                    while (!game.EndGame())
                    {
                        try
                        {
                            Console.WriteLine("Ходит игрок " + game.Chek);
                            if (game.Chek == game.player1.Name)
                            {
                                game.player1.Step();
                            }
                            else
                            {
                                game.player2.Step();
                            }
                            GameDisplay(game);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Попробуйте еще раз");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("0 - стоп, 1 - дальше");
                    string lineread = Console.ReadLine();
                    if (int.Parse(lineread) == 1)
                    {
                        game.ResetScore();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}
