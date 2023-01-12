using System;
using Audios.AudioPitch.Behaviour;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Audios.Controller
{
    [RequireComponent(typeof(AudioPitchBehaviour))]
    public class AudioPitchController : MonoBehaviour
    {
        [SerializeField] 
        private AudioSource audioSourceToModify;

        [SerializeField] 
        private float pitchRandomnessSpectrum;

        [SerializeField] 
        private AudioPitchBehaviour audioPitchBehaviour;

        private float originalPitch;
        private void Awake()
        {
            originalPitch = audioSourceToModify.pitch;
        }

        public void PitchAlteration()
        {
            audioPitchBehaviour.DoPitchAlteration(audioSourceToModify, Random.Range(originalPitch - pitchRandomnessSpectrum, originalPitch + pitchRandomnessSpectrum));
        }
    }
}