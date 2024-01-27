using System;
using UnityEngine;

namespace CJ.Scripts.Crops
{
    [Serializable]
    public class CropData
    {
        [Header("MetaData")]
        public int id;
        public string name;
        public int initValue;
        public int minValue;
        public int maxValue;
        public int minEscapeTime;
        public int maxEscapeTime;
        public int maximumSpawnCount;

        [Header("Graphics Data")]
        public Sprite icon;
        public RuntimeAnimatorController animController;
    }
}
