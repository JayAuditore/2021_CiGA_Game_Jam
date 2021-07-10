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
            SetTimeScale();
            OpenPauseMenu();
            GetMousePosition();
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
        /// 获取鼠标位置
        /// </summary>
        public void GetMousePosition()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 _temp = Input.mousePosition;
                MousePosition = Camera.main.ScreenToWorldPoint(_temp);
                mouseCondition = true;
            }
        }

        #endregion

    }

}
