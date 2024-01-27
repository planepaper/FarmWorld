using TMPro;
using UnityEngine;

namespace CJ.Scripts.GamePlay.UI
{
    public class CropCount : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI totalCount;
        [SerializeField] private TextMeshProUGUI[] cropCounts;

        private void Awake()
        {
            GameManager.Instance.OnCropCountUpdated += OnCropCountUpdated;
        }

        private void OnCropCountUpdated(int cropIndex)
        {
            var totalCropCount = GameManager.Instance.totalCropCounts;
            var cropCount = GameManager.Instance.cropCounts[cropIndex];

            totalCount.text = totalCropCount.ToString();
            cropCounts[cropIndex].text = cropCount.ToString();
        }
    }
}
