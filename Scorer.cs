using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
    public class Scorer
    {
        private int ball;
        private int[] throws = new int[21];
        private int curretThrow;

        public void AddThrow(int pins)
        {
            throws[curretThrow++] = pins;
        }

        public int ScoreForFrame(int theFrame)
        {
            ball = 0;
            int score = 0;
            for (int currentFrame = 0; currentFrame < theFrame; currentFrame++)
            {
                if (Strike())
                {
                    score += 10 + NextTwoBalls;
                    ball++;
                }
                else if (Spare())
                {
                    score += 10 + NextBall;
                    ball += 2;
                }
                else
                {
                    score += TwoBallsInFrame;
                    ball += 2;
                }
            }
            return score;
        }

        private bool Strike()
        {
            return throws[ball] == 10;
        }


        private int NextTwoBalls
        {
            get { return (throws[ball + 1] + throws[ball + 2]); }
        }

        private int TwoBallsInFrame
        {
            get { return throws[ball] + throws[ball + 1]; }
        }

        private bool Spare()
        {
            return throws[ball] + throws[ball + 1] == 10;
        }

        private int NextBall
        {
            get { return throws[ball + 2]; }
        }
    }
}
