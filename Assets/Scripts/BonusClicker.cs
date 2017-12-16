using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
	public class BonusClicker : MonoBehaviour
	{
		public BonusType bonusType;
		public GameInventory inventory;

		public void OnClick()
		{
			inventory.TryToTake(bonusType);
		}
	}
}

