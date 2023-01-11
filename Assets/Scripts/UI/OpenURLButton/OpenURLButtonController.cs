using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.OpenURLButton
{
    public class OpenURLButtonController : MonoBehaviour
    {
        [SerializeField]
        private Button buttonToInteract;

        [SerializeField] 
        private string urlToOpen;

        private void OnEnable()
        {
            buttonToInteract.onClick.AddListener(OpenURL);
        }

        private void OnDisable()
        {
            buttonToInteract.onClick.RemoveListener(OpenURL);
        }

        void OpenURL()
        {
            DoOpenURL(urlToOpen);
        }

        void DoOpenURL(string url)
        {
            Application.OpenURL(url);
        }
    }
}