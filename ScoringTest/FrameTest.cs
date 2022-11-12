using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scoring;
using System;

namespace ScoringTest
{
    [TestClass]
    public class FrameTest
    {
        [TestMethod]
        public void RollTheBall_Valid1stRoll()
        {
            //Arrange
            int rollScore = 5;
            IFrame frame = new Frame();

            //Act
            frame.RollTheBall(rollScore);

            //Assert
            Assert.AreEqual(rollScore, frame.Score);
            Assert.AreEqual(1, frame.RollsCount);
        }

        [TestMethod]
        public void RollTheBall_Zero1stRoll()
        {
            //Arrange
            int rollScore = 0;
            IFrame frame = new Frame();

            //Act
            frame.RollTheBall(rollScore);

            //Assert
            Assert.AreEqual(rollScore, frame.Score);
            Assert.AreEqual(1, frame.RollsCount);
        }

        [TestMethod]
        public void RollTheBall_Valid2Rolls()
        {
            //Arrange
            int rollScore1 = 4;
            int rollScore2 = 3;
            IFrame frame = new Frame();

            //Act
            frame.RollTheBall(rollScore1);
            frame.RollTheBall(rollScore2);

            //Assert
            Assert.AreEqual(rollScore1 + rollScore2, frame.Score);
            Assert.IsTrue(frame.IsCompleted);
            Assert.AreEqual(2, frame.RollsCount);
        }

        [TestMethod]
        public void RollTheBall_Zero2ndRoll()
        {
            //Arrange
            int rollScore1 = 7;
            int rollScore2 = 0; 
            IFrame frame = new Frame();

            //Act
            frame.RollTheBall(rollScore1);
            frame.RollTheBall(rollScore2);

            //Assert
            Assert.AreEqual(rollScore1, frame.Score);
            Assert.IsTrue(frame.IsCompleted);
            Assert.AreEqual(2, frame.RollsCount);
        }

        [TestMethod]
        public void RollTheBall_BadRollArgument_LessThan0()
        {
            //Arrange
            int rollScore = -2;
            IFrame frame = new Frame();

            //Act
            try
            {
                frame.RollTheBall(rollScore);
            }
            catch (ArgumentException ex)
            {
                //Assert
                StringAssert.Contains(ex.Message, ErrorMessages.RollScoreIsLessThan0);
            }
        }

        [TestMethod]
        public void RollTheBall_BadRollArgument_MoreThan10()
        {
            //Arrange
            int rollScore = 11;
            IFrame frame = new Frame();

            //Act
            try
            {
                frame.RollTheBall(rollScore);
            }
            catch (ArgumentException ex)
            {
                //Assert
                StringAssert.Contains(ex.Message, ErrorMessages.RollScoreIsMoreThan10);
            }
        }

        [TestMethod]
        public void RollTheBall_BadRollArgument_SumMoreThan10()
        {
            //Arrange
            int rollScore1 = 2;
            int rollScore2 = 9;
            IFrame frame = new Frame();

            //Act
            try
            {
                frame.RollTheBall(rollScore1);
                frame.RollTheBall(rollScore2);
            }
            catch (ArgumentException ex)
            {
                //Assert
                StringAssert.Contains(ex.Message, ErrorMessages.SumOfRollScoresIsMoreThan10);
            }
        }

        [TestMethod]
        public void RollTheBall_Strike()
        {
            //Arrange
            int rollScore = 10;
            IFrame frame = new Frame();

            //Act
            frame.RollTheBall(rollScore);

            //Assert
            Assert.IsTrue(frame.IsStrike);
            Assert.IsFalse(frame.IsSpare);
            Assert.IsTrue(frame.IsCompleted);
            Assert.AreEqual(1, frame.RollsCount);
        }

        [TestMethod]
        public void RollTheBall_Spare()
        {
            //Arrange
            int rollScore1 = 4;
            int rollScore2 = 6;
            IFrame frame = new Frame();

            //Act
            frame.RollTheBall(rollScore1);
            frame.RollTheBall(rollScore2);

            //Assert
            Assert.IsTrue(frame.IsSpare);
            Assert.IsFalse(frame.IsStrike);
            Assert.IsTrue(frame.IsCompleted);
            Assert.AreEqual(2, frame.RollsCount);
        }

        [TestMethod]
        public void RollTheBall_ValidBonus()
        {
            //Arrange
            int rollScore1 = 4;
            int rollScore2 = 6;
            int bonus = 7;
            IFrame frame = new Frame();

            //Act
            frame.RollTheBall(rollScore1);
            frame.RollTheBall(rollScore2);
            frame.AddBonus(bonus);

            //Assert
            Assert.AreEqual(rollScore1 + rollScore2 + bonus, frame.Score);
            Assert.AreEqual(2, frame.RollsCount);
        }
    }
}
