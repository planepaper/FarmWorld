
using CJ.Scripts.Common;
using UnityEngine;

namespace CJ.Scripts.SceneScript
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _howToPlayObject;
        [SerializeField] private GameObject _creditObject;

        public void HowToPlayOnOff(bool forward)
        {
            _howToPlayObject.SetActive(forward);
        }

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
