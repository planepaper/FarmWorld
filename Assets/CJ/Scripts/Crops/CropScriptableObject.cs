using CJ.Scripts.Common;
using System;
using UnityEngine;

namespace CJ.Scripts.Crops
{
    public class CropScriptableObject : ScriptableSingleton<CropScriptableObject>
    {
        [SerializeField]
        private CorpData[] corps;

        public CorpData GetData(int id) => corps[id];
    }
}
