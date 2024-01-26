using CJ.Scripts.Common;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CJ.Scripts.Audio
{
    public class SfxManager : MonoSingleton<SfxManager>
    {
        [SerializeField] private List<AudioSource> _audioSources;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void Play(SfxType type)
        {
            var data = SfxScriptableObject.Instance.GetData(type);

            AudioSource source = null;
            foreach (var audioSource in _audioSources)
            {
                if (!audioSource.isPlaying)
                {
                    source = audioSource;
                    break;
                }
            }

            if (source == null)
            {
                source = _audioSources[0];
                source.Stop();
            }

            source.pitch = data.pitch;
            source.volume = data.volume;
            source.loop = data.loop;
            source.PlayOneShot(data.clip);
        }
    }
}
