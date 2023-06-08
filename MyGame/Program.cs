using System;
using System.Resources;
using System.ComponentModel;
using GameLibrary;
using GameLibrary.GameException;
using System.Globalization;
using System.Reflection;

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
                Console.WriteLine("Выиграл - " + game.LastPlayerName);
            }
        }
        static void Main(string[] args)
        {
            ResourceManager rm = new ResourceManager("GameLibrary.GameException.ResourceFile",
                               typeof(ExceptionCode).Assembly);
            Game game = new Game();
            while (true)
            {
                if (!game.EndGame())
                {
                    while (game.StepNowPlayerName == null)
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
                        catch (GameException ex)
                        {
                            Console.WriteLine(rm.GetString(ex.Code));
                            Console.WriteLine("Попробуйте еще раз");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Необработанное исключение: " + ex.Message);
                        }
                    }
                    Console.WriteLine("Игра началась, чтобы выйти - \"/exit\"");
                    
                    while (!game.EndGame())
                    {
                        try
                        {
                            Console.WriteLine("Ходит игрок " + game.StepNowPlayerName);
                            if (game.StepNowPlayerName == game.player1.Name)
                            {
                                game.player1.Step();
                            }
                            else
                            {
                                game.player2.Step();
                            }
                            GameDisplay(game);
                        }
                        catch (GameException ex)
                        {
                            Console.WriteLine(rm.GetString(ex.Code));
                            if (ex is InvalidPlayerStepException)
                            {
                                if (game.Score >= 91)
                                {
                                    Console.WriteLine("Диапазон шага от 1 до " + (100 - game.Score).ToString());
                                }
                                else
                                {
                                    Console.WriteLine("Диапазон шага от 1 до 10");
                                }
                            }
                            Console.WriteLine("Попробуйте еще раз");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Необработанное исключение: " + ex.Message);
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
