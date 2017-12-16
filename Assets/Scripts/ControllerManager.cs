using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts
{
    public class ControllerManager : MonoBehaviour
    {
        public IController currentController;
        public MouseUserController MouseController;
        public CatUserController CatController;

        public void SetCurrentController(TurnType type)
        {
            if (type == TurnType.CAT)
            {
                currentController = CatController;
            }
            else
            {
                currentController = MouseController;
            }
        }

        public void FinishTurn()
        {
            currentController.FinishTurn();
        }

        public void InitRound()
        {
            MouseController.trajectory.Reset();
        }

        public void EnableMouseController()
        {
            MouseController.Enable();
        }

        public void DisableMouseController()
        {
            MouseController.Disable();
        }

        public void EnableCatController()
        {
            CatController.Enable();
        }

        public void DisableCatController()
        {
            CatController.Disable();
        }
    }
}