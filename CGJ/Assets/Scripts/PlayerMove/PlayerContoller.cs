using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGJ.PlayerController
{
    public class PlayerContoller : MonoBehaviour
    {
        #region 字段

        [SerializeField] private CapsuleCollider2D coll;
        [SerializeField] private MouseInput mouseInput;

        #endregion

        #region Unity回调

        private void Awake()
        {

        }

        #endregion

        #region 方法

        /// <summary>
        /// 抛绳子
        /// </summary>
        public void ThrowRope()
        {
            if (mouseInput.mouseCondition)
            {

            }
        }

        /// <summary>
        /// 设置绳子是否可见
        /// </summary>
        public void SetRopeVisible()
        {

        }

        #endregion
    }
}

