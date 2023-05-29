using System;

namespace GameLibrary
{
    public class Game
    {
        public Player player1;
        public IPlayer player2;
        private string _chek;
        private int _score = 0;
        public int Score { get { return _score; } }
        public string Last { get; set; }
        public string Chek { get { return _chek; } }
        public bool GameWithBot { get; set; }
        
        public void CreatePlayers(string p1_name, string p2_name)
        {
            player1 = new Player(p1_name, this);
            if (GameWithBot)
            {
                player2 = new Computer(this);
            }
            else
            {
                player2 = new Player(p2_name, this);
            } 
            if (player1.Name == player2.Name)
            {
                throw new Exception("У игроков одинаковые имена.");
            }
            FirstMove();
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
            if (number > 100 - _score)
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
                _chek = player1.Name;
            }
            else
            {
                _chek = player2.Name;
            }
        }
        public void ResetScore()
        {
            _score = 0;
            _chek = null;
        }
        public bool EndGame()
        {
            bool b = false;
            if (_score == 100)
            {
                b = true;
            }
            return b;
        }
        public void NextStep(int number)
        { 
            if (_chek == Last) 
            {
                string res = "";
                bool b = IsValid(number);
                if (b)
                {
                    _score += number;
                    if (_chek == player1.Name)
                    {
                        _chek = player2.Name;
                    }
                    else
                    {
                        _chek = player1.Name;
                    }
                }
                else
                {
                    if (_score >= 91)
                    {
                        res += $"Диапазон хода от 1 до {100 - _score}\n";
                        throw new Exception(res);
                    }
                    else
                    {
                        res += "Диапазон хода от 1 до 10\n";
                        throw new Exception(res);
                    }
                }
            }
            else
            {
                throw new Exception("Очередь другого игрока.");            
            }
        }
    }
}
