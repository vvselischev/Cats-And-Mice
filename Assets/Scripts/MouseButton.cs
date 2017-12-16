using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class MouseButton : MonoBehaviour
    {
        public MouseUserController Controller;
        public BoardButton boardButton;
        private Color defaultColor;

        public void Initialize(BoardButton boardButton)
        {
            this.boardButton = boardButton;
            defaultColor = GetComponent<Image>().color;
        }

        public void ResetColor()
        {
            GetComponent<Image>().color = defaultColor;
        }

        public void OnMouseEnter()
        {
            if (enabled)
            {
                if (Controller.TryAddButton(this))
                {
                    boardButton.button.image.color = Color.green;
                }
            }
        }

        public void Enable()
        {
            enabled = true;
        }

        public void Disable()
        {
            enabled = false;
        }
    }
}