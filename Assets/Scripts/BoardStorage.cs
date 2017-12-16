using System;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class BoardStorage : MonoBehaviour
    {
        public List<BoardStorageItem>[,] boardTable;
        public Trajectory trajectory;
        public CheckeredBoard board;
        private static BoardStorage instance;
        public ControllerManager controllerManager;

        public static BoardStorage GetInstance()
        {
            return instance;
        }

        private bool CheckSameOwner(IBonus bonus, int boardX, int boardY)
        {
            return boardTable[boardX, boardY].Exists(item =>
               {
                   return (item.bonus.GetOwner() == bonus.GetOwner());
               });
        }

        public bool TryAdd(BoardButton boardButton, IBonus bonus)
        {
            int boardX = boardButton.boardX;
            int boardY = boardButton.boardY;
            if (!CheckSameOwner(bonus, boardX, boardY))
            {

                boardTable[boardX, boardY].Add(new BoardStorageItem(boardButton, bonus));
                return true;
            }
            return false;
        }

        void Awake()
        {
            instance = this;
            boardTable = new List<BoardStorageItem>[board.width + 1, board.height + 1];
            for (int i = 1; i <= board.width; i++)
            {
                for (int j = 1; j <= board.height; j++)
                {
                    boardTable[i, j] = new List<BoardStorageItem>();
                }
            }
        }

        public void SetTrajectory(Trajectory trajectory)
        {
            this.trajectory = trajectory;
        }

        public void RemoveBoardItem(BoardButton boardButton, BonusOwner owner)
        {
            int boardX = boardButton.boardX;
            int boardY = boardButton.boardY;
            BoardStorageItem lastItem = boardTable[boardX, boardY].FindLast(item =>
                {
                    return (item.bonus.GetOwner() == owner);
                });
            if (lastItem != null)
            {
                lastItem.boardButton.icon.Reset();
                controllerManager.currentController.GetInventory().AddBonus(lastItem.bonus.GetBonusType());
                boardTable[boardX, boardY].Remove(lastItem);
            }
            else if (owner == BonusOwner.MOUSE)
            {
                trajectory.DeleteFromPos(boardX, boardY);
            }
        }

        public void Reset()
        {
            for (int i = 1; i <= board.width; i++)
            {
                for (int j = 1; j <= board.height; j++)
                {
                    foreach (BoardStorageItem item in boardTable[i, j])
                        item.boardButton.icon.Reset();
                    boardTable[i, j].Clear();
                }
            }

        }
    }
}