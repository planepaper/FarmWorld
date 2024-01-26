
using CJ.Scripts.Common;
using UnityEngine;

namespace CJ.Scripts.SceneScript
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _creditObject;

        public void PlayGame()
        {
            SceneManager.LoadScene(SceneType.InGame);
        }

        public void CreditOnOff(bool forward)
        {
            _creditObject.SetActive(forward);
        }
    }
}
