using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class MouseUserController : MonoBehaviour, IController
    {
        public Trajectory trajectory;
        public CheckeredBoard board;

        public PlayGameState PlayState;
        public BoardStorage storage;
        public GameInventory MouseGameInventory;

        public StartButton startButton;

        public void Disable()
        {
            enabled = false;

            foreach (WayPoint wayPoint in trajectory.path)
            {
                wayPoint.mouseButton.ResetColor();
            }
            DisableTrajectoryEnter();
        }

        public void DisableTrajectoryEnter()
        {
            var buttons = FindObjectsOfType(typeof(Button));
            foreach (Button button in buttons.Cast<Button>().Where(button =>
                button.GetComponent<MouseButton>() != null))
            {
                button.gameObject.GetComponent<MouseButton>().Disable();
            }
        }

        public void EnableTrajectoryEnter()
        {
            var buttons = FindObjectsOfType(typeof(Button));
            foreach (Button button in buttons.Cast<Button>().Where(button =>
                button.GetComponent<MouseButton>() != null))
            {
                button.gameObject.GetComponent<MouseButton>().Enable();
            }
        }

        public void Enable()
        {
            enabled = true;
            startButton.Lock();
            EnableTrajectoryEnter();
        }

        private void LockStartButton()
        {
            startButton.Lock();
        }

        private void UnlockStartButton()
        {
            startButton.Unlock();
        }

        public void FinishTurn()
        {
            if (trajectory.Finished())
            {
                PlayState.OnFinishTurn(TurnType.MOUSE);
            }
        }

        void Awake()
        {
            trajectory = new Trajectory(new Vector2(board.width, board.height));
            trajectory.OnChanged += TrajectoryChanged;
            storage.SetTrajectory(trajectory);
        }

        private void TrajectoryChanged()
        {
            if (trajectory.Finished())
            {
                UnlockStartButton();
            }
            else
            {
                LockStartButton();
            }
        }

        public bool TryAddButton(MouseButton mouseButton)
        {
            return trajectory.AddWayPoint(mouseButton);
        }

        public void OnBonusTaken()
        {
            DisableTrajectoryEnter();
        }

        public void OnBonusRemoveFromHand()
        {
            EnableTrajectoryEnter();
        }


        public GameInventory GetInventory()
        {
            return MouseGameInventory;
        }

        public BonusOwner GetOwner()
        {
            return BonusOwner.MOUSE;
        }
    }
}