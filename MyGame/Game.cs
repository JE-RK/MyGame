using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class Game
    {
        public Player player1;
        public Player player2;
        public string chek;
        public int score;
        public void CreatePlayer()
        {
            Console.WriteLine("Введите имя первого игрока");
            player1 = new Player(Console.ReadLine());
            Console.WriteLine("Введите имя второго игрока");
            player2 = new Player(Console.ReadLine());
        }
        public void AddScore()
        {
            string lineread = Console.ReadLine();
            switch (lineread)
            {
                case ("/exit"):
                    Environment.Exit(0);
                    break;
                default:
                    int s = Convert.ToInt32(lineread);
                    if (score < 91)
                    {
                        if (s >= 1 && s <= 10)
                        {
                            score += s;
                            Console.WriteLine($"Текущий счет: {score}");
                        }
                        else
                        {
                            Console.WriteLine("Диапазон шага от 1 до 10");
                            AddScore();
                        }
                    }
                    else
                    {
                        if (s >= 1 && s <= 100 - score)
                        {
                            score += s;
                            Console.WriteLine($"Текущий счет: {score}");
                        }
                        else
                        {
                            Console.WriteLine($"Диапазон шага от 1 до {100 - score}");
                            AddScore();
                        }
                    }
                    break;
            }

        }
        public void Roll()
        {
            Console.WriteLine("Определяем кто будет ходить первым...");
            while (player1.random_number == player2.random_number)
            {
                Random random = new Random();
                player1.random_number = random.Next(1, 100);
                player2.random_number = random.Next(1, 100);
                if (player1.random_number > player2.random_number)
                {
                    chek = player1.name;
                }
                else
                {
                    chek = player2.name;
                }
            }
            Console.WriteLine("Рандом определил рандомное число для первого игрока - " + player1.random_number);
            Console.WriteLine("Рандом определил рандомное число для второго игрока - " + player2.random_number);
        }
        public void Start()
        {
            CreatePlayer();
            Roll();
            Console.WriteLine($"Число у игрока {chek} больше! Он ходит первым");
            Console.WriteLine("Игра началась. Чтобы выйти введите /exit");
            while (true)
            {

                Console.Write($"Очередь игрока {chek}");
                Console.WriteLine();
                AddScore();
                if (score < 100)
                {
                    if (chek == player1.name)
                    {
                        chek = player2.name;
                    }
                    else
                    {
                        chek = player1.name;
                    }
                }
                else
                {
                    break;
                }

            }
            Console.WriteLine("Выиграл игрок " + chek);
        }
    }
}
