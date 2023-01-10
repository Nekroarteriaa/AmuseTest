using System.Collections;
using DG.Tweening;
using ScriptableEvents.Void;
using ScriptableVariables.Float;
using UnityEngine;

namespace ShotTest
{
    public class ShotTestThree : MonoBehaviour
    {
        [SerializeField] 
        private Transform firePoint;

        [SerializeField] 
        private Transform finalPoint;

        [SerializeField] private GameObject prefab;

        [SerializeField] 
        private float height;

        [SerializeField] 
        private float angle;

        [SerializeField] 
        private LineRenderer lineRenderer;

        [SerializeField] 
        private float step;

        [SerializeField]
        private float finalTime;

        [SerializeField] 
        private ScriptableVariableFloat velocityScriptableVariable;
        
        [SerializeField] 
        private ScriptableEventVoid scriptableEventVoid;
        
        [SerializeField] 
        private bool hasLaunched;
        
        private void Update()
        {
            if(hasLaunched) return;
            
            height = finalPoint.position.y + finalPoint.position.magnitude / 2f;
            float v0;
            float time;
            CalculatePathWithHeight(finalPoint.position - firePoint.position, height, out v0, out angle, out time);
            DrawPath(v0, angle, time, step);
            if (Input.GetMouseButtonDown(0))
            {
               // StopAllCoroutines();
                var projectile = GameObject.Instantiate(prefab, firePoint.position, Quaternion.identity);
              //  StartCoroutine(MovementCourutine(v0, angle, finalTime, projectile.transform));

              var velocity = Vector2.Distance(projectile.transform.position, new Vector2(projectile.transform.position.x, projectile.transform.position.y * height)) / finalTime;
              
              projectile.transform.DOMoveY(projectile.transform.position.y + height, finalTime).OnComplete(() =>
              {
               //   projectile.AddComponent<Rigidbody2D>();
              });
              
              
              print("Velocity: " + velocity);

              Vector3 finalPointCalculated = (Vector2)firePoint.position + Physics2D.gravity *finalTime;
              
              print("Final Point:"+   finalPointCalculated);
              
              velocityScriptableVariable.SetValue(velocity);
              scriptableEventVoid.InvokeEvent();
              hasLaunched = true;

              // projectile.transform.DOLocalJump(projectile.transform.position, 2f, 1, 5f);
              // projectile.transform.DOJump(new Vector3(0, projectile.transform.position.y + height, 0), 2f, 1, 5f);
            }
        }

        void CalculatePathWithHeight(Vector3 finalPosition, float h, out float v0, out float angle, out float time)
        {
            float xfinalPosition = finalPosition.x;
            float yfinalPosition = finalPosition.y;
            float g = -Physics2D.gravity.y;

            float a = (-0.5f * g);
            float b = Mathf.Sqrt(2 * g * h);
            float c = -yfinalPosition;

            float tMax = QuadraticEquation(a, b, c, 1);
            float tMin = QuadraticEquation(a, b, c, -1);
            time = tMax > tMin ? tMax : tMin;
            
            angle = Mathf.Atan(b * time / xfinalPosition);
            v0 = b / Mathf.Sin(angle);
        }

        void DrawPath(float v0, float angle, float time ,float step)
        {
            step = Mathf.Max(0.01f, step);
            lineRenderer.positionCount = (int)(time / step) + 2;
            int count = 0;
            for (float i = 0; i < time; i+= step)
            {
                float x = v0 * i * Mathf.Cos(angle);
                float y = v0 * i * Mathf.Sin(angle) - (1f / 2f) * -Physics2D.gravity.y * Mathf.Pow(i, 2);
                lineRenderer.SetPosition(count, firePoint.position + new Vector3(x,y));
                count++;
            }
            
            float xfinal = v0 * time * Mathf.Cos(angle);
            float yfinal = v0 * time * Mathf.Sin(angle) - (1f / 2f) * -Physics2D.gravity.y * Mathf.Pow(time, 2);
            lineRenderer.SetPosition(count, firePoint.position + new Vector3(xfinal,yfinal));
            
        }

        float QuadraticEquation(float a, float b, float c, float sign)
        {
            return (-b + sign * Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a);
        }
        
        IEnumerator MovementCourutine(float v0, float angle, float time, Transform objectToMove)
        {
            float t = 0f;
            while (t < time)
            {
                float x = v0 * t * Mathf.Cos(angle);
                float y = v0 * t * Mathf.Sin(angle) - (1f / 2f) * -Physics2D.gravity.y * Mathf.Pow(t, 2);
                objectToMove.position = firePoint.position + new Vector3(0, y);
                t += Time.deltaTime;
                yield return null;
            }
        }
    }
}