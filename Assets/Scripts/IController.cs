using System;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public interface IController
    {
        void FinishTurn();
        void Disable();
        void Enable();
        void OnBonusTaken();
        void OnBonusRemoveFromHand();
		GameInventory GetInventory();
		BonusOwner GetOwner();
    }
}
