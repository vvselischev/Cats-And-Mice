﻿using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Follower : MonoBehaviour
    {
        //public Transform transform;
        public float velocity;

        public event VoidHandler ReachedTarget;

        private Vector3 localPosition;
        private float fraction;

        void Awake()
        {
            localPosition = gameObject.GetComponent<RectTransform>().localPosition;
        }

        public IEnumerator MoveTo(Vector3 startPosition, Vector3 targetPosition)
        {
            fraction = 0;
            Vector3 direction = targetPosition - startPosition;
            while (fraction < 1)
            {
                fraction += velocity / direction.magnitude * Time.deltaTime;
                //gameObject.GetComponent<RectTransform>().localPosition += direction * Time.deltaTime;
                gameObject.GetComponent<RectTransform>().localPosition =
                    Vector3.Lerp(startPosition, targetPosition, fraction);
                yield return null;
            }
            ReachedTarget();
        }
    }
}