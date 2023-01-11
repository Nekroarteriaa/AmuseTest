using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Async.SceneLoader.Behaviour
{
    public class AsyncSceneLoaderBehaviour : MonoBehaviour
    {
        [SerializeField] 
        private string sceneName;

        [SerializeField] 
        private LoadSceneMode loadSceneMode;
        
        [SerializeField] 
        private UnityEvent onSceneLoaded;
        
        public void DoAsyncLoadScene()
        {
            var cts = new CancellationTokenSource();
            _ = LoadScene(sceneName, loadSceneMode, cts.Token);
        }
        
        async Task LoadScene(string sceneName, LoadSceneMode loadSceneMode , CancellationToken cts)
        {
            await AsyncLoadScene(sceneName, loadSceneMode, cts);
            onSceneLoaded.Invoke();
        }

        Task AsyncLoadScene(string sceneName, LoadSceneMode loadSceneMode,CancellationToken token)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
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