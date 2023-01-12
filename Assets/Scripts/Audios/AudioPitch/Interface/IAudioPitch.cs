using UnityEngine;

namespace Audios.AudioPitch.Interface
{
    public interface IAudioPitch
    {
        void DoPitchAlteration(AudioSource audioSource, float pitchToApply);
    }
}