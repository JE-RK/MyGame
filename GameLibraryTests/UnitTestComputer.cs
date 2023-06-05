using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GameLibrary;

namespace GameLibraryTests
{
    [TestClass]
    public class UnitTestComputer
    {
        private Game game;
        Computer computer;
        [TestInitialize]
        public void TestInitialize()
        {
            game = new Game();
            while (true)
            {
                game.CreatePlayers(new Player("Player", game));
                if (game.Chek == game.player2.Name)
                {
                    break;
                }
            }
            computer = new Computer(game);
        }

        [TestMethod]
        public void Step_Score0_Return1()
        {
            computer.Step();
            int expected = 1;
            int actual = game.Score;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Step_Score10_To12()
        {
            game.SetScore(10);
            computer.Step();
            int expected = 12;
            int actual = game.Score;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Step_Score15_To23()
        {
            game.SetScore(15);
            computer.Step();
            int expected = 23;
            int actual = game.Score;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Step_Score27_To34()
        {
            game.SetScore(27);
            computer.Step();
            int expected = 34;
            int actual = game.Score;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Step_Score39_To45()
        {
            game.SetScore(39);
            computer.Step();
            int expected = 45;
            int actual = game.Score;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Step_Score54_To56()
        {
            game.SetScore(54);
            computer.Step();
            int expected = 56;
            int actual = game.Score;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Step_Score62_To67()
        {
            game.SetScore(62);
            computer.Step();
            int expected = 67;
            int actual = game.Score;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Step_Score75_To78()
        {
            game.SetScore(75);
            computer.Step();
            int expected = 78;
            int actual = game.Score;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Step_Score87_To89()
        {
            game.SetScore(87);
            computer.Step();
            int expected = 89;
            int actual = game.Score;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Step_Score95_To100()
        {
            game.SetScore(95);
            computer.Step();
            int expected = 100;
            int actual = game.Score;
            Assert.AreEqual(expected, actual);
        }
    }
}
