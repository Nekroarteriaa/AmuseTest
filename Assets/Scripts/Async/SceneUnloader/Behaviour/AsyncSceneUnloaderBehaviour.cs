using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Async.SceneUnloader.Behaviour
{
    public class AsyncSceneUnloaderBehaviour : MonoBehaviour
    {
        [SerializeField] 
        private string sceneName;

        [SerializeField] 
        private UnloadSceneOptions unloadSceneOptions;
        
        [SerializeField] 
        private UnityEvent onSceneUnloaded;
        
        public void DoAsyncUnloadScene()
        {
            var cts = new CancellationTokenSource();
            _ = UnloadScene(sceneName, unloadSceneOptions, cts.Token);
        }

        public void UnloadSceneByCoroutine(float timeToWait)
        {
            StartCoroutine(DoUnloadSceneByCoroutine(timeToWait));
        }

        IEnumerator DoUnloadSceneByCoroutine(float timeToWait)
        {
            yield return new WaitForSeconds(timeToWait);
            SceneManager.UnloadSceneAsync(sceneName, unloadSceneOptions);
            onSceneUnloaded.Invoke();
        }
        
        async Task UnloadScene(string sceneName, UnloadSceneOptions unloadSceneOptions , CancellationToken cts)
        {
            await AsyncUnloadScene(sceneName, unloadSceneOptions, cts);
            onSceneUnloaded.Invoke();
        }

        Task AsyncUnloadScene(string sceneName, UnloadSceneOptions unloadSceneOptions,CancellationToken token)
        {
            var operation = SceneManager.UnloadSceneAsync(sceneName, unloadSceneOptions);
            while (true)
            {
                token.ThrowIfCancellationRequested();
                if (token.IsCancellationRequested)
                    return Task.CompletedTask;               
                if (operation.progress>=0.9f)
                    break;              
            }

            return Task.CompletedTask;
        }
    }
}