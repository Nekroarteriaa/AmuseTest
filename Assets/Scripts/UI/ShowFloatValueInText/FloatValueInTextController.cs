using ScriptableVariables.Float;
using TMPro;
using UnityEngine;

namespace UI.ShowFloatValueInText
{
    public class FloatValueInTextController : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI distanceAmountText;

        [SerializeField]
        private ScriptableVariableFloat floatScriptableVariable;
        
        private string format = "0.00";

        public void ShowFloatValueInText()
        {
            distanceAmountText.SetText(floatScriptableVariable.Value.ToString(format));
        }

    }
}