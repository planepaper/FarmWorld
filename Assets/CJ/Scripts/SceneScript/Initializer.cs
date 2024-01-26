
using CJ.Scripts.Audio;
using CJ.Scripts.Common;
using UnityEngine;

namespace CJ.Scripts.SceneScript
{
    public class Initializer : MonoBehaviour
    {
        void Start()
        {
            // TODO: Initialize data
            DontDestroyOnLoad(SfxManager.Instance.gameObject);
            DontDestroyOnLoad(BgmManager.Instance.gameObject);

            SceneManager.LoadScene(SceneType.MainMenu);
        }
    }
}
