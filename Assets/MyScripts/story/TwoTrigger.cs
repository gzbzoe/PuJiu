using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TwoTrigger : MonoBehaviour
{
    //定义NPC对话数据
    private string[] data ={"小姐 小生姓张名珙子君瑞 西洛人士" ,
                           "先父曾拜礼部尚书 ","我年方二十有三 正月十七日子时建生 ","父母双亡书剑飘零，至今尚未娶妻",
        "哎，小姐，小姐"};
    //当前对话索引
    private int index = 0;
    //用于显示对话的 Text
    //public GameObject Text;
    //对话标示贴图
    //public Texture mTalkIcon;
    //是否显示对话标示贴图
   // private bool isTalk = false;
    public GameObject NPC2;
    //public GameObject paper;
    public bool next2 = false;
    void Start()
    {
        //Instantiate(paper, new Vector3(0f, 0f, 26f), Quaternion.identity, transform.parent.gameObject.transform);
    }

    void Update()
    {
        //从角色位置向NPC发射一条经过鼠标位置的射线
        Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mHi;
        //判断是否击中了NPC
        if (Physics.Raycast(mRay, out mHi))
        {
            //如果击中了NPC
            if (mHi.collider.gameObject.tag == "NPC")
            {
                Debug.Log("123");
                //进入对话状态
               // isTalk = true;
                //允许绘制
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    //绘制指定索引的对话文本
                    if (index < 6)
                    {
                        Debug.Log(index);
                        NPC2.GetComponentInChildren<TextMesh>().text = null;
                        if (index == 4)
                        {
                            this.GetComponentInChildren<TextMesh>().text = null;
                            NPC2.GetComponentInChildren<TextMesh>().text = "谁问你了";
                            NPC2.GetComponent<Paths>().enabled = true;
                        }
                        else
                        {
                            if (index == 5)
                            {
                                this.GetComponentInChildren<TextMesh>().text = data[index-1];
                            }
                            else
                            {
                                this.GetComponentInChildren<TextMesh>().text = data[index];
                            }  
                        }
                          index = index + 1;
                    }  
                    if (index == 6)  //对话结束 触发该场景消失
                    {
                        //this.GetComponentInChildren<TextMesh>().text = null;

                        next2 = true;
                    }
                 
                }
            }
        }
    }

   /* void OnGUI()
    {
        if (isTalk)
        {
            //禁用系统鼠标指针
            //Screen.showCursor = false;
            Rect mRect = new Rect(Input.mousePosition.x - mTalkIcon.width,
                   Screen.height - Input.mousePosition.y - mTalkIcon.height,
                   mTalkIcon.width, mTalkIcon.height);
            //绘制自定义鼠标指针
            GUI.DrawTexture(mRect, mTalkIcon);
        }

    }*/
}

