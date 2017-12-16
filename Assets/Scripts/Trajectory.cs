using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Trajectory
    {
        private WayPoint[,] wayPoints;

        public List<WayPoint> path;

        private int boardWidth;
        private int boardHeight;
        private WayPoint lastPoint;
        public event VoidHandler OnChanged;

        public Trajectory(Vector2 boardSize)
        {
            boardWidth = (int)boardSize.x;
            boardHeight = (int)boardSize.y;
            Reset();
        }

        public void Reset()
        {
            wayPoints = new WayPoint[boardWidth + 1, boardHeight + 1];
            lastPoint = new WayPoint()
            {
                mouseButton = new MouseButton()
                {
                    boardButton = new BoardButton() { boardY = 0, }
                },
                number = 0
            };
            path = new List<WayPoint>();
        }

        /*void Awake()
        {
            wayPoints = new WayPoint[boardWidth + 1, boardHeight + 1];
            path = new List<WayPoint>();
        }*/

        public bool AddWayPoint(MouseButton mouseButton)
        {
            int x = mouseButton.boardButton.boardX;
            int y = mouseButton.boardButton.boardY;
            if (CanAddWayPoint(x, y))
            {
                WayPoint newPoint = new WayPoint()
                {
                    mouseButton = mouseButton,
                    number = lastPoint.number + 1,

                };
                path.Add(newPoint);
                wayPoints[x, y] = newPoint;
                lastPoint = newPoint;
                OnChanged();
                return true;
            }
            return false;
        }

        public IEnumerable Path()
        {
            return path;
        }

        private bool CanAddWayPoint(int x, int y)
        {
            Vector2 currentPos = new Vector2(x, y);
            Vector2 lastPos = new Vector2(lastPoint.mouseButton.boardButton.boardX,
                lastPoint.mouseButton.boardButton.boardY);
            return CheckInsideBoard(x, y) && IsEmpty(x, y) && (y >= lastPos.y)
                && CheckOnLine(currentPos, lastPos);
        }

        private bool CheckOnLine(Vector2 currentPos, Vector2 lastPos)
        {
            return ((lastPoint.number == 0) && (currentPos.y == 1)) ||
                (ManhattenDist(currentPos, lastPos) == 1);
        }

        private float ManhattenDist(Vector2 first, Vector2 second)
        {
            return Math.Abs(first.x - second.x) + Math.Abs(first.y - second.y);
        }

        private bool IsEmpty(int x, int y)
        {
            return wayPoints[x, y] == null;
        }

        private int WayPointNumber(int x, int y)
        {
            return wayPoints[x, y].number;
        }

        private bool CheckInsideBoard(int x, int y)
        {
            return (x >= 1) && (x <= boardWidth) && (y >= 1) && (y <= boardHeight);
        }

        public bool Finished()
        {
            return lastPoint.mouseButton.boardButton.boardY == boardHeight;
        }

        public void DeleteFromPos(int posX, int posY)
        {
            if (!IsEmpty(posX, posY))
            {
                WayPoint currentWayPoint = wayPoints[posX, posY];
                lastPoint = path.Find(item =>
               {
                   return item.number == currentWayPoint.number - 1;
               });

                path.RemoveAll(item =>
                    {
                        if (item.number >= currentWayPoint.number)
                        {
                            item.mouseButton.ResetColor();
                            item = null;
                            return true;
                        }
                        return false;
                    });

                for (int i = 1; i <= boardWidth; i++)
                {
                    for (int j = 1; j <= boardHeight; j++)
                    {
                        if (wayPoints[i, j] != null)
                        {
                            if (wayPoints[i, j].number >= currentWayPoint.number)
                            {
                                wayPoints[i, j] = null;
                            }
                        }
                    }
                }
                if (lastPoint == null)
                {
                    Reset();
                }
                OnChanged();
            }
        }
    }
}