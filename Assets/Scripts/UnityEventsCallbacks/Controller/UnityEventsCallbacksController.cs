using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace UnityEventsCallbacks.Controller
{
    public class UnityEventsCallbacksController : MonoBehaviour
    {
        [SerializeField] 
        private UnityEvent onAwakeEvent;
        
        [SerializeField] 
        private UnityEvent onEnableEvent;

        [SerializeField] 
        private UnityEvent onStart;

        [SerializeField] 
        private UnityEvent onDisable;

        private void Awake()
        {
            onAwakeEvent.Invoke();
        }

        private void OnEnable()
        {
            StartCoroutine(wea());
        }

        private void Start()
        {
            onStart.Invoke();
        }

        private void OnDisable()
        {
            onDisable.Invoke();
        }

        IEnumerator wea()
        {
            yield return new WaitForEndOfFrame();
            onEnableEvent.Invoke();
        }
    }
}