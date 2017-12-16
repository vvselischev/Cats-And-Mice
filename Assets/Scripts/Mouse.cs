using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts
{
    public class Mouse : MonoBehaviour
    {
        public List<IBonus> bonuses;

        void Awake()
        {
            bonuses = new List<IBonus>();
        }
        
        public void AddBonus(IBonus bonus)
        {
            if (bonus != null)
            {
                bonuses.Add(bonus);
            }
        }

        public void DeleteBonus(IBonus bonus)
        {
            if (bonus != null)
            {
                bonuses.Remove(bonus);
            }
        }

        public bool IsArmoured()
        {
            return bonuses.FindIndex(currentBonus => (currentBonus.GetBonusType() ==
               BonusType.ARMOUR)) >= 0;
        }

        public void Init()
        {
            bonuses.Clear();
        }

        public void Kill()
        {
            //TODO: some effect
        }
    }
}