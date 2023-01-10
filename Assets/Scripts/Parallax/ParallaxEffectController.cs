using System;
using Cinemachine;
using UnityEngine;

namespace Parallax
{
    public class ParallaxEffectController : MonoBehaviour
    {
        [SerializeField] 
        private SpriteRenderer desiredSprite;
        
        [SerializeField] 
        private CinemachineVirtualCamera virtualCamera;

        [SerializeField] 
        private float movementEffect = 1f;
        
        private float spriteLength;
        private float startPosition;

        private void Awake()
        {
            startPosition = desiredSprite.transform.position.x;
            spriteLength = desiredSprite.bounds.size.x;
        }

        private void FixedUpdate()
        {
            float temp = (virtualCamera.transform.position.x * CalculateParallaxEffectOffset());
            float currentParallaxPositionX = virtualCamera.transform.position.x * movementEffect;

            desiredSprite.transform.position = new Vector2(startPosition + currentParallaxPositionX, desiredSprite.transform.position.y);

            if (temp > startPosition + spriteLength) startPosition += spriteLength;
            else if (temp < startPosition - spriteLength) startPosition -= spriteLength;
        }

        float CalculateParallaxEffectOffset()
        {
            return (1 - movementEffect);
        }
    }
}