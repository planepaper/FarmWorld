using CJ.Scripts.Common;
using CJ.Scripts.Crops;
using CJ.Scripts.GamePlay.State;
using CJ.Scripts.StockMarket;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CJ.Scripts.GamePlay
{
    public class InventorySlotData
    {
        public CropData data;
        public GameObject go;
    }

    public class GameManager : MonoSingleton<GameManager>
    {
        #region Game Data

        public float money;
        public List<InventorySlotData> inventory = new List<InventorySlotData>();
        public Dictionary<int, StockMarketData> stockMarket = new Dictionary<int, StockMarketData>();

        #endregion

        #region Events

        public delegate void InventorySlotUpdated(int slot, InventorySlotData data);
        public InventorySlotUpdated OnInventorySlotUpdated;

        public delegate void StockMarketUpdated();
        public StockMarketUpdated OnStockMarketUpdated;

        #endregion

        private GamePlayState _status = new GamePlayState_Init();
        public GamePlayState state => _status;

        public bool isRunning => _status.GetType() == typeof(GamePlayState_Running);

        private void Awake()
        {
            // 인벤토리에 비어있는 정보 입력
            for (var i = 0; i < GameRule.Instance.maxInventorySlot; ++i)
            {
                inventory.Add(new InventorySlotData() { data = null, go = null });
            }
        }

        private void Start()
        {
            money = 0;
        }

        private void FixedUpdate()
        {
            if (_status != null) _status = _status.Process();
        }

        public bool TryCatchCrop(int id, GameObject go)
        {
            var (slot, idx) = GetEmptySlot();
            if (slot == null)
            {
                return false;
            }

            slot.data = CropScriptableObject.Instance.GetData(id);
            slot.go = go;

            OnInventorySlotUpdated?.Invoke(idx, slot);

            return true;
        }

        public GameObject TryUnCatchCrops()
        {
            var slot = GetFirstFilledSlot();
            if (slot == null)
            {
                return null;
            }

            var go = slot.go;

            // 첫번째 거를 빈 상태로 만들고 맨 뒤로 이동시킴
            slot.data = null;
            slot.go = null;

            inventory.RemoveAt(0);
            inventory.Add(slot);

            OnInventorySlotUpdated?.Invoke(-1, slot);

            return go;
        }

        private (InventorySlotData, int) GetEmptySlot()
        {
            for (var i = 0; i < inventory.Count; i++)
            {
                var slot = inventory[i];
                if (slot.data == null)
                {
                    return (slot, i);
                }
            }

            return (null, -1);
        }

        private InventorySlotData GetFirstFilledSlot()
        {
            foreach (var slot in inventory)
            {
                if (slot.data != null)
                {
                    return slot;
                }
            }

            return null;
        }

        public void SellInventoryCrops()
        {
            money += SumUpInventory();
            FlushInventory();
        }

        private int SumUpInventory()
        {
            int sum = 0;
            foreach (var slot in inventory)
            {
                if (slot.data != null)
                {
                    sum += stockMarket[slot.data.id].price;
                }
            }
            return sum;
        }

        private void FlushInventory()
        {
            foreach (var slot in inventory)
            {
                slot.data = null;
                slot.go = null;
            }
            OnInventorySlotUpdated?.Invoke(-1, null);
        }
    }
}
