using DG.Tweening;
using ScriptableEvents.Void;
using UnityEngine;

namespace ShotTest
{
    public class ShotTwo : MonoBehaviour
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
        private ScriptableEventVoid scriptableEventVoid;

        [SerializeField] 
        private bool hasLaunched;

        [SerializeField] 
        private GameObject projectilePrefab;

        private Vector2 direction;
        
        private void Update()
        {
            if(hasLaunched) return;
            
            if (Input.GetMouseButton(0))
            {
                var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                direction = mousePosition - transform.position;
                float angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
                if(angle < minAngle || angle >= maxAngle) return;
                angle = Mathf.Clamp(angle, minAngle, maxAngle);
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            }
            
            else if (Input.GetMouseButtonUp(0))
            {
                // GameObject projectile = new GameObject("Projectile");
                // projectile.transform.SetPositionAndRotation(transform.position, transform.rotation);
                // projectile.AddComponent<BoxCollider2D>();
                // projectile.AddComponent<SpriteRenderer>().sprite = spriteRef;
                var projectile = GameObject.Instantiate(projectilePrefab, transform.position, transform.rotation); 
                projectile.GetComponent<Rigidbody2D>().AddForce(Vector3.up * (throwForce), ForceMode2D.Impulse);


                transform.DOMoveX(-100f, 1f);
                scriptableEventVoid.InvokeEvent();
                hasLaunched = true;



            }
        }
    }
}