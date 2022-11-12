using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scoring;
using System;
using System.Linq;

namespace ScoringTest
{
    [TestClass]
    public class GameTest
    {
        private int[] testRolls = { 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6 };
        private int testRollsTotalScore = 133;

        [TestMethod]
        public void NewGameEmpty()
        { 
            //Arrange
            Game game = new Game();

            //Act

            //Assert
            Assert.IsFalse(game.IsCompleted);
            Assert.AreEqual(0, game.Frames.Count()); 
        }

        [TestMethod]
        public void GameCompleted()
        {
            //Arrange
            Game game = new Game();

            //Act
            for (int i = 0; i < testRolls.Length; i++)
            {
                game.RollTheBall(testRolls[i]);
            }

            //Assert
            Assert.IsTrue(game.IsCompleted);
            Assert.AreEqual(10, game.Frames.Count());
            Assert.AreEqual(testRollsTotalScore, game.Frames.Sum(f => f.Score));
        }

        [TestMethod]
        public void RollTheBall_1stTime()
        {
            //Arrange
            Game game = new Game();

            //Act
            game.RollTheBall(testRolls[0]);

            //Assert
            Assert.IsFalse(game.IsCompleted);
            Assert.AreEqual(1, game.Frames.Count());            
        }

        [TestMethod]
        public void RollTheBall_2ndTime()
        {
            //Arrange
            Game game = new Game();

            //Act
            for (int i = 0; i < 2; i++)
            {
                game.RollTheBall(testRolls[i]);
            }

            //Assert
            Assert.IsFalse(game.IsCompleted);
            Assert.AreEqual(1, game.Frames.Count());
        }

        [TestMethod]
        public void RollTheBall_3rdTime()
        {
            //Arrange
            Game game = new Game();

            //Act
            for (int i = 0; i < 3; i++)
            {
                game.RollTheBall(testRolls[i]);
            }

            //Assert
            Assert.IsFalse(game.IsCompleted);
            Assert.AreEqual(2, game.Frames.Count());
        }

        [TestMethod]
        public void RollTheBall_Add1stBonusAfterStrike()
        {
            //Arrange
            Game game = new Game();
            int strikeScore = 10;
            int bonusRoll = 4;

            //Act
            game.RollTheBall(strikeScore);
            game.RollTheBall(bonusRoll);

            //Assert
            Assert.AreEqual(strikeScore + bonusRoll, game.Frames.First().Score);
        }

        [TestMethod]
        public void RollTheBall_Add2ndBonusAfterStrike()
        {
            //Arrange
            Game game = new Game();
            int strikeScore = 10;
            int bonusRoll1 = 4;
            int bonusRoll2 = 3;

            //Act
            game.RollTheBall(strikeScore);
            game.RollTheBall(bonusRoll1);
            game.RollTheBall(bonusRoll2);

            //Assert
            Assert.AreEqual(strikeScore + bonusRoll1 + bonusRoll2, game.Frames.First().Score);
        }

        [TestMethod]
        public void RollTheBall_AddBonusAfterSpare()
        {
            //Arrange
            Game game = new Game();
            int spareRoll1 = 6;
            int spareRoll2 = 4;
            int bonusRoll = 3;

            //Act
            game.RollTheBall(spareRoll1);
            game.RollTheBall(spareRoll2);
            game.RollTheBall(bonusRoll);

            //Assert
            Assert.AreEqual(spareRoll1 + spareRoll2 + bonusRoll, game.Frames.First().Score);
        }

    }
}
