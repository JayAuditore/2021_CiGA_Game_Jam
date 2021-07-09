using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGJ.PlayerController
{
    public class MouseInput : MonoBehaviour
    {
        #region 字段

        public int pauseCondition = 1;
        public bool mouseCondition;
        public Vector3 MousePosition;
        public GameObject PauseMenu;

        #endregion

        #region Unity回调

        private void Update()
        {
            GetMouseCondition();
            GetMousePosition();
            SetTimeScale();
            OpenPauseMenu();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 判断是否暂停
        /// </summary>
        public void SetTimeScale()
        {
            int temp = this.pauseCondition;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                this.pauseCondition = -temp;
            }
        }

        /// <summary>
        /// 打开暂停菜单
        /// </summary>
        public void OpenPauseMenu()
        {
            if (pauseCondition < 0)
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
            }
            else
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }

        /// <summary>
        /// 获取鼠标是否按下的状态
        /// </summary>
        public void GetMouseCondition()
        {
            mouseCondition = Input.GetMouseButtonDown(0);
        }

        /// <summary>
        /// 获取鼠标位置
        /// </summary>
        public void GetMousePosition()
        {
            MousePosition = Input.mousePosition;
        }

        #endregion

    }

}
