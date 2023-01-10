using System;
using DG.Tweening;
using UnityEngine;

namespace Projectile
{
    public class ProjectileController : MonoBehaviour
    {
        [SerializeField] 
        private Rigidbody2D rigi2D;

        [SerializeField] 
        private float fallingGravity;

        private float originalGravity;

        private Vector2 originalPosition;

        private void OnEnable()
        {
           // originalGravity = rigi2D.gravityScale;
            originalPosition = transform.position;
            print("Enable");
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.DOMoveY(originalPosition.y, .3f);
                //rigi2D.gravityScale = fallingGravity;
            }
        }
    }
}