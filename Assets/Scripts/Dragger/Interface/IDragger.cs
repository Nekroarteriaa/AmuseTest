using UnityEngine;

namespace Dragger.Interface
{
    public interface IDragger
    {
        void DoDrag(Rigidbody2D rigidbody2DToApplyDragging, float timeToReachTotalStop);

        void StopDragging();
    }
}