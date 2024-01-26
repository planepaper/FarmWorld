using UnityEngine;

namespace CJ.Scripts.GamePlay.State
{
    /// <summary>
    /// 게임 플레이 상태
    /// </summary>
    public class GamePlayState_Running : GamePlayState
    {
        private float _playTime = 0;                // 게임 플레이 상태에 들어온 이후 지난 시간
        private float _nextStockUpdateTime = 15;    // 다음 주식 시장 업데이트 시간

        protected override void Update()
        {
            _playTime += Time.fixedDeltaTime;

            if (Mathf.Abs(_playTime - _nextStockUpdateTime) < float.Epsilon)
            {
                // TODO: 주식 업데이트
                _nextStockUpdateTime += GameRule.Instance.stockUpdateInterval;
            }

            if (_playTime >= GameRule.Instance.gamePlayTime)
            {
                nextStatus = new GamePlayState_Finish();
                nextEvent = Event.Exit;
            }
        }
    }
}
