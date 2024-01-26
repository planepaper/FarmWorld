using UnityEngine;

namespace CJ.Scripts.GamePlay.State
{
    /// <summary>
    /// 게임이 마무리 되는 상태
    /// </summary>
    public class GamePlayState_Ready : GamePlayState
    {
        protected override void Enter()
        {
            // TODO: Play animation and something between init and play

            // 일단은 바로 게임 플레이로 이동
            nextStatus = new GamePlayState_Running();
            nextEvent = Event.Exit;
        }
    }
}
