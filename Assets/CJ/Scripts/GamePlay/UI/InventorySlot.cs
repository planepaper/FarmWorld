using CJ.Scripts.Crops;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CJ.Scripts.GamePlay.UI
{
    public class InventorySlot : MonoBehaviour
    {
        [Header("MetaData")]
        public int slot;

        [Header("UI")]
        public TMP_Text name;
        public Image image;
        public Animator animator;

        private static int IdleAnim = Animator.StringToHash("Idle");

        private void Start()
        {
            GameManager.Instance.OnInventorySlotUpdated += OnInventoryUpdated;
            UpdateUI();
        }

        /// <summary>
        /// 변경된 인벤토리 슬롯이 연결된 슬롯이라면 UI를 업데이트 한다
        /// </summary>
        /// <param name="i"></param>
        /// <param name="data"></param>
        private void OnInventoryUpdated(int i, InventorySlotData data)
        {
            if (i >= 0 && i != slot) { return; }
            UpdateUI();
        }

        public void UpdateUI()
        {
            var data = GameManager.Instance.inventory[slot].data;
            if (data == null)
            {
                name.text = "";
                image.color = new Color(0, 0, 0, 0);
                animator.runtimeAnimatorController = null;
            }
            else
            {
                name.text = data.name;
                image.color = Color.white;
                animator.runtimeAnimatorController = data.animController;
                animator.Play(IdleAnim);
            }
        }
    }
}
