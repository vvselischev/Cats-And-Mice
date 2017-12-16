using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
	public enum BonusType 
	{
        ARMOUR,
        TIME,
		TRAP,	
        RUBBER,
	}
	public enum BonusOwner
	{
		CAT,
		MOUSE,
		NEUTRAL
	}
	public class BonusFactory : MonoBehaviour
	{
		public Image timeImage;
		public Image trapImage;
        public Image rubberImage;

		public IBonus CreateBonus(BonusType bonus, BonusOwner owner)
        {
			switch (bonus) 
			{
				case BonusType.TIME: 
					return new TimeBonus(5, timeImage); // Вынести в глобальный инвентарь
				case BonusType.TRAP: 
					return new MouseTrap(trapImage);
                case BonusType.RUBBER:
                    return new Rubber(rubberImage, owner);
			}
			return null;
		}

	}
}

