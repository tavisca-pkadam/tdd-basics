﻿using System;

namespace BowlingBall
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;
        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int GetScore()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }

            }

            return score;
        }

        private int SumOfBallsInFrame(int frameIndex) {
            return rolls[frameIndex] + rolls[frameIndex+1];
        }

        private int SpareBonus(int frameIndex) {
            return rolls[frameIndex+2];
        }

        private int StrikeBonus(int frameIndex) {
            return rolls[frameIndex+1] + rolls[frameIndex+2];
        }

        private bool IsStrike(int frameIndex)
        {
            return int.Equals(10, rolls[frameIndex]);
        }

        private bool IsSpare(int frameIndex)
        {
            return int.Equals(10, rolls[frameIndex] + rolls[frameIndex+1]);
        }

    }
}

