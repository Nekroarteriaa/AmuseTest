using DG.Tweening;
using Tweeners.TweenersBase;
using UnityEngine;

namespace Tweeners.TweenersColour.Controller
{
    public class TweenerColourController : TweenerControllerBase
    {
        [SerializeField] 
        private Renderer rendererToTweenColour;

        [SerializeField] 
        private Color finalTweeningColour;

        public void DoTweenColour()
        {
            rendererToTweenColour.material.DOColor(finalTweeningColour, tweeningDuration).OnPlay(() =>
            {
                onPlayTweening.Invoke();
            }).OnComplete(() =>
            {
                onFinishTweening.Invoke();
            });
        }
    }
}