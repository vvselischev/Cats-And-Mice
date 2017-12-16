using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class CatUserController : MonoBehaviour, IController
    {
        public PlayGameState playState;
        public CheckeredBoard board;
        public GameInventory CatGameInventory;

        public void FinishTurn()
        {
            playState.OnFinishTurn(TurnType.CAT);
        }

        public void Disable()
        {
            //var buttons = FindObjectsOfType(typeof(MouseButton));
            enabled = false;
        }

        public void Enable()
        {
            //var buttons = FindObjectsOfType(typeof(Button));

            enabled = true;
        }

        public void OnBonusTaken()
        {
            //throw new NotImplementedException();
        }

        public void OnBonusRemoveFromHand()
        {
            //throw new NotImplementedException();
        }

        public GameInventory GetInventory()
        {
            return CatGameInventory;
        }

        public BonusOwner GetOwner()
        {
            return BonusOwner.CAT;
        }
    }
}