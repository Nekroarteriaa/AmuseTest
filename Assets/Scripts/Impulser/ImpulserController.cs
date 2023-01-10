using System;
using Unity.Mathematics;
using UnityEngine;

namespace Impulser
{
    public class ImpulserController : MonoBehaviour
    {
        
        public float impulseForce;

        [SerializeField] private Vector2 wea;
        [SerializeField] [Range(0f, 1f)] 
        private float influenceOnX;

        [SerializeField] private float movementSpeed;
        
        // private void OnTriggerEnter2D(Collider2D col)
        // {
        //     // Vector3 temp = col.transform.position - transform.position;
        //     // Vector3 normalPoint = transform.position + temp;
        //     //
        //     // Vector3 collisionPoint = col.ClosestPoint(transform.position);
        //     // var newNormal = transform.position - collisionPoint;
        //    // print(normalPoint.normalized);
        //     //print();
        //     // print(newNormal.magnitude);
        //     // print(newNormal.normalized);
        //    //  ContactPoint2D[] contacts = new ContactPoint2D[1];
        //    // int numContacts = col.GetContacts(contacts);
        //    // for (int i = 0; i < numContacts; i++)
        //    // {
        //    //     print(i);
        //    // }
        //    
        //    // Vector3 collisionPoint = col.ClosestPoint(transform.position);
        //    // var direction = transform.position - collisionPoint;
        //    // // print(direction.normalized);
        //    //  
        //    //
        //    //
        //    //  var currentVelocity = col.GetComponent<Rigidbody2D>().velocity;
        //    //  currentVelocity += wea;
        //    //  col.GetComponent<Rigidbody2D>().velocity = currentVelocity;
        //    // col.GetComponent<Rigidbody2D>().AddForce(direction.normalized * wea, ForceMode2D.Impulse);
        //    
        //    
        //    // Vector3 collisionPoint = col.ClosestPoint(transform.position);
        //    // var direction = transform.position - collisionPoint;
        //    // print(col.GetComponent<Rigidbody2D>().velocity.y);
        //    // var currentVelocity = col.GetComponent<Rigidbody2D>().velocity;
        //    // var normalizedAcceleration =  wea.y - Mathf.Abs(currentVelocity.y);
        //    //  col.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //    // col.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.normalized.x * wea.x, normalizedAcceleration) , ForceMode2D.Impulse);
        //    
        //    
        //    // var currentVelocity = col.GetComponent<Rigidbody2D>().velocity;
        //    // var finishDirection = new Vector2(direction.normalized.x, 1);
        //    // var newVelocity = currentVelocity + (finishDirection * impulseForce);
        //    // col.GetComponent<Rigidbody2D>().velocity = newVelocity;
        //    
        //    
        //    // Vector3 collisionPoint = col.ClosestPoint(transform.position);
        //    // var direction = transform.position - collisionPoint;
        //    // var currentVelocity = col.GetComponent<Rigidbody2D>().velocity;
        //    // var finalP = direction * currentVelocity;
        //    // col.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //    // col.GetComponent<Rigidbody2D>().AddForce(finalP.normalized * wea , ForceMode2D.Impulse);
        //    
        //    var currentVelocity = col.GetComponent<Rigidbody2D>().velocity;
        //    Vector3 collisionPoint = col.ClosestPoint(transform.position);
        //    var newNormal = transform.position - collisionPoint;
        //    var direction = Vector2.Reflect(currentVelocity, newNormal).normalized;
        //    print(direction);
        //    col.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, Mathf.Abs(direction.y)) * impulseForce;
        // }

        // private void OnCollisionEnter2D(Collision2D col)
        // {
        //     var currentSpeed = GetComponent<Rigidbody2D>().velocity.magnitude;
        //     var impulserNormal = col.contacts[0].normal;
        //     var direction = Vector2.Reflect(GetComponent<Rigidbody2D>().velocity.normalized, impulserNormal);
        //     col.transform.GetComponent<Collider2D>().enabled = false;
        //    GetComponent<Rigidbody2D>().velocity = direction * currentSpeed;
        // }

        private void Update()
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }


        private void OnTriggerEnter2D(Collider2D col)
        {
            var currentVelocity = col.GetComponent<Rigidbody2D>().velocity;
            float bounce = Vector3.Dot(currentVelocity, transform.up);
            //var finalshit = wea * ;
            col.GetComponent<Rigidbody2D>().AddForce(new Vector2(influenceOnX, 1) * (impulseForce - bounce), ForceMode2D.Impulse);
        }
    }
}