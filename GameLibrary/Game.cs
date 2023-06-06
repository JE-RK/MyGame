using System;

namespace GameLibrary
{
    public class Game : IGame
    {
        public IPlayer player1;
        public IPlayer player2;
        private string _stepNowPlayerName;
        private int _score = 0;
        public int Score { get { return _score; } }
        public string StepNowPlayerName { get { return _stepNowPlayerName; } }
        private string _lastPlayerName;
        public string LastPlayerName { get { return _lastPlayerName; } }
        public void CreatePlayers(IPlayer p1, IPlayer p2)
        {
            player1 = p1;
            player2 = p2;
            if (player1.Name == player2.Name)
            {
                throw new Exception("У игроков одинаковые имена.");
            }
            FirstMove();
        }
        public void CreatePlayers(IPlayer p1)
        {
            player1 = p1;
            player2 = new Computer(this);
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
                _stepNowPlayerName = player1.Name;
            }
            else
            {
                _stepNowPlayerName = player2.Name;
            }
        }

        public IPlayer WhoseMove()
        {
            if (_stepNowPlayerName == player1.Name)
            {
                return player1;
            }
            else
            {
                return player2;
            }
        }

        public void ResetScore()
        {
            _score = 0;
            _stepNowPlayerName = null;
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

        public void NextStep(int number, IPlayer player)
        { 
            if (_stepNowPlayerName == player.Name) 
            {
                _lastPlayerName = player.Name;
                string res = "";
                if (IsValid(number))
                {
                    _score += number;
                    if (_stepNowPlayerName == player1.Name)
                    {
                        _stepNowPlayerName = player2.Name;
                    }
                    else
                    {
                        _stepNowPlayerName = player1.Name;
                    }
                }
                else
                {
                    if (_score >= 91)
                    {
                        res += $"Диапазон хода от 1 до {100 - _score}";
                        throw new Exception(res);
                    }
                    else
                    {
                        res += "Диапазон хода от 1 до 10";
                        throw new Exception(res);
                    }
                }
            }
            else
            {
                throw new Exception("Очередь игрока " + StepNowPlayerName);            
            }
        }
    }
}
