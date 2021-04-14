using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public class PageChange : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    
    private ScrollRect rect;                          //滑动组件
    private float targethorizontal = 0;             //滑动的起始坐标  
    private bool isdrag = false;                    //是否拖拽结束  
    private List<float> posList = new List<float>();            //每页的临界角，页索引从0开始  
    private int currentpageindex = -1;
    public Action<int> OnPageChanged;               //Action<int> 表示有传入参数int无返回值的委托
    public RectTransform content;
    private bool stopmove = true;
    public float smooting = 4;      //滑动速度  
    public float sensitivity = 0;
    private float startTime;

    private float startDragHorizontal;
    public Transform togglelist;
    public int preindex = 0;//前一个页面的索引

    public GameObject selectingpanel; //选择人物面板
    public GameObject hintpanel;//提示信息面板
    public GameObject people;//合影界面 人物
 
    void Start()
    {
        rect = transform.GetComponent<ScrollRect>();
        var rectwidth = GetComponent<RectTransform>();//显示窗口的宽度
        var tempWidth = ((float)(content.transform.childCount-1)* rectwidth.rect.width);///content的宽度
        content.sizeDelta = new Vector2(tempWidth, rectwidth.rect.height);
        float horizontalLength = content.rect.width - rectwidth.rect.width;        //未显示的长度
        people = GameObject.Find("people");
        for (int i = 0; i < rect.content.transform.childCount; i++)
        {
            posList.Add(rectwidth.rect.width * i / horizontalLength);//添加每页的临界角
        }
    }

    void Update()
    {
        //控制滑动一个页面
        if (!isdrag && !stopmove)
        {
            startTime += Time.deltaTime;
            float t = startTime * smooting;
            rect.horizontalNormalizedPosition = Mathf.Lerp(rect.horizontalNormalizedPosition, targethorizontal, t);
            if (t >= 1)
                stopmove = true;
        }
        //合影界面
        if (preindex == 0||preindex==1)
        {
            //双击出现选择人物面板
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("222");
                if (Input.GetTouch(0).tapCount == 2)
                {
                    selectingpanel.SetActive(true);
                }
            }
        }
    }

    public void PageTo(int index)
    {
        if (index >= 0 && index < posList.Count)
        {
            rect.horizontalNormalizedPosition = posList[index];
            SetPageIndex(index);
            GetIndex(index);
        }

    }
    //设置页面索引
    private void SetPageIndex(int index)
    {
        if (currentpageindex != index)
        {
            currentpageindex = index;
            if (OnPageChanged != null)
                OnPageChanged(index);
        }
    }
    //开始拖动
    public void OnBeginDrag(PointerEventData eventData)
    {
        isdrag = true;

        startDragHorizontal = rect.horizontalNormalizedPosition;
    }
    //结束拖动
    public void OnEndDrag(PointerEventData eventData)
    {
        float posX = rect.horizontalNormalizedPosition;
        posX += ((posX - startDragHorizontal) * sensitivity);
        posX = posX < 1 ? posX : 1;
        posX = posX > 0 ? posX : 0;
        int index = 0;

        float offset = Mathf.Abs(posList[index] - posX);
        for (int i = 1; i < posList.Count; i++)
        {
            float temp = Mathf.Abs(posList[i] - posX);
            if (temp < offset)
            {
                index = i;
                offset = temp;
            }
        }
        SetPageIndex(index);//设置页面索引
        GetIndex(index);//获得页面索引
        targethorizontal = posList[index]; //设置当前坐标，更新函数进行插值  
        isdrag = false;
        startTime = 0;
        stopmove = false;
    }
    public void GetIndex(int index)
    {
        //地图
        if (index == 0)
        {

            if (people.transform.childCount>0)
            {
                Destroy(people.transform.GetChild(0).gameObject);
            }
        }
        
          //选择人物时不能切换版块
            if(selectingpanel.activeInHierarchy)
            {
                rect.enabled = false;
            }
            else
            {
                rect.enabled = true;
            }
        
        //扫一扫
        if (index == 2)
        {
            if (people.transform.childCount>0)
            {
                Destroy(people.transform.GetChild(0).gameObject);
            }
            //提示面板出现
            if (hintpanel.activeInHierarchy)
            {
                //不能左右滑动
                rect.enabled = false;

            }
            else
            {
                rect.enabled = true;
            }
        }
        //图标提示与页面关联
        var toogle = togglelist.GetChild(preindex).GetComponent<Toggle>();
        Debug.Log(preindex);
        toogle.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        toogle = togglelist.GetChild(index).GetComponent<Toggle>();
        //toogle.isOn = true;
        toogle.GetComponent<Transform>().localScale = new Vector3(2, 2, 2);
        preindex = index;
    }
}
