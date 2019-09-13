using System;
using System.Collections;
using System.Collections.Generic;

namespace BowlingGameSDET
{
    public class BowlingGame
    {
        private readonly IList<Frame> _frames;
        private readonly IList _throws;
        private int _frameNumber = 1;
        private int _firstThrow;
        private int _lastRoundBonusThrowRemaining;
        private bool _isLastBallInFrame = false;
        private bool _firstThrowInFrame = true;

        public BowlingGame()
        {
            _frames = new List<Frame>();
            _throws = new List<int>();
        }

        public void Roll(int pins)
        {
            var endRoll = false;

            VerifyPins(pins);
            VerifyFrameNumber();

            if (_frameNumber == 10 && _lastRoundBonusThrowRemaining > 0)
            {
                BonusRoll(pins);
            }

            if (!_isLastBallInFrame && !_firstThrowInFrame && _lastRoundBonusThrowRemaining == 0)
            {
                SecondRoll(pins);
                endRoll = true;
            }

            if (_firstThrowInFrame && _lastRoundBonusThrowRemaining == 0 && !endRoll)
            {
                FirstRoll(pins);
            }
        }

        public int Score()
        {
            int totalScore = 0;

            foreach (var frame in _frames)
            {
                totalScore += frame.Score();
            }

            return totalScore;
        }

        private void OpenFrame(int firstThrow, int secondThrow)
        {
            _frames.Add(new OpenFrame(_throws, firstThrow, secondThrow));
        }

        private void SpareFrame(int firstThrow, int secondThrow)
        {
            _frames.Add(new SpareFrame(_throws, firstThrow, secondThrow));
        }

        private void StrikeFrame()
        {
            _frames.Add(new StrikeFrame(_throws));
        }

        private void BonusFrame(int firstThrow)
        {
            _frames.Add(new BonusFrame(_throws, firstThrow));
        }

        private static void VerifyPins(int pins)
        {
            if (pins < 0)
            {
                throw new ArgumentException("Negative roll is invalid");
            }
            if (pins > 10)
            {
                throw new ArgumentException("Pin count exceeds pins on the lane");
            }
        }

        private void VerifyFrameNumber()
        {
            if (_frameNumber > 10)
            {
                throw new Exception("You cannot roll another ball. Bowling game has been completed!");
            }
        }

        private void AddBonusThrowIfLastFrame(int bonusThrows)
        {
            if (_frameNumber == 10)
            {
                _lastRoundBonusThrowRemaining = bonusThrows;
            }
            else
            {
                _frameNumber++;
            }
        }

        private void FirstRoll(int pins)
        {
            if (pins == 10)
            {
                StrikeFrame();
                AddBonusThrowIfLastFrame(2);

                _isLastBallInFrame = true;
            }
            else
            {
                _firstThrow = pins;
                _isLastBallInFrame = false;
                _firstThrowInFrame = false;
            }
        }

        private void SecondRoll(int pins)
        {
            VerifyPins(_firstThrow + pins);

            if (_firstThrow + pins == 10)
            {
                SpareFrame(_firstThrow, pins);
                AddBonusThrowIfLastFrame(1);
            }
            else
            {
                OpenFrame(_firstThrow, pins);
                _frameNumber++;
            }

            _isLastBallInFrame = false;
            _firstThrowInFrame = true;
        }

        private void BonusRoll(int pins)
        {
            BonusFrame(pins);
            _lastRoundBonusThrowRemaining--;

            if (_lastRoundBonusThrowRemaining == 0)
            {
                _frameNumber++;
                _lastRoundBonusThrowRemaining--;
            }
        }
    }
}