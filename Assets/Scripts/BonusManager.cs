using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
	public class BonusManager : MonoBehaviour
	{
		public IBonus ActiveBonus;
		public GameIcon activeBonusIcon;
		public BonusFactory factory;
        public ControllerManager controllerManager;
		public BoardStorage storage;

		public bool HasActiveBonus()
		{
			return ActiveBonus != null;
		}

		public void TakeBonus(GameInventory inventory, BonusType bonus)
		{
            if (HasActiveBonus())
            {
                PutAway();
            }

			ActiveBonus = factory.CreateBonus(bonus, controllerManager.currentController.GetOwner());
			ActiveBonus.executed += () => inventory.RemoveBonus(bonus);

            if (ActiveBonus.CanTakeToHand())
            {
                activeBonusIcon.SetImage(ActiveBonus.GetBonusImage());
                controllerManager.currentController.OnBonusTaken();
                ActiveBonus.OnTake();
            }
            else
            {
                ActiveBonus.Execute();
                ActiveBonus = null;
            }    
		}


		public void PutAway()
		{
			Reset();
            controllerManager.currentController.OnBonusRemoveFromHand();
		}

        public void OnBoardClick(BoardButton boardButton)
        {
			
            if (HasActiveBonus())
            {
				GameInventory inventory = controllerManager.currentController.GetInventory();
				BonusType bonus = ActiveBonus.GetBonusType();
				if (inventory.HasBonus(bonus)) 
				{
					ActiveBonus.DropOnBoard (boardButton);
					if (ActiveBonus.CanHoldInStorage()) 
					{
						if (storage.TryAdd (boardButton, ActiveBonus)) 
						{
							boardButton.icon.SetImage (ActiveBonus.GetBonusImage ());
							inventory.RemoveBonus (bonus);
						}
					} 

				}
            }
        }

		public void Reset()
		{
			ActiveBonus = null;
			activeBonusIcon.Reset();
		}
	}
}

