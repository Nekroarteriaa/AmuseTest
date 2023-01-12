using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

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

        [SerializeField] 
        private UnityEvent onShakingTransform;

        [SerializeField]
        private UnityEvent onShakingFinished;

        public void Shake()
        {
            transformToShake.DOShakePosition(shakeDuration, shakeStrenght).SetEase(shakeEase).OnPlay(() =>
            {
                onShakingTransform.Invoke();
            }).OnComplete(() =>
            {
                onShakingFinished.Invoke();
            });
        }

        public void Shake(float strength)
        {
            transformToShake.DOShakePosition(shakeDuration, strength).SetEase(shakeEase);
        }
    }
}