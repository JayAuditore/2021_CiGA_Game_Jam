using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGJ.Animals
{
    public class AnimalLoader : MonoBehaviour
    {
        #region 字段

        public Transform TopPoint;
        public Transform BottomPoint;
        public Transform LeftPoint;
        public Transform RightPoint;

        [SerializeField] private float timeSpan;
        [SerializeField] private string animalType;
        private float timer;

        #endregion

        #region

        private void FixedUpdate()
        {
            LoadAnimal();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 加载动物，给定初始位置和初始速度
        /// </summary>
        /// <returns>动物</returns>
        public GameObject LoadAnimalPrefab()
        {
            switch (CalculateAnimalType())
            {
                case 0: animalType = "Elephant"; break;
                case 1: animalType = "Ostrich"; break;
                case 2: animalType = "Crab"; break;
                case 3: animalType = "Rhinoceros"; break;
                case 4: animalType = "Turtle"; break;
                default:
                    break;
            }

            GameObject _animal = Resources.Load<GameObject>("Prefabs/" + animalType);
            GameObject _temp = Instantiate<GameObject>(_animal);
            switch (CalculateLoadPoint())
            {
                case 0: _animal.transform.position = TopPoint.position; break;
                case 1: _animal.transform.position = BottomPoint.position; break;
                case 2: _animal.transform.position = LeftPoint.position; break;
                case 3: _animal.transform.position = RightPoint.position; break;
                default:
                    break;
            }
            _temp.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-8f, 8f), Random.Range(-0.4f, 0.4f));

            if (_temp.GetComponent<Rigidbody2D>().velocity.x >= 0)
            {
                _temp.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                _temp.transform.localScale = new Vector3(-1, 1, 1);
            }

            return _animal;
        }

        /// <summary>
        /// 计算动物类型
        /// </summary>
        /// <returns>0是大象，1是鸵鸟，2是蟹，3是犀牛，4是龟</returns>
        public float CalculateAnimalType()
        {
            return Random.Range(0, 5) % 5;
        }

        /// <summary>
        /// 计算生成的位置
        /// </summary>
        /// <returns>0是上方，1是下方，2是左方，3是右方</returns>
        public float CalculateLoadPoint()
        {
            return Random.Range(0, 4) % 4;
        }

        /// <summary>
        /// 固定时间生成动物
        /// </summary>
        public void LoadAnimal()
        {
            timer += Time.fixedDeltaTime;
            if (timer >= timeSpan)
            {
                LoadAnimalPrefab();
                timer = 0;
            }
            else
            {
                return;
            }
        }

        #endregion

    }
}
