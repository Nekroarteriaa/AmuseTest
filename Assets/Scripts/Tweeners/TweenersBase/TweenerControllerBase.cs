using UnityEngine;
using UnityEngine.Events;

namespace Tweeners.TweenersBase
{
    public abstract class TweenerControllerBase : MonoBehaviour
    {
        [SerializeField]
        protected float tweeningDuration;
        
        [SerializeField] 
        protected UnityEvent onPlayTweening;

        [SerializeField]
        protected UnityEvent onFinishTweening;
    }
}