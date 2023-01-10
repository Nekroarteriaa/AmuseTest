using Dragger.Behaviour;
using UnityEngine;

namespace Dragger.Controller
{
    [RequireComponent(typeof(DraggerBehaviour))]
    public class DraggerController : MonoBehaviour
    {
        [SerializeField] 
        private Rigidbody2D birdRigidbody2D;

        [SerializeField] 
        private float timeToReachTotalStop;
        
        [SerializeField] 
        private DraggerBehaviour groundDraggerBehaviour;

        public void ApplyDragging()
        {
            if(birdRigidbody2D.velocity == Vector2.zero) return;
            groundDraggerBehaviour.DoDrag(birdRigidbody2D, timeToReachTotalStop);
        }
        
        public void ResetDragginCounter()
        {
            groundDraggerBehaviour.StopDragging();
        }
    }
}