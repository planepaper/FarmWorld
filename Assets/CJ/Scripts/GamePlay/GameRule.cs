using CJ.Scripts.Common;
using UnityEngine;

namespace CJ.Scripts.GamePlay
{
    public class GameRule : ScriptableSingleton<GameRule>
    {
        [SerializeField] private float _stockUpdateInterval = 15f;
        public float stockUpdateInterval => _stockUpdateInterval;
    }
}
