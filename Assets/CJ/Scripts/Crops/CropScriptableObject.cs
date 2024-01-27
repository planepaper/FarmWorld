using CJ.Scripts.Common;
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace CJ.Scripts.Crops
{
    public class CropScriptableObject : ScriptableSingleton<CropScriptableObject>
    {
        [FormerlySerializedAs("corps")]
        [SerializeField]
        private CropData[] crops;

        public CropData GetData(int id) => crops[id];
        public int Count => crops.Length;
    }
}
