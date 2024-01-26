using CJ.Scripts.Common;
using CJ.Scripts.GamePlay.State;
using System;
using UnityEngine;

namespace CJ.Scripts.GamePlay
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private GamePlayState _status;

        private void FixedUpdate()
        {
            if (_status != null) _status = _status.Process();
        }
    }
}
