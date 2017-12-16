using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public enum TurnType
    {
        MOUSE,
        CAT,
        RESULT
    }

    public class TurnManager : MonoBehaviour
    {
        public ControllerManager controllerManager;

        public GameObject MouseUI;
        public GameObject CatUI;
		public GameObject RoundUI;

        public GameObject mouseMover;
        public GameObject MouseIcon;
        public GameObject CatIcon;

        private TurnType currentTurn;

        public TurnType CurrentTurn
        {
            get
            {
                return currentTurn;
            }
        }

        public void InitRound()
        {
            controllerManager.InitRound();
        }

        private void DisableMouse()
        {
            controllerManager.DisableMouseController();
            MouseUI.SetActive(false);
        }

        private void EnableMouse()
        {
            controllerManager.EnableMouseController();
            MouseUI.SetActive(true);
        }

        private void DisableCat()
        {
            CatUI.SetActive(false);
            CatIcon.SetActive(false);
            controllerManager.DisableCatController();
        }

        private void EnableCat()
        {
            CatUI.SetActive(true);
            CatIcon.SetActive(true);
            controllerManager.EnableCatController();
        }

		private void EnableRound()
		{
			RoundUI.SetActive(true);
		}

		private void DisableRound()
		{
			RoundUI.SetActive(false);
		}

        public void SetTurn(TurnType turn)
        {
            currentTurn = turn;
            controllerManager.SetCurrentController(turn);
            if (turn == TurnType.MOUSE)
            {
				EnableRound();
                DisableCat();
                EnableMouse();
            }
            else if (turn == TurnType.CAT)
            {
				EnableRound();
                DisableMouse();
                EnableCat();
            }
            else if (turn == TurnType.RESULT)
            {
                DisableCat();
                DisableMouse();
				DisableRound();
            }
        }

        public void SetNextTurn()
        {
            if (currentTurn == TurnType.MOUSE)
            {
                SetTurn(TurnType.CAT);
            }
            else
            {
                SetTurn(TurnType.MOUSE);
            }
        }
    }
}