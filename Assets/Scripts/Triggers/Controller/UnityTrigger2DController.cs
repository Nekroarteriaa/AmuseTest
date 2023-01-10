using HelplerStaticClasses.ComparingLayerMask;
using UnityEngine;
using UnityEngine.Events;

namespace Triggers.Controller
{
    public class UnityTrigger2DController : MonoBehaviour
    {
        [SerializeField] 
        private LayerMask layerMaskToDetect;
        
        [SerializeField] 
        private UnityEvent<Collider2D> onTrigger2DEnterEvent;
        [SerializeField] 
        private UnityEvent<Collider2D> onTrigger2DStayEvent;
        [SerializeField] 
        private UnityEvent<Collider2D> onTrigger2DExitEvent;


        private void OnTriggerEnter2D(Collider2D col)
        {
            if(!ComparingLayerMaskBehaviour.AreLayerMaskEquals(layerMaskToDetect, col.gameObject.layer)) return;
            onTrigger2DEnterEvent.Invoke(col);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if(!ComparingLayerMaskBehaviour.AreLayerMaskEquals(layerMaskToDetect, other.gameObject.layer)) return;
            onTrigger2DStayEvent.Invoke(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(!ComparingLayerMaskBehaviour.AreLayerMaskEquals(layerMaskToDetect, other.gameObject.layer)) return;
            onTrigger2DExitEvent.Invoke(other);
        }
    }
}