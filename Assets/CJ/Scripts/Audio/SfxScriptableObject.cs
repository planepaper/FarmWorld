using CJ.Scripts.Common;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CJ.Scripts.Audio
{
    public enum SfxType : uint
    {
        Count,
    }

    /// <summary>
    /// Sfx Effect 정보를 담고 있는 Scriptable Object
    /// </summary>
    public class SfxScriptableObject : ScriptableSingleton<SfxScriptableObject>
    {
        [Serializable]
        public class SfxData
        {
            public SfxType type;
            public AudioClip clip;
            public float pitch;
            public float volume;
            public bool loop;
        }

        [SerializeField] private List<SfxData> _pairs;

        public SfxData GetData(SfxType type) => _pairs.Find(pair => pair.type == type);
    }
}
