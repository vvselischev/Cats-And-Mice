using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TimeBonus : IBonus
    {
        public event VoidHandler executed;

        private TimerManager timer;
        public int deltaTime;
        public Image image;

        public void Execute()
        {
            timer.AddTime(deltaTime);
            executed();
        }

        public TimeBonus(int deltaTime, Image image)
        {
            this.deltaTime = deltaTime;
            timer = GameObject.FindObjectOfType<TimerManager>();
            this.image = image;
        }

        public void OnTake()
        {
            Execute();
        }

        public BonusType GetBonusType()
        {
            return BonusType.TIME;
        }

        public Image GetBonusImage()
        {
            return image;
        }
        public bool CanTakeToHand()
        {
            return false;
        }

        public BonusOwner GetOwner()
        {
            return BonusOwner.NEUTRAL;
        }

        public void DropOnBoard(BoardButton boardButton)
        {

        }

        public bool CanHoldInStorage()
        {
            return false;
        }
    }
}