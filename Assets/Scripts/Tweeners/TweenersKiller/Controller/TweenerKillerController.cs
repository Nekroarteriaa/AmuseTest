using DG.Tweening;
using UnityEngine;

namespace Tweeners.TweenersKiller.Controller
{
    public class TweenerKillerController : MonoBehaviour
    {
        public void KillAllTweens()
        {
            DOTween.KillAll();
        }
    }
}