using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameInventory : MonoBehaviour
    {
        private Dictionary<BonusType, int> inventoryDict;
        public List<InventoryItem> inventoryList;// для удобной работы в редакторе unity
        public BonusManager bonusManager;

        public void TryToTake(BonusType bonus)
        {
            if (HasBonus(bonus))
            {
                if (bonusManager.HasActiveBonus() && 
                    bonusManager.ActiveBonus.GetBonusType() == bonus)
                {
                    bonusManager.PutAway();
                }
                else
                {
                    bonusManager.TakeBonus(this, bonus);
                }
            }
        }

        public void RemoveBonus(BonusType bonus)
        {
            if (HasBonus(bonus))
            {
                inventoryDict[bonus]--;
                if (inventoryDict[bonus] == 0)
                {
                    bonusManager.PutAway();
                }
            }
        }

        private void ListToDictionary()
        {
            foreach (InventoryItem item in inventoryList)
            {
                inventoryDict.Add(item.type, item.count);
            }
        }

        void Awake()
        {
            inventoryDict = new Dictionary<BonusType, int>();
            ListToDictionary();
        }

        public bool HasBonus(BonusType bonus)
        {
            if (inventoryDict.ContainsKey(bonus))
            {
                return inventoryDict[bonus] > 0;
            }
            return false;
        }

        public void AddBonus(BonusType bonus)
        {
            if (inventoryDict.ContainsKey(bonus))
            {
                inventoryDict[bonus]++;
            }
        }
    }
}