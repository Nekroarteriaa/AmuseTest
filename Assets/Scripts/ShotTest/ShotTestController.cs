using System;
using DG.Tweening;
using Impulser;
using UnityEngine;

namespace ShotTest
{
    public class ShotTestController : MonoBehaviour
    {
        [SerializeField] 
        private float minAngle;
        [SerializeField] 
        private float maxAngle;

        [SerializeField]
        Sprite spriteRef;

        [SerializeField]
        private float throwForce;

        [SerializeField]
        private LineRenderer line;

        [SerializeField]
        int linePoints;

        [SerializeField] private float simulationThrowTime;

        [SerializeField]
        private float force;

        [SerializeField] private float acceleration;


        private Vector2 direction;
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                direction = mousePosition - transform.position;
                float angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
                if(angle < minAngle || angle >= maxAngle) return;
                angle = Mathf.Clamp(angle, minAngle, maxAngle);
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                //DrawPath(throwForce, angle, simulationThrowTime);

                //force = Mathf.Clamp(force, 0, throwForce);

               // force += Time.deltaTime * acceleration;

                line.positionCount = linePoints;

                for (int i = 0; i < linePoints; i++)
                {
                    line.SetPosition(i, DrawPath(i * simulationThrowTime));
                    
                    Vector2 initialVelocity = -(direction.normalized * (throwForce *(i * simulationThrowTime)));
                    print(initialVelocity );
                }
            }
            
            else if (Input.GetMouseButtonUp(0))
            {
                GameObject projectile = new GameObject("Projectile");
                projectile.transform.SetPositionAndRotation(transform.position, transform.rotation);
                projectile.AddComponent<BoxCollider2D>();
                // projectile.AddComponent<ImpulserController>();
                // projectile.GetComponent<ImpulserController>().impulseForce = 20;
                projectile.AddComponent<SpriteRenderer>().sprite = spriteRef;
                projectile.AddComponent<Rigidbody2D>().AddForce(transform.right * (throwForce), ForceMode2D.Impulse);


                transform.DOMoveX(-100f, 1f);


            }
           
        }

        // void DrawPath(float v0, float angle, float stepTime)
        // {
        //     stepTime = Mathf.Max(0.01f, stepTime);
        //     float totalTime = 10f;
        //     line.positionCount = (int)(totalTime / stepTime) +2;
        //     int count = 0;
        //     for (float i = 0; i < totalTime; i += stepTime)
        //     {
        //         float x0 = v0 * i * Mathf.Cos(angle);
        //         float y0 = v0 * i * Mathf.Sin(angle) - 0.5f * -Physics2D.gravity.y * Mathf.Pow(totalTime,2);
        //         line.SetPosition(count, transform.position + new Vector3(x0, y0));
        //     }
        //     
        //     float xfinal = v0 * totalTime * Mathf.Cos(angle);
        //     float yfinal = v0 * totalTime * Mathf.Sin(angle) - 0.5f * -Physics2D.gravity.y * Mathf.Pow(totalTime,2);
        //     line.SetPosition(count, transform.position + new Vector3(xfinal, yfinal));
        //
        // }

        Vector2 DrawPath(float t)
        {
            Vector2 position = transform.position;
            Vector2 initialVelocity = -(direction.normalized * (throwForce * t));
            return position + initialVelocity  + Physics2D.gravity * (0.5f * (t * t));
        }
    }
}