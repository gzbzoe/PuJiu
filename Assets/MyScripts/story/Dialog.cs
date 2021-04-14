using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    //角色
    public GameObject Npc1;
    public GameObject Npc2;
    //男话
    private string[] data1 ={"1","2",
        "4"};
    //女话
    private string data2 ="3";
    //男对话索引
    private int index = 0;
    //是否处于对话中
    public bool isTalk = false;
    void Start()
    {
        Debug.Log(Npc1.GetComponentInChildren<TextMesh>().text);
       
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "NPC")
                {
                    Debug.Log(Npc1.GetComponentInChildren<TextMesh>().text);
                    //进入对话状态
                    isTalk = true;
                    //允许绘制
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                    {
                        //绘制指定索引的对话文本
                        if (index < data1.Length)
                        {
                            Npc1.GetComponentInChildren<TextMesh>().text = data1[index];
                            if (index == 1)
                            {
                                Npc2.GetComponentInChildren<TextMesh>().text = data2;
                            }
                            index = index + 1;
                        }

                    }
                }
            }
        
        
    }
    // Update is called once per frame
    void Update()
    {

    }
}

  

