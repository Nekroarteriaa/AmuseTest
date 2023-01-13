using ScriptableVariables.Float;
using UnityEngine;
using UnityEngine.Events;

namespace ShootingJudge.Controller
{
    public class ShootingJudgeController : MonoBehaviour
    {
        [SerializeField] 
        private ScriptableVariableFloat velocityMagnitude;

        [SerializeField] 
        private UnityEvent onNiceShotEvent;

        public void JudgeTheShot()
        {
            if(velocityMagnitude.Value is > 19 and < 23)
                onNiceShotEvent.Invoke();
        }
    }
}