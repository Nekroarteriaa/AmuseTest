using System;
using ScriptableEvents.Void;
using ScriptableVariables.Float;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace Parallax
{
    public class ParallaxEffectThree : MonoBehaviour
    {
        // private Transform lastestBackground;
        // public void MoveBackgroundTowardsEndPoint(Transform hittedBackground)
        // {
        //     if(hittedBackground == lastestBackground) return;
        //     //TODO Move Towards endPoint
        //     lastestBackground = hittedBackground;
        // }

        [SerializeField] 
        private Camera virtualCamera;

        // [SerializeField] 
        // private GameObject[] parallaxPlanes;
        [SerializeField] 
        private GameObject parallaxPlane;

        // [SerializeField] 
        // private float movementSpeed;
        

        [SerializeField]
        private bool canFollowTheCamera;
        
        [SerializeField] [Range(0f,1f)]
        private float movement = 1f;

        [SerializeField] 
        private Renderer selfRenderer;

        [SerializeField][Range(10f, 100f)] 
        private float materialOffset;

        [SerializeField]
        private ScriptableVariableFloat wea;
        


        private float currentAcceleration;
        private float previousAcceleration;
        private float currentTime;
        

        private void FixedUpdate()
        {
            if(!canFollowTheCamera) return;
            float currentParallaxPositionX = virtualCamera.transform.position.x * movement;
            parallaxPlane.transform.position = new Vector3(currentParallaxPositionX, parallaxPlane.transform.position.y, parallaxPlane.transform.position.z);
        }

        private void LateUpdate()
        {
            if(!canFollowTheCamera) return;
            currentTime += Time.deltaTime;
            CalculateParallaxEffectMovement();
        }

        void CalculateParallaxEffectMovement()
        {
            
            // acc = DVelocity / t
            
            //float temp = (virtualCamera.transform.position.x * CalculateParallaxEffectOffset());
            
            
            // float currentParallaxPositionX = virtualCamera.transform.position.x * movement;
            // parallaxPlane.transform.position = new Vector2(startPosition + currentParallaxPositionX, parallaxPlane.transform.position.y);
            // var distance = startPosition - parallaxPlane.transform.position.x;
            // selfRenderer.material.mainTextureOffset += new Vector2(materialOffset, 0)* wea.Value;



            //selfRenderer.material.mainTextureOffset += new Vector2(CalculateTheEffectAcceleration(), 0);
            if(wea.Value <= 0 ) return;
            currentAcceleration = CalculateTheEffectAcceleration();
            selfRenderer.material.mainTextureOffset += new Vector2(Mathf.Lerp(previousAcceleration, currentAcceleration, Time.deltaTime), 0) * Time.deltaTime;
            previousAcceleration = currentAcceleration;
        }

        public void OnShoot()
        {
            canFollowTheCamera = true;
        }

        float CalculateTheEffectAcceleration()
        {
            return (wea.Value) / (currentTime * materialOffset);
        }
    }
}