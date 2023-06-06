using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GameLibrary;
using Moq;

namespace GameLibraryTests
{
    [TestClass]
    public class UnitTestGame
    {
        Game game;
        Mock <IPlayer> player1;
        Mock<IPlayer> player2;
        [TestInitialize]
        public void TestInitialize()
        {
            game = new Game();
            player1 = new Mock<IPlayer>();
            player2 = new Mock<IPlayer>();
            player1.Setup(m => m.Name).Returns("Name1");
            player2.Setup(m => m.Name).Returns("Name2");
            game.CreatePlayers(player1.Object, player2.Object);
        }

        [TestMethod]
        public void TestMethod()
        {
            player1.Setup(m => m.Name).Returns("Name");
            var exception = Assert.ThrowsException<Exception>(() => game.CreatePlayers(player1.Object, player1.Object));
            Assert.AreEqual("У игроков одинаковые имена.", exception.Message);
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
            IPlayer player = game.WhoseMove();
            if (player.Name == player1.Object.Name)
                player = player2.Object;
            else
                player = player1.Object;        
            var exception = Assert.ThrowsException<Exception>(() => game.NextStep(6, player));
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
