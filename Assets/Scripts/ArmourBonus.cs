using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ArmourBonus : IBonus
    {
        public event VoidHandler executed;
        private Image image;

        public ArmourBonus(Image image)
        {
            this.image = image;
        }

        public bool CanTakeToHand()
        {
            return true;
        }

        public void Execute()
        {

        }

        public void OnTake()
        {
        }

        public Image GetBonusImage()
        {
            return image;
        }

        public BonusType GetBonusType()
        {
            return BonusType.ARMOUR;
        }

        public BonusOwner GetOwner()
        {
            return BonusOwner.MOUSE;
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
