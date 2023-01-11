using DG.Tweening;
using UnityEngine;

namespace TweenersManager
{
    public class TweenerManager : MonoBehaviour
    {
        public void KillAllTweens()
        {
            DOTween.KillAll();
        }
    }
}