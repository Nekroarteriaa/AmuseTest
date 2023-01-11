using System.Threading;
using UnityEngine.Events;

namespace Async.Waiter.Interface
{
    public interface IWaiter
    {
        UnityEvent OnFinishWaiting { get; }
        UnityEvent OnWaitingCancelled { get; }
        CancellationTokenSource CancellationWaitingTokenSource { get; }
        void DoWait();
    }
}