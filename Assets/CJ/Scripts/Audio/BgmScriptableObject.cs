
using CJ.Scripts.Common;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CJ.Scripts.Audio
{
    public enum BgmType : uint
    {
        Count
    }

    /// <summary>
    /// BGM 정보를 담고 있는 Scriptable Object
    /// </summary>
    public class BgmScriptableObject : ScriptableSingleton<BgmScriptableObject>
    {
        [Serializable]
        public class BgmData
        {
            public BgmType type;
            public AudioClip clip;
            public float pitch;
            public float volume;
            public bool loop;
        }

        [SerializeField] private List<BgmData> _pairs;

        public BgmData GetData(BgmType type) => _pairs.Find(pair => pair.type == type);
    }
}
