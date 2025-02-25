using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Binuswhy
{
    public class VerticalFloatTrap : MonoBehaviour
    {
        static float t = 0.0f;
        public float distance, speed, timeStart;

        private float originalPosY;
        bool isRotate = false;

        void Start()
        {
            originalPosY = transform.position.y;
            
        }

        float a; 

        void Update()
        {
            transform.position = new Vector3(transform.position.x, originalPosY + Mathf.Sin(t) * distance, transform.position.z);
            t += speed * Time.deltaTime;
        }
    }
}
