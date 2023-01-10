using System;
using Cinemachine;
using UnityEngine;

namespace AspectRatioFixer
{
    public class AspectRatioFixerController : MonoBehaviour
    {
        [SerializeField] 
        private SpriteRenderer resolutionTargetSize;

        [SerializeField] 
        private CinemachineVirtualCamera virtualCamera;

        private void Awake()
        {
            float screenRatio = (float)Screen.width / (float)Screen.height;
            float targetRatio = resolutionTargetSize.bounds.size.x / resolutionTargetSize.bounds.size.y;

            if (screenRatio >= targetRatio)
            {
                virtualCamera.m_Lens.OrthographicSize = resolutionTargetSize.bounds.size.y / 2;
            }
            else
            {
                float differenceInSize = targetRatio / screenRatio;
                virtualCamera.m_Lens.OrthographicSize = resolutionTargetSize.bounds.size.y / 2 * differenceInSize;
            }
        }
    }
}