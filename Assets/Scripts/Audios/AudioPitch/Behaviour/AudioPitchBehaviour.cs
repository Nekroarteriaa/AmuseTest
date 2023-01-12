using Audios.AudioPitch.Interface;
using UnityEngine;

namespace Audios.AudioPitch.Behaviour
{
    public class AudioPitchBehaviour : MonoBehaviour, IAudioPitch
    {
        public void DoPitchAlteration(AudioSource audioSource, float pitchToApply)
        {
            audioSource.pitch = pitchToApply;
        }
    }
}