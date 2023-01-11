using System.Globalization;
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

        public void ShowFloatValueInText()
        {
            distanceAmountText.SetText(floatScriptableVariable.Value.ToString(CultureInfo.CurrentCulture));
        }

    }
}