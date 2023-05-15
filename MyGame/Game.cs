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
        public void CreatePlayers(string p1_name, string p2_name)
        {
            if (p1_name == "" || p2_name == "")
            {
                throw new Exception();
            }
            else
            {   
                player1 = new Player(p1_name);
                player2 = new Player(p2_name);
            }
            
        }
        public string AddScore(string lineread)
        {
            int number;
            string res = "";
            if (int.TryParse(lineread, out number))
            {
                if (score < 91)
                {
                    if (number >= 1 && number <= 10)
                    {
                        score += number;
                        res = $"Текущий счет: {score}\n";
                    }
                    else
                    {
                        res = ("Диапазон шага от 1 до 10\n");
                    }
                }
                else
                {
                    if (number >= 1 && number <= 100 - score)
                    {
                        score += number;
                        res = ($"Текущий счет: {score}\n");
                    }
                    else
                    {
                        res = ($"Диапазон шага от 1 до {100 - score}\n");
                    }
                }
            }
            else if (lineread == "/exit")
            {
                Environment.Exit(0);
            }
            else
            {
                throw new Exception();
            }
            return res;
        }
        public string FirstMove()
        {
            Random random = new Random();
            while (player1.random_number == player2.random_number)
            {
                
                player1.random_number = random.Next(0, 2);
                player2.random_number = random.Next(0, 2);
                if (player1.random_number > player2.random_number)
                {
                    chek = player1.name;
                }
                else
                {
                    chek = player2.name;
                }
            }
            return chek;
        }
        public string Start(string s)
        {
            string res;
            res =  AddScore(s);
            if (score < 100)
            {

                if (!res.Contains("Диапазон") && chek == player1.name)
                {
                    chek = player2.name;
                    res += "Ход игрока " + chek;
                }
                else if (!res.Contains("Диапазон") && chek == player2.name)
                {
                    chek = player1.name;
                    res += "Ход игрока " + chek;
                }
                else
                {
                    res += "Ход игрока " + chek;
                }
            }
            else
            {
                res += ("Выиграл игрок " + chek);
                 
            }
            return res;
        }
    }
}
