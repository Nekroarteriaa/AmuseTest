using System.Threading;
using System.Threading.Tasks;
using Async.Waiter.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace Async.Waiter.Behaviour
{
    public class AwaitAndTriggerEventBehaviour : MonoBehaviour, IWaiter
    {
        public UnityEvent OnFinishWaiting => onFinishWaiting;
        
        public UnityEvent OnWaitingCancelled => onWaitingCancelled;
        
        public CancellationTokenSource CancellationWaitingTokenSource => cancellationTokenSource;

        [SerializeField]
        private int timeToAwaitInMilliseconds;
        
        [SerializeField] 
        private UnityEvent onFinishWaiting;
        
        [SerializeField] 
        private UnityEvent onWaitingCancelled;

        private CancellationTokenSource cancellationTokenSource;

        #region UnityEvents

        private void Awake()
        {
            cancellationTokenSource = new CancellationTokenSource();
        }
        
        #endregion

        public void DoWait()
        {
            _ = AwaitAndTrigger(timeToAwaitInMilliseconds, CancellationWaitingTokenSource.Token);
        }

        async Task AwaitAndTrigger(int timeToAwait, CancellationToken cancellationToken)
        {
            await Task.Delay(timeToAwait, cancellationToken);
            if (cancellationToken.IsCancellationRequested)
            {
                onWaitingCancelled.Invoke();
            }
            cancellationToken.ThrowIfCancellationRequested();
            onFinishWaiting.Invoke();
            
        }
    }
}