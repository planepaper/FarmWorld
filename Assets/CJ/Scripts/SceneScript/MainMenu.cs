
using CJ.Scripts.Audio;
using CJ.Scripts.Common;
using System;
using UnityEngine;

namespace CJ.Scripts.SceneScript
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _howToPlayObject;
        [SerializeField] private GameObject _creditObject;

        private void Awake()
        {
            BgmManager.Instance.Play(BgmType.Main);
        }

        public void HowToPlayOnOff(bool forward)
        {
            _howToPlayObject.SetActive(forward);

            if (forward)
            {
                SfxManager.Instance.Play(SfxType.Button);
            }
        }

        public void PlayGame()
        {
            SfxManager.Instance.Play(SfxType.Button);
            SceneManager.LoadScene(SceneType.InGame);
        }

        public void CreditOnOff(bool forward)
        {
            _creditObject.SetActive(forward);

            if (forward)
            {
                SfxManager.Instance.Play(SfxType.Button);
            }
        }
    }
}
