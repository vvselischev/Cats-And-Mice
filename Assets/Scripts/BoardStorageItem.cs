using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class BoardStorageItem
    {
        public IBonus bonus;
        public BoardButton boardButton;

        public BoardStorageItem(BoardButton boardButton, IBonus bonus)
        {
            this.bonus = bonus;
            this.boardButton = boardButton;
        }
    }
}