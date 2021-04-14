using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectingMan : MonoBehaviour
{
    public GameObject[] people;//合影人物数组
    public int currentnum;//当前人物编号
    public GameObject panel;//选择人物面板
    public ScrollRect rect; //左滑右滑操控
    public GameObject Man;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    //选择人物
    public void Selecting(int num)
    {
        //Instantiate(Resources.Load("man1", typeof(GameObject)));
        //若已选择人物，则已经显示人物消失
        if (people[currentnum].activeInHierarchy)
        {
            Destroy(people[currentnum]);
        }
       
        //people[currentnum].SetActive(false);
        //显示所选人物
        GameObject.Instantiate(people[num], new Vector3(0f, -1f, 2.5f), Quaternion.AngleAxis(180, Vector3.up),Man.transform);
       // people[num].transform.localScale = new Vector3(100, 100, 100);
       // people[num].SetActive(true);
        currentnum = num;
        //选择人物面板消失
        panel.SetActive(false);
        //可进行左右滑动
        rect.enabled = true;
    }
}
