using Dragger.Interface;
using UnityEngine;

namespace Dragger.Behaviour
{
    public class DraggerBehaviour : MonoBehaviour, IDragger
    {
        private float currentHittingTime = 0;

        public void DoDrag(Rigidbody2D rigidbody2DToApplyDragging, float timeToReachTotalStop)
        {
            currentHittingTime += Time.deltaTime;
            if(currentHittingTime < timeToReachTotalStop) return;
            rigidbody2DToApplyDragging.velocity = Vector2.zero;
            rigidbody2DToApplyDragging.angularVelocity = 0;
        }

        public void StopDragging()
        {
            currentHittingTime = 0;
        }
    }
}