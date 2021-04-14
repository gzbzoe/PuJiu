using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTrigger : MonoBehaviour
{
    public GameObject redwall;
    private float temptime;
    //public GameObject wall;
    public ParticleSystem particle;
    public bool next = false;

    void Start()
    {
 
    }

   
    void Update()
    {
        if (temptime < 1)
        {
            temptime = temptime + Time.deltaTime;
        }
  
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                //门消失 触发整个场景消失
                if (hitInfo.transform.gameObject.tag == "redwall")
                {
                    StartCoroutine(ChangeFormTime(temptime));
                    particle.GetComponent<ParticleSystem>().Play();
                    
                    /*if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                    
                       
                    }*/
                }

            }
        }
    }
    IEnumerator ChangeFormTime(float _timeCout)
    {
        while (_timeCout > 0)
        {
            //倒计时
            _timeCout -= Time.deltaTime;
            if (redwall.GetComponent<Renderer>().material.color.a > 0)
            {
                redwall.gameObject.GetComponent<Renderer>().material.color = new Color(
                    redwall.GetComponent<Renderer>().material.color.r,
                    redwall.GetComponent<Renderer>().material.color.g,
                    redwall.GetComponent<Renderer>().material.color.b,
                    //会根据你输入的时间进行渐变
                    redwall.GetComponent<Renderer>().material.color.a - Time.deltaTime / temptime);
                yield return null;
            }
        }
        //虽然是透明的但是还在渲染，为了减少Drawcall，可以
        //1.隐藏物体2.摧毁物体3.移除到摄像机拍不到的地方
        next = true;
        redwall.gameObject.SetActive(false);
        
    }
  

}

