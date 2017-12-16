using System;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public delegate void VoidHandler();

    public interface IBonus
    {
        event VoidHandler executed;
        void Execute();
        void OnTake();
        BonusOwner GetOwner();
        Image GetBonusImage();
        BonusType GetBonusType();
        bool CanTakeToHand();
        void DropOnBoard(BoardButton boardButton);
        bool CanHoldInStorage();
    }
}
