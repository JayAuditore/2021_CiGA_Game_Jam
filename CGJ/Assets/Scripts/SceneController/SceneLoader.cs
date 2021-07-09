using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CGJ.SceneController
{
    public class SceneLoader : MonoBehaviour
    {
        #region 字段

        [SerializeField] private int Index;
        private Action<float> onPageChange;
        private Action onFinish;
        private static SceneLoader instance;

        //单例
        public static SceneLoader Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        #region Unity回调

        private void Awake()
        {
            //不销毁
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            //如果不止一个controller，抛出异常
            else if (instance != null)
            {
                throw new Exception("There's more than one scene controller. ");
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="index">要加载的场景索引号</param>
        /// <param name="onpagechange">跳转场景时候的回调函数，如果没有就null</param>
        /// <param name="onfinish">跳转结束之后的回调，如果没有就null</param>
        public void LoadScene(int index, Action<float> onpagechange, Action onfinish)
        {
            this.Index = index;
            this.onPageChange = onpagechange;
            this.onFinish = onfinish;

            //开启协程
            StartCoroutine(LoadScenes());
        }

        /// <summary>
        /// 异步加载场景
        /// </summary>
        /// <returns></returns>
        private IEnumerator LoadScenes()
        {
            yield return 0;
            //异步加载场景
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(Index);

            while (!asyncOperation.isDone)
            {
                yield return 0;
                //传递异步加载进度，如果完成，progress=1
                onPageChange?.Invoke(asyncOperation.progress);
            }

            yield return new WaitForSeconds(2f);
            //在完成加载之后的操作
            onFinish?.Invoke();
        }

        #endregion

    }
}

