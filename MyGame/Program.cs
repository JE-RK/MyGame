using System;
using GameLibrary;
namespace MyGame
{
    class Program
    {
        static void GameDisplay(Game game)
        {

            if (game.EndGame() == false)
            {
                Console.WriteLine($"Счет: {game.Score}\n");
            }
            else
            {
                Console.WriteLine($"Счет:  {game.Score}\n");
                Console.WriteLine("Выиграл - " + game.Last);
            }
        }
        static void Ending(string lineread)
        {
            if (lineread == "/exit")
            {
                Environment.Exit(0);
            }
        }
        static void Main(string[] args)
        {   
            Game game = new Game();
            while (true)
            {
                if (game.EndGame() == false)
                {
                    while (game.Chek == null)
                    {
                        try
                        {
                            Console.WriteLine("Enter, чтобы играть с игроком\nКоманда /bot, чтобы играть с компьютером\n ");
                            string lineread = Console.ReadLine();
                            if (lineread == "/bot")
                            {
                                game.GameWithBot = true;
                                Console.WriteLine("Введите имя первого игрока");
                                string p1_name = Console.ReadLine();
                                game.CreatePlayers(p1_name, "BOT");
                            }
                            else
                            {
                                game.GameWithBot = false;
                                Console.WriteLine("Введите имя первого игрока");
                                string p1_name = Console.ReadLine();
                                Console.WriteLine("Введите имя второго игрока");
                                string p2_name = Console.ReadLine();
                                game.CreatePlayers(p1_name, p2_name);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Попробуйте еще раз");
                        }
                    }
                    Console.WriteLine("Игроки созданы");
                    
                    while (game.EndGame() == false)
                    {
                        try
                        {
                            Console.WriteLine("Ходит игрок " + game.Chek);
                            if (game.Chek == game.player1.Name)
                            {
                                string lineread = Console.ReadLine();
                                Ending(lineread);
                                int num = int.Parse(lineread);
                                game.player1.SetStep(num);
                                game.NextStep(game.player1.Step());
                            }
                            else
                            {
                                string lineread;
                                if (game.player2 is Computer computer)
                                {
                                    computer.Think();
                                    lineread = game.player2.Step().ToString();
                                    Console.WriteLine(lineread);
                                }
                                else
                                {
                                    lineread = Console.ReadLine();
                                }
                                Ending(lineread);
                                int num = int.Parse(lineread);
                                game.player2.SetStep(num);
                                game.NextStep(game.player2.Step());
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
