using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GameLibrary;
using Moq;

namespace GameLibraryTests
{
    [TestClass]
    public class UnitTestComputer
    {
        Mock<IGame> game;
        Computer computer;
        [TestInitialize]
        public void TestInitialize()
        {
            game = new Mock<IGame>();
            computer = new Computer(game.Object);
        }

        [TestMethod]
        public void Step_Score0_Return1()
        {
            game.Setup(m => m.Score).Returns(0);
            computer.Step();
            game.Verify(lw => lw.NextStep(1, computer));
        }

        [TestMethod]
        public void Step_Score10_Return2()
        {
            game.Setup(m => m.Score).Returns(10);
            computer.Step();
            game.Verify(lw => lw.NextStep(2, computer));
        }

        [TestMethod]
        public void Step_Score15_Return8()
        {
            game.Setup(m => m.Score).Returns(15);
            computer.Step();
            game.Verify(lw => lw.NextStep(8, computer));
        }

        [TestMethod]
        public void Step_Score27_Returns7()
        {
            game.Setup(m => m.Score).Returns(27);
            computer.Step();
            game.Verify(lw => lw.NextStep(7, computer));
        }

        [TestMethod]
        public void Step_Score39_Returns6()
        {
            game.Setup(m => m.Score).Returns(39);
            computer.Step();
            game.Verify(lw => lw.NextStep(6, computer));
        }

        [TestMethod]
        public void Step_Score54_Returns2()
        {
            game.Setup(m => m.Score).Returns(54);
            computer.Step();
            game.Verify(lw => lw.NextStep(2, computer));
        }

        [TestMethod]
        public void Step_Score62_Returns5()
        {
            game.Setup(m => m.Score).Returns(62);
            computer.Step();
            game.Verify(lw => lw.NextStep(5, computer));
        }

        [TestMethod]
        public void Step_Score75_Return3()
        {
            game.Setup(m => m.Score).Returns(75);
            computer.Step();
            game.Verify(lw => lw.NextStep(3, computer));
        }

        [TestMethod]
        public void Step_Score87_Returns2()
        {
            game.Setup(m => m.Score).Returns(87);
            computer.Step();
            game.Verify(lw => lw.NextStep(2, computer));
        }

        [TestMethod]
        public void Step_Score95_Returns5()
        {
            game.Setup(m => m.Score).Returns(95);
            computer.Step();
            game.Verify(lw => lw.NextStep(5, computer));
        }
    }
}
