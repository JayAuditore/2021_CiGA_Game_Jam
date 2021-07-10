using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CGJ.SceneController;

namespace CGJ.UI.GameOverMenu
{
    public class GameOverMenu : MonoBehaviour
    {

        /// <summary>
        /// 回到主菜单
        /// </summary>
        public void OnBackToMainClick()
        {
            SceneLoader.Instance.LoadScene(0, null, null);
        }

        /// <summary>
        /// 重新加载场景
        /// </summary>
        public void OnRestartClick()
        {
            SceneLoader.Instance.LoadScene(1, null, null);
        }
    }
}

