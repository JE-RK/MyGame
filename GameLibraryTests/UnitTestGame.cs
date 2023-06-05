using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GameLibrary;

namespace GameLibraryTests
{
    [TestClass]
    public class UnitTestGame
    {
        private Game game;

        [TestInitialize]
        public void TestInitialize()
        {
            game = new Game();
            game.CreatePlayers(new Player("1", game), new Player("2", game));
        }

        [TestMethod]
        public void SetStep_StepMoreThan10_ExceptionThrown()
        {
            IPlayer player = game.WhoseMove();
            var exception = Assert.ThrowsException<Exception>(() => game.NextStep(12, player));
            Assert.AreEqual("Диапазон хода от 1 до 10", exception.Message);
        }

        [TestMethod]
        public void SetStep_StepLessThan1_ExceptionThrown()
        {
            IPlayer player = game.WhoseMove();
            var exception = Assert.ThrowsException<Exception>(() => game.NextStep(0, player));
            Assert.AreEqual("Диапазон хода от 1 до 10", exception.Message);
        }

        [TestMethod]
        public void SetStep_NotThatPlayer_ExceptionThrown()
        {
            IPlayer player = new Player("PRIVET", game);
            var exception = Assert.ThrowsException<Exception>(() => game.NextStep(0, player));
            Assert.AreEqual("Очередь игрока " + game.Chek, exception.Message);
        }

        [TestMethod]
        public void SetStep_StepFrom1To10_True()
        {
            IPlayer player = game.WhoseMove();
            int step = 7;
            game.NextStep(step, player);
            Assert.AreEqual(game.Score, step);
        }

        [TestMethod]
        public void CreatePlayers_SamePlayerNames_ExceptionThrown()
        {
            var exception = Assert.ThrowsException<Exception>(() => game.CreatePlayers(new Player("1", game), new Player("1", game)));
            Assert.AreEqual("У игроков одинаковые имена.", exception.Message);
        }

        [TestMethod]
        public void ResetScore_True()
        {
            IPlayer player = game.WhoseMove();
            game.NextStep(5, player);
            game.ResetScore();
            Assert.IsTrue(game.Score == 0);
        }

        [TestMethod]
        public void EndGame_True()
        {
            while (game.Score != 100)
            {
                game.NextStep(10, game.WhoseMove());
            }
            Assert.IsTrue(game.EndGame());
        }

        [TestMethod]
        public void EndGame_False()
        {
            Assert.IsFalse(game.EndGame());
        }
    }
}
