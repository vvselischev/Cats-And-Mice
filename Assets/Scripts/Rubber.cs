using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Rubber : IBonus
    {
        public event VoidHandler executed;
        public Image image;
		public BoardStorage storage;
		private BonusOwner owner;

		public Rubber(Image image, BonusOwner owner)
        {
            this.image = image;
			storage = BoardStorage.GetInstance ();
			this.owner = owner;
        }

        public bool CanTakeToHand()
        {
            return true;
        }

        public void Execute()
        {
            
        }

        public Image GetBonusImage()
        {
            return image;
        }

        public BonusType GetBonusType()
        {
            return BonusType.RUBBER;
        }

        public void OnTake()
        {
            
        }

		public BonusOwner GetOwner()
		{
			return owner;
		}

		public void DropOnBoard(BoardButton boardButton)
		{
			storage.RemoveBoardItem(boardButton, owner);
		}

		public bool CanHoldInStorage()
		{
			return false;
		}
    }
}