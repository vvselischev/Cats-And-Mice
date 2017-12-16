using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts
{
    public class MouseTrap : IBonus
    {
        public event VoidHandler executed;
        public Image image;

        public void OnTake()
        {

        }

        public void Execute()
        {
            RoundJudge.GetInstance().TryToKill();
        }

        public MouseTrap(Image image)
        {
            this.image = image;
        }

        public BonusType GetBonusType()
        {
            return BonusType.TRAP;
        }

        public Image GetBonusImage()
        {
            return image;
        }

        public bool CanTakeToHand()
        {
            return true;
        }

        public BonusOwner GetOwner()
        {
            return BonusOwner.CAT;
        }

        public void DropOnBoard(BoardButton boardButton)
        {

        }

        public bool CanHoldInStorage()
        {
            return true;
        }
    }
}