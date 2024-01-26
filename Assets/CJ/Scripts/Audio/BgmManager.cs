
using CJ.Scripts.Common;
using System;
using UnityEngine;

namespace CJ.Scripts.Audio
{
    public class BgmManager : MonoSingleton<BgmManager>
    {
        [SerializeField]
        private AudioSource _bgmSource;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void Play(BgmType type)
        {
            var data = BgmScriptableObject.Instance.GetData(type);

            AudioSource source = _bgmSource;
            source.Stop();

            source.loop = data.loop;
            source.pitch = data.pitch;
            source.volume = data.volume;
            source.clip = data.clip;
            source.Play();
        }
    }
}
