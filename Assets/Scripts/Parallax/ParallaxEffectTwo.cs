using System;
using ScriptableVariables.Float;
using UnityEngine;

namespace Parallax
{
    public class ParallaxEffectTwo : MonoBehaviour
    {
        [SerializeField] 
        private Vector2 offset;

        [SerializeField] 
        private ScriptableVariableFloat velocityScriptableVariable;

        [SerializeField] 
        private bool isPlayingParallaxEffect;
        private Material currentMaterial;

        private void Awake()
        {
            currentMaterial = GetComponent<Renderer>().material;
        }

        private void Update()
        {
            if(!isPlayingParallaxEffect) return;
            currentMaterial.mainTextureOffset += offset * (velocityScriptableVariable.Value * Time.deltaTime);
        }

        public void PlayEffect()
        {
            isPlayingParallaxEffect = true;
        }

        public void StopEffect()
        {
            isPlayingParallaxEffect = false;
        }
    }
}