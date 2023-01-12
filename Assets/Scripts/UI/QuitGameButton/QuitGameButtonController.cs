using UnityEngine;
using UnityEngine.UI;

namespace UI.QuitGameButton
{
    public class QuitGameButtonController : MonoBehaviour
    {
        [SerializeField] 
        private Button buttonToInteract;

        #region UnityEvents

        private void OnEnable()
        {
            buttonToInteract.onClick.AddListener(DoQuitGame);
        }

        private void OnDisable()
        {
            buttonToInteract.onClick.RemoveListener(DoQuitGame);
        }
        

        #endregion
        

        void DoQuitGame()
        {
            Application.Quit();
        }
    }
}