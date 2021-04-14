using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    //持有当前外发光需要的组件
    private HighlightableObject m_ho;

    void Awake()
    {
        //初始化组件
        m_ho = GetComponent<HighlightableObject>();
        
    }

    void Update()
    {
        if (this.gameObject.tag == "props")
        {
            m_ho.FlashingOn(Color.green, Color.yellow, 1f);
        }
        if (this.gameObject.tag == "img"|| this.gameObject.tag == "img2")
        {
            m_ho.FlashingOn(Color.yellow, Color.yellow, 1f);
        }
       
        if (this.gameObject.tag == "redwall")
        {
            m_ho.FlashingOn(Color.red, Color.red, 1f);
        }
    }
  /*  void HifhLightFunction()
    {
        //循环往复外发光开启（参数为：颜色1，颜色2，切换时间）
        m_ho.FlashingOn(Color.green, Color.blue, 1f);

        //关闭循环往复外发光
        m_ho.FlashingOff();


        //持续外发光开启（参数：颜色）
        m_ho.ConstantOn(Color.yellow);

        //关闭持续外发光
        m_ho.ConstantOff();
    }*/

   

}
