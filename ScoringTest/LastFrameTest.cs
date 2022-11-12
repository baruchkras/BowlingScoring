using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scoring;
using System;

namespace ScoringTest
{
    [TestClass]
    public class LastFrameTest
    {
        [TestMethod]
        public void RollTheBall_BadRollArgument_LessThan0()
        {
            //Arrange
            int rollScore = -2;
            IFrame frame = new LastFrame();

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
            IFrame frame = new LastFrame();

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
            IFrame frame = new LastFrame();

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
        public void RollTheBall_SumMoreThan10AfterStrike()
        {
            //Arrange
            int rollScore1 = 10;
            int rollScore2 = 9;
            IFrame frame = new LastFrame();

            //Act
            try
            {
                frame.RollTheBall(rollScore1);
                frame.RollTheBall(rollScore2);
            }
            catch (ArgumentException ex)
            {
                //Assert
                Assert.Fail("Sum of 2 roll scores > 10 after strike is valid");
            }
        }

        [TestMethod]
        public void RollTheBall_NotCompletedAfterStrike()
        {
            //Arrange
            int rollScore = 10;
            IFrame frame = new LastFrame();

            //Act
            frame.RollTheBall(rollScore);
            
            //Assert
            Assert.IsFalse(frame.IsCompleted);
        }

        [TestMethod]
        public void RollTheBall_NotCompletedAfterStrikeAndRoll()
        {
            //Arrange
            int rollScore = 10;
            IFrame frame = new LastFrame();

            //Act
            frame.RollTheBall(rollScore);
            frame.RollTheBall(rollScore);

            //Assert
            Assert.IsFalse(frame.IsCompleted);
        }

        [TestMethod]
        public void RollTheBall_CompletedAfterStrikeAnd2Rolls()
        {
            //Arrange
            int rollScore = 10;
            IFrame frame = new LastFrame();

            //Act
            frame.RollTheBall(rollScore);
            frame.RollTheBall(rollScore);
            frame.RollTheBall(rollScore);

            //Assert
            Assert.IsTrue(frame.IsCompleted);
        }

        [TestMethod]
        public void RollTheBall_NotCompletedAfterSpare()
        {
            //Arrange
            int rollScore = 5;
            IFrame frame = new LastFrame();

            //Act
            frame.RollTheBall(rollScore);
            frame.RollTheBall(rollScore);

            //Assert
            Assert.IsFalse(frame.IsCompleted);
        }

        [TestMethod]
        public void RollTheBall_CompletedAfterSpareAndRoll()
        {
            //Arrange
            int rollScore = 5;
            IFrame frame = new LastFrame();

            //Act
            frame.RollTheBall(rollScore);
            frame.RollTheBall(rollScore);
            frame.RollTheBall(rollScore);

            //Assert
            Assert.IsTrue(frame.IsCompleted);
        }
    }
}
