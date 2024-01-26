using UnityEngine;

namespace CJ.Scripts.GamePlay.State
{
    /// <summary>
    /// 게임 초기화가 진행 되는 상태
    /// </summary>
    public class GamePlayState_Init : GamePlayState
    {
        protected override void Enter()
        {
            // TODO: Init Data

            // 초기화 이후에는 바로 Ready 상태로 이동
            nextStatus = new GamePlayState_Ready();
            nextEvent = Event.Exit;
        }
    }
}
