using System;
using UnityEngine;

namespace CJ.Scripts.Crops
{
    [Serializable]
    public class CorpData
    {
        [Header("MetaData")]
        public int id;
        public string name;
        public float initValue;
        public float minValue;
        public float minEscapeTime;
        public float maxEscapeTime;

        [Header("Graphics Data")]
        public RuntimeAnimatorController animController;
    }
}
