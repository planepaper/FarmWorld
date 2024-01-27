using CJ.Scripts.Crops;
using CJ.Scripts.StockMarket;
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
            // TODO: 데이터 초기화

            for (var i = 0; i < CropScriptableObject.Instance.Count; ++i)
            {
                var cropData = CropScriptableObject.Instance.GetData(i);
                var stockData = new StockMarketData
                {
                    price = cropData.initValue,
                    lastPriceStatus = PriceStatus.None
                };

                GameManager.Instance.stockMarket.Add(cropData.id, stockData);
            }

            GameManager.Instance.OnStockMarketUpdated();

            // TODO: 농작물 랜덤 위치 생성

            int loopCount = 0;
            while (VegetableSpawner.Instance.SpawnVegetable() != null && loopCount < 200)
            {
                loopCount++;
            }

            if (loopCount == 200)
            {
                Debug.LogError("Failed to spawn vegetable!");
            }

            // 초기화 이후에는 바로 Ready 상태로 이동
            nextStatus = new GamePlayState_Ready();
            nextEvent = Event.Exit;
        }
    }
}
