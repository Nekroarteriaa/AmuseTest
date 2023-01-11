using UnityEngine;

namespace ParticleSystemMainSettings.Controller
{
    public class ParticleSystemMainSettingsController : MonoBehaviour
    {
        [SerializeField] 
        private ParticleSystem particleSystemToModify;
        
        public void SetParticleSystemLifeTime(float lifeTime)
        {
            var mainSettings = particleSystemToModify.main;
            mainSettings.startLifetime = lifeTime;
        }
    }
}