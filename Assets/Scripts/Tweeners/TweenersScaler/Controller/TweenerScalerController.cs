using DG.Tweening;
using Tweeners.TweenersBase;
using UnityEngine;

namespace Tweeners.TweenersScaler.Controller
{
    public class TweenerScalerController : TweenerControllerBase
    {
        [SerializeField] 
        private Transform transformToScale;

        [SerializeField]
        private float scaleAmount;

        [SerializeField] 
        private Ease scaleEase;

        [SerializeField] 
        private float delayDuration;
        

        public void ScaleTransform()
        {
            transformToScale.DOScale(scaleAmount, tweeningDuration).SetEase(scaleEase).SetDelay(delayDuration).OnPlay(() =>
            {
                onPlayTweening.Invoke();
            }).OnComplete(() =>
            {
                onFinishTweening.Invoke();
            });
        }
    }
}