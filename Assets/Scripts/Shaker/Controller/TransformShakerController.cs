using DG.Tweening;
using UnityEngine;

namespace Shaker.Controller
{
    public class TransformShakerController : MonoBehaviour
    {
        [SerializeField]
        private Transform transformToShake;

        [SerializeField] 
        private float shakeDuration;

        [SerializeField] 
        private float shakeStrenght;

        [SerializeField] 
        private Ease shakeEase;

        public void Shake()
        {
            transformToShake.DOShakePosition(shakeDuration, shakeStrenght).SetEase(shakeEase);
        }

        public void Shake(float strength)
        {
            transformToShake.DOShakePosition(shakeDuration, strength).SetEase(shakeEase);
        }
    }
}