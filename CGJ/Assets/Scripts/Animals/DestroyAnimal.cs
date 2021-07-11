using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGJ.Animals
{
    public class DestroyAnimal : MonoBehaviour
    {
        #region 字段

        private Vector3 screenPosistion;

        #endregion

        #region Unity回调

        private void Update()
        {
            DestroyPrefabs();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 超出范围的物体删除
        /// </summary>
        public void DestroyPrefabs()
        {
            screenPosistion = Camera.main.WorldToViewportPoint(transform.position);
            if (screenPosistion.x > -0.5f && screenPosistion.x < 1.5f && screenPosistion.y > -0.2f && screenPosistion.y < 1.2f)
            {
                return;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion
    }
}

