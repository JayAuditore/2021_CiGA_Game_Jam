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
        [SerializeField] private Animator anim;
        [SerializeField] private GameObject lineRenderer;
        [SerializeField] private GameObject canvas;
        [SerializeField] private LineRenderer component;
        [SerializeField] private Vector3 targetPosistion;
        private Vector3 realPlayerPivot;
        private RaycastHit2D info;
        private Vector3 playerScreenPosistion;

        public LayerMask mask;

        #endregion

        #region Unity回调

        private void Update()
        {
            realPlayerPivot = new Vector3(transform.position.x - 2f, transform.position.y + 1.5f, transform.position.z);
            playerScreenPosistion = Camera.main.WorldToScreenPoint(realPlayerPivot);

            if (mouseInput.mouseCondition)
            {
                ThrowRope();
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 抛绳子
        /// </summary>
        public void ThrowRope()
        {
            PreRaycast();
            anim.SetBool("IsThrowing", true);
        }

        /// <summary>
        /// 绳子移动
        /// </summary>
        public void RopeMove()
        {
            mouseInput.mouseCondition = false;
            component.SetPosition(0, realPlayerPivot);
            component.SetPosition(1, targetPosistion);
            CalculateSpeed();
            Invoke(nameof(ResetRope), 1f);
        }

        /// <summary>
        /// 重置状态
        /// </summary>
        public void ResetRope()
        {
            anim.SetBool("IsThrowing", false);
            targetPosistion = realPlayerPivot;
            component.SetPosition(1, realPlayerPivot);
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 0f);
        }

        /// <summary>
        /// 检测是否受伤
        /// </summary>
        /// <param name="collision">相撞的动物</param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            anim.SetBool("IsHurting", true);
        }

        /// <summary>
        /// 打开游戏结束界面
        /// </summary>
        public void GameOver()
        {
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            canvas.transform.Find("GameOver").gameObject.SetActive(true);
        }

        /// <summary>
        /// 预先射出射线检测是否碰到动物
        /// </summary>
        public void PreRaycast()
        {
            info = Physics2D.Raycast(realPlayerPivot, Vector3.Normalize(mouseInput.MousePosition - realPlayerPivot), 1000f, mask);
            if (info.transform != null)
            {
                targetPosistion = info.point;
            }
            else
            {
                Vector3 _temp = Input.mousePosition;
                targetPosistion = Camera.main.ScreenToWorldPoint(_temp);
            }
        }

        /// <summary>
        /// 计算角色和动物的速度
        /// </summary>
        public void CalculateSpeed()
        {
            if (info.transform != null)
            {
                switch (info.transform.tag)
                {
                    case "Crab":
                        {
                            anim.SetBool("IsThrowing", false);
                            targetPosistion = realPlayerPivot;
                            component.SetPosition(1, realPlayerPivot);
                        }
                        break;
                    case "Elephant":
                        {
                            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(info.point.x - transform.position.x, info.point.y - transform.position.y).normalized * 5;
                        }
                        break;
                    case "Ostrich":
                        {
                            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(info.point.x - transform.position.x, info.point.y - transform.position.y).normalized * 1.5f;
                            info.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        }
                        break;
                    case "Rhinoceros":
                        {
                            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(info.point.x - transform.position.x, info.point.y - transform.position.y).normalized * 1.5f;
                            info.transform.GetComponent<Rigidbody2D>().velocity *= 1.2f;
                        }
                        break;
                    case "Turtle":
                        {
                            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(info.point.x - transform.position.x, info.point.y - transform.position.y).normalized * 1.5f;
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                return;
            }

        }

        /// <summary>
        /// 玩家出屏幕时游戏结束
        /// </summary>
        public void OnPlayerInvisible()
        {
            if (playerScreenPosistion.x > 0f && playerScreenPosistion.x < 1f && playerScreenPosistion.y > 0f && playerScreenPosistion.y < 1f)
            {
                return;
            }
            else
            {
                anim.SetBool("IsHurting", true);
            }
        }

        #endregion
    }
}

