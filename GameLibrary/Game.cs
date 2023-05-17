using System;

namespace GameLibrary
{
    public class Game
    {
        private Player player1;
        private Player player2;
        private string chek;
        private int score;
        public string Chek
        {
            get { return chek; }
        }
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
                FirstMove();
            }

        }

        public void GameClosing()
        {
            Environment.Exit(0);
        }
        private bool IsValid(int number)
        {
            bool res;
            if (number >= 1 && number <= 10)
            {
                res = true;
            }       
            else
            {
                res = false;
            }
            if (number > 100 - score)
            {
                res = false;
            }
            return res;
        }
        private void FirstMove()
        {
            Random random = new Random();
            int firstmove = random.Next(0, 2);
            if (firstmove == 0)
            {
                chek = player1.name;
            }
            else
            {
                chek = player2.name;
            }
        }
        public bool EndGame()
        {
            bool b = false;
            if (score != 100)
            {
                b = true;
                
            }
            return b;
        }
        public string NextStep(int number)
        {           
            string res = "";
            bool b = IsValid(number);
            if (b)
            {
                score += number;
                if (EndGame())
                {
                    
                    if (chek == player1.name)
                    {
                        chek = player2.name;
                    }
                    else
                    {
                        chek = player1.name;
                    }
                    res += $"Счет: {score}\n";
                    res += $"Ход игрока - {chek}";
                }
                else
                {
                    res += $"Счет:  {score}\n";
                    res += "Выиграл - " + chek;
                }
            }
            else
            {
                if (score >= 91)
                {
                    res += $"Диапазон хода от 1 до {100 - score}\n";
                    res += $"Ход игрока - {chek}";
                }
                else
                {
                    res += "Диапазон хода от 1 до 10\n";
                    res += $"Ход игрока - {chek}";
                }
                
            }
            return res;
        }
    }
}
