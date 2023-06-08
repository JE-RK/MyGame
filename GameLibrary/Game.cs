using System;
using GameLibrary.GameException;
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
                throw new GameException.InvalidUserNameException();
            }
            FirstMove();
        }
        public void CreatePlayers(IPlayer p1)
        {
            player1 = p1;
            player2 = new Computer(this);
            FirstMove();
        }
        private void IsValid(int number)
        {
            if (number < 1 || number > 10)
            {
                throw new InvalidPlayerStepException();
            }
            if (number > 100 - _score)
            {
                throw new InvalidPlayerStepException();
            }
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
                IsValid(number);
                _score += number;
                _stepNowPlayerName = _stepNowPlayerName == player1.Name ? player2.Name : player1.Name;
            }
            else
            {
                throw new OutOfOrderInputException();            
            }
        }
    }
}
