using HelplerStaticClasses.ComparingLayerMask;
using UnityEngine;
using UnityEngine.Events;

namespace Collisions.UnityCollision2DController
{
    public class UnityCollider2DCollisionController : MonoBehaviour
    {
        [SerializeField] 
        private LayerMask layerMaskToDetect;
        
        [SerializeField]
        private UnityEvent<Collision2D> onCollisionEnter2DEvent;
        [SerializeField]
        private UnityEvent<Collision2D> onCollisionStay2DEvent;
        [SerializeField]
        private UnityEvent<Collision2D> onCollisionExit2DEvent;
        

        private void OnCollisionEnter2D(Collision2D col)
        {
            if(!ComparingLayerMaskBehaviour.AreLayerMaskEquals(layerMaskToDetect, col.gameObject.layer)) return;
            onCollisionEnter2DEvent.Invoke(col);
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if(!ComparingLayerMaskBehaviour.AreLayerMaskEquals(layerMaskToDetect, collision.gameObject.layer)) return;
            onCollisionStay2DEvent.Invoke(collision);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if(!ComparingLayerMaskBehaviour.AreLayerMaskEquals(layerMaskToDetect, other.gameObject.layer)) return;
            onCollisionExit2DEvent.Invoke(other);
        }
    }
}