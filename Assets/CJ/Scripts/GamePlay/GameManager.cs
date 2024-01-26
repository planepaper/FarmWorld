using CJ.Scripts.Common;
using CJ.Scripts.GamePlay.State;
using System;
using UnityEngine;

namespace CJ.Scripts.GamePlay
{
    public class GameManager : MonoSingleton<GameManager>
    {
        #region Game Data

        public float money;

        #endregion

        private GamePlayState _status;

        public bool isRunning => _status.GetType() == typeof(GamePlayState_Running);

        private void FixedUpdate()
        {
            if (_status != null) _status = _status.Process();
        }
    }
}
