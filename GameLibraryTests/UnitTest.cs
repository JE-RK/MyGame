using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GameLibrary;

namespace GameLibraryTests
{
    [TestClass]
    public class GameLibraryTests
    {
        private Game game;
        private Player player;
        private Computer computer;
        [TestInitialize]
        public void TestInitialize()
        {
            game = new Game();
            player = new Player("Name", game);
            computer = new Computer(game);
        }
        [TestMethod]
        public void PlayerNameIsNull()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                Player player = new Player(null, game);
            });
                
        }

        [ExpectedException(typeof(Exception), "Недопустимы пустые имена.")]
        [TestMethod]
        public void PlayerNameIsEmpty()
        {
            Player player = new Player("", game);
        }

        [TestMethod]
        public void PlayerSetStepTest()
        {
            int step = 1;
            player.SetStep(step);
            Assert.AreEqual(step, player.Step());
        }

        [ExpectedException(typeof(Exception), "У игроков одинаковые имена.")]
        [TestMethod]
        public void GameNameTest()
        {
            game.CreatePlayers("Name", "Name");
        }

        [ExpectedException(typeof(Exception), "Очередь другого игрока.")]
        [TestMethod]
        public void NextStepTest()
        {
            game.GameWithBot = false;
            game.CreatePlayers("Name1", "Name2");
            if (game.Chek == game.player1.Name)
            {
                game.NextStep(game.player2.Step());
            }
            else
            {
                game.NextStep(game.player1.Step());
            }
        }

        [ExpectedException(typeof(Exception), "Диапазон хода от 1 до 10")]
        [TestMethod]
        public void NextStepValues12()
        {
            game.GameWithBot = false;
            game.CreatePlayers("Name1", "Name2");
            do
            {
                game.CreatePlayers("Name1", "Name2");
            }
            while (game.Chek != game.player1.Name);
            game.player1.SetStep(12);
            game.NextStep(game.player1.Step());
        }

        [TestMethod]
        public void EndGameTest()
        {
            game.GameWithBot = false;
            game.CreatePlayers("Name1", "Name2");
            while (game.Score != 100)
            {
                if (game.Chek == game.player1.Name)
                {
                    game.player1.SetStep(10);
                    game.NextStep(game.player1.Step());
                }
                else
                {
                    game.player2.SetStep(10);
                    game.NextStep(game.player2.Step());
                } 
            }
            Assert.IsTrue(game.EndGame());
        }

        [TestMethod]
        public void ResetScoreTest()
        {
            game.ResetScore();
            Assert.AreEqual(0, game.Score);
        }


    }
}
