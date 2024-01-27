using CJ.Scripts.Crops;
using CJ.Scripts.StockMarket;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CJ.Scripts.GamePlay.State
{
    /// <summary>
    /// 게임 플레이 상태
    /// </summary>
    public class GamePlayState_Running : GamePlayState
    {
        private float _playTime = 0;                // 게임 플레이 상태에 들어온 이후 지난 시간
        private float _nextStockUpdateTime = 15;    // 다음 주식 시장 업데이트 시간

        public float playTime => _playTime;

        protected override void Enter()
        {
            base.Enter();

            _nextStockUpdateTime = GameRule.Instance.stockUpdateInterval;
        }

        protected override void Update()
        {
            _playTime += Time.fixedDeltaTime;

            if (_nextStockUpdateTime < _playTime)
            {
                _nextStockUpdateTime += GameRule.Instance.stockUpdateInterval;

                UpdateStockMarket();
            }

            if (_playTime >= GameRule.Instance.gamePlayTime)
            {
                nextStatus = new GamePlayState_Finish();
                nextEvent = Event.Exit;
            }
        }

        private void UpdateStockMarket()
        {
            foreach (var pair in GameManager.Instance.stockMarket)
            {
                var stock = pair.Value;
                var data = CropScriptableObject.Instance.GetData(pair.Key);

                stock.lastPriceStatus = (PriceStatus) Random.Range(0, (int) PriceStatus.Count);
                switch (stock.lastPriceStatus)
                {
                    case PriceStatus.Up:
                        stock.price += Random.Range(0, data.randomGap);
                        break;
                    case PriceStatus.Down:
                        stock.price -= Random.Range(0, data.randomGap);
                        break;
                }

                stock.price = Mathf.Max(stock.price, data.minValue);
                stock.price = Mathf.Min(stock.price, data.maxValue);
            }

            GameManager.Instance.OnStockMarketUpdated?.Invoke();
        }
    }
}
