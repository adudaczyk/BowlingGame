using System;
using BowlingGameSDET;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private BowlingGame bowlingGame;

        [SetUp]
        public void Setup()
        {
            bowlingGame = new BowlingGame();
        }

        [Test]
        public void RollOver10FramesThrowsException()
        {
            for (int i = 0; i < 20; i++)
            {
                bowlingGame.Roll(4);
            }

            var ex = Assert.Throws<Exception>(() => bowlingGame.Roll(4));
            Assert.AreEqual("You cannot roll another ball. Bowling game has been completed!", ex.Message);
        }

        [Test]
        public void RollOver10PinsThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => bowlingGame.Roll(15));
            Assert.AreEqual("Pin count exceeds pins on the lane", ex.Message);
        }

        [Test]
        public void NegativeRollThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => bowlingGame.Roll(-3));
            Assert.AreEqual("Negative roll is invalid", ex.Message);
        }

        [Test]
        public void MaximumPoints()
        {
            for (int i = 0; i < 12; i++)
            {
                bowlingGame.Roll(10);
            }

            Assert.AreEqual(300, bowlingGame.Score());
        }

        [Test]
        public void MinimumPoints()
        {
            for (int i = 0; i < 10; i++)
            {
                bowlingGame.Roll(0);
            }

            Assert.AreEqual(0, bowlingGame.Score());
        }

        [Test]
        public void NormalGame()
        {
            bowlingGame.Roll(1);
            bowlingGame.Roll(4);
            bowlingGame.Roll(4);
            bowlingGame.Roll(5);
            bowlingGame.Roll(6);
            bowlingGame.Roll(4);
            bowlingGame.Roll(5);
            bowlingGame.Roll(5);
            bowlingGame.Roll(10);
            bowlingGame.Roll(0);
            bowlingGame.Roll(1);
            bowlingGame.Roll(7);
            bowlingGame.Roll(3);
            bowlingGame.Roll(6);
            bowlingGame.Roll(4);
            bowlingGame.Roll(10);
            bowlingGame.Roll(2);
            bowlingGame.Roll(8);
            bowlingGame.Roll(6);

            Assert.AreEqual(133, bowlingGame.Score());
        }
    }
}