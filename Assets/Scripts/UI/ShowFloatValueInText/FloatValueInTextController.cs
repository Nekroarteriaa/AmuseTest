using DG.Tweening;
using ScriptableVariables.Float;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI.ShowFloatValueInText
{
    public class FloatValueInTextController : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI distanceAmountText;

        [SerializeField]
        private ScriptableVariableFloat floatScriptableVariable;

        [SerializeField] 
        private UnityEvent onNewRecordCountingBegins;
        
        [SerializeField] 
        private UnityEvent onNewRecordAdditionMethodFinished;
        
        private string format = "0.00";

        public void ShowFloatValueInText()
        {
            distanceAmountText.SetText(floatScriptableVariable.Value.ToString(format));
        }

        public void ShowScoreInAdditionMethod(float timeToReachRecord)
        {
            float tempFloat = 0;
            DOTween.To(() => tempFloat, x => tempFloat = x, floatScriptableVariable.Value, timeToReachRecord).OnUpdate(
                () =>
                {
                    distanceAmountText.SetText(tempFloat.ToString(format));
                }).OnPlay(() =>
            {
                onNewRecordCountingBegins.Invoke();
            }).OnComplete(() =>
            {
                onNewRecordAdditionMethodFinished.Invoke();
            });
        }

    }
}