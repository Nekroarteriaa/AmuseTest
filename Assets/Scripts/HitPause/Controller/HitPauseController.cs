using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace HitPause.Controller
{
    public class HitPauseController : MonoBehaviour
    {
        [SerializeField] 
        private float pauseDuration;

        private bool isFrozen;
        private float originalTimeScale;

        public void ApplyHitPause()
        {
            // if(isFrozen) return;
            // originalTimeScale = Time.timeScale;
            // StartCoroutine(DoApplyHitPause());

            if(isFrozen) return;
            _ = DoHitPause();
        }

        // IEnumerator DoApplyHitPause()
        // {
        //     isFrozen = true;
        //     Time.timeScale = 0;
        //
        //     yield return new WaitForSecondsRealtime(pauseDuration);
        //
        //     Time.timeScale = originalTimeScale;
        //     isFrozen = false;
        // }

        async Task DoHitPause()
        {
            _ = FreezeTime();
            await Task.Delay(500);
            _ = UnFreezeTime();
        }

        Task FreezeTime()
        {
            isFrozen = true;
            Time.timeScale = 0;
            return Task.CompletedTask;
        }

        Task UnFreezeTime()
        {
            isFrozen = false;
            Time.timeScale = 1;
            return Task.CompletedTask;
        }
    }
}