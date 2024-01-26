using UnityEngine;

namespace CJ.Scripts.GamePlay.State
{
    /// <summary>
    /// 게임 플레이 상태
    /// </summary>
    public class GamePlayState_Running : GamePlayState
    {
        /// <summary>
        /// 게임 플레이 상태에 들어온 이후 지난 시간
        /// </summary>
        private float playTime = 0;

        protected override void Update()
        {
            playTime += Time.fixedDeltaTime;
        }
    }
}
