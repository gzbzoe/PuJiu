using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item.itemuse
{
    public class Item : MonoBehaviour
    {
        //背包
        public package pack;
        void Start()
        {

        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {//判断鼠标是否按下
             // 从摄像机开始，到屏幕触摸点，发出一条射线
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // 撞击到了哪个3D物体
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "props")
                    {
                        //打印出碰撞到的节点的名字
                        Debug.Log(hit.transform.name);
                        //道具消失
                        //hit.transform.position = new Vector3(0, 1000, 0);
                        hit.transform.gameObject.SetActive(false);
                        //背包添加道具

                        pack.Additems(this.GetComponent<Item>());
                      
                    }

                }
            }
        }
    }
}
 


