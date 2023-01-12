using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Audios.Controller
{
    public class AudioPitchController : MonoBehaviour
    {
        [SerializeField] 
        private AudioSource audioSourceToModify;

        [SerializeField] 
        private float pitchRandomnessSpectrum;

        private float originalPitch;
        private void Awake()
        {
            originalPitch = audioSourceToModify.pitch;
        }

        public void PitchAlteration()
        {
            audioSourceToModify.pitch = Random.Range(originalPitch - pitchRandomnessSpectrum, originalPitch + pitchRandomnessSpectrum);
        }
    }
}