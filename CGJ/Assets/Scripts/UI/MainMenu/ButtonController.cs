using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CGJ.SceneController;
using UnityEngine.Audio;

namespace CGJ.UI.MainMenu
{
    public class ButtonController : MonoBehaviour
    {
        #region 字段

        [SerializeField] private GameObject settingPanel;

        public AudioMixer Volume;

        #endregion 



        #region 方法

        /// <summary>
        /// 点击开始
        /// </summary>
        public void OnStartClick()
        {
            SceneLoader.Instance.LoadScene(1, null, null);
        }

        /// <summary>
        /// 点击设置
        /// </summary>
        public void OnSettingClick()
        {
            settingPanel.SetActive(true);
        }

        /// <summary>
        /// 点击退出
        /// </summary>
        public void OnExitClick()
        {
            Application.Quit();
        }

        /// <summary>
        /// 在设置界面点返回
        /// </summary>
        public void OnBackClick()
        {
            settingPanel.SetActive(false);
        }

        /// <summary>
        /// 音量条
        /// </summary>
        /// <param name="volume">音量大小</param>
        public void SetVolume(float volume)
        {
            Volume.SetFloat("MainVolume", volume);
        }

        #endregion 


    }

}
