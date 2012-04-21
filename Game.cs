﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
    public class Game
    {
        private int currentFrame = 1;
        private bool isFirstThrow = true;
        private Scorer scorer = new Scorer();

        public int Score
        {
            get { return ScoreForFrame(currentFrame); }
        }

        public void Add(int pins)
        {
            scorer.AddThrow(pins);
            AdjustCurrentFrame(pins);
        }

        private void AdjustCurrentFrame(int pins)
        {
            if (LastBallInFrame(pins))
                AdvanceFrame();
            else
                isFirstThrow = false;                           
        }

        private bool LastBallInFrame(int pins)
        {
            return (Strike(pins)) || (!isFirstThrow);
        }

        private bool Strike(int pins)
        {
            return isFirstThrow && pins == 10;
        }

        private bool AdjustFrameForStrike(int pins)
        {
            if (pins == 10)
            {
                AdvanceFrame();
                return true;
            }
            return false;
        }

        private void AdvanceFrame()
        {
            currentFrame++;
            if (currentFrame > 10)
                currentFrame = 10;
        }

        public int ScoreForFrame(int theFrame)
        {
            return scorer.ScoreForFrame(theFrame);
        }

       
    }
}