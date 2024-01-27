using CJ.Scripts.Common;
using UnityEngine;

namespace CJ.Scripts.GamePlay
{
    public class GameRule : ScriptableSingleton<GameRule>
    {
        [Header("Game System")]
        [SerializeField] private float _gamePlayTime = 5f * 60f;
        public float gamePlayTime => _gamePlayTime;

        [SerializeField] private float _stockUpdateInterval = 15f;
        public float stockUpdateInterval => _stockUpdateInterval;

        [SerializeField] private float _maxInventorySlot = 5f * 60f;
        public float maxInventorySlot => _maxInventorySlot;
    }
}
