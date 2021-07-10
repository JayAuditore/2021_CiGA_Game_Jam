using CGJ.PlayerController;
using CGJ.SceneController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace CGJ.UI.PauseMenuController
{
    public class PauseMenuController : MonoBehaviour
    {
        #region 字段

        public AudioMixer Volume;
        public MouseInput Param;

        #endregion

        #region 方法

        /// <summary>
        /// 点击返回主菜单
        /// </summary>
        public void OnBackToMainClick()
        {
            SceneLoader.Instance.LoadScene(0, null, null);
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

