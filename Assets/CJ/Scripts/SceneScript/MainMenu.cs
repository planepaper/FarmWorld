
using CJ.Scripts.Audio;
using CJ.Scripts.Common;
using System;
using UnityEngine;

namespace CJ.Scripts.SceneScript
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject[] _howToPlayObject;
        [SerializeField] private GameObject _creditObject;

        private int currentHowToPlay = 0;

        private void Awake()
        {
            BgmManager.Instance.Play(BgmType.Main);
        }

        public void HowToPlayOnOff(bool forward)
        {
            SfxManager.Instance.Play(SfxType.Button);

            if (currentHowToPlay >= _howToPlayObject.Length)
            {
                SceneManager.LoadScene(SceneType.InGame);
                return;
            }

            _howToPlayObject[currentHowToPlay].SetActive(false);
            _howToPlayObject[currentHowToPlay++].SetActive(forward);

            if (forward)
            {
                SfxManager.Instance.Play(SfxType.Button);
            }
            else
            {
                currentHowToPlay = 0;
            }
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
