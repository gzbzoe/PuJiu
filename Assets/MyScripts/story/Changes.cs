using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Changes : MonoBehaviour
{
    private float temptime ;
    public OneTrigger con;
    public GameObject onewall;
    public GameObject onewoman;
    public GameObject oneman;
    public GameObject two;
    public ParticleSystem particle;
    

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (temptime < 20)
        {
            temptime = temptime + Time.deltaTime;
        }
      
        if (con.next == true&&temptime>20f)
        {
            StartCoroutine(ChangeFormTime(temptime));
            
        }
    }
    IEnumerator ChangeFormTime(float _timeCout)
    {
        while (_timeCout > 0)
        {

            //倒计时
            _timeCout -= Time.deltaTime;
            
         
            if (onewall.GetComponent<Renderer>().material.color.a > 0)
            {
                onewall.gameObject.GetComponent<Renderer>().material.color = new Color(
                    onewall.GetComponent<Renderer>().material.color.r,
                    onewall.GetComponent<Renderer>().material.color.g,
                    onewall.GetComponent<Renderer>().material.color.b,
                    //会根据你输入的时间进行渐变
                    onewall.GetComponent<Renderer>().material.color.a - Time.deltaTime / temptime);
                
            }
            if (onewoman.GetComponent<Renderer>().material.color.a > 0)
            {
                onewoman.gameObject.GetComponent<Renderer>().material.color = new Color(
                    onewoman.GetComponent<Renderer>().material.color.r,
                    onewoman.GetComponent<Renderer>().material.color.g,
                    onewoman.GetComponent<Renderer>().material.color.b,
                    //会根据你输入的时间进行渐变
                    onewoman.GetComponent<Renderer>().material.color.a - Time.deltaTime / temptime);
                yield return null;
            }
            
            // FadeModel(twotree);
            if (oneman.GetComponent<Renderer>().material.color.a > 0)
            {
                oneman.gameObject.GetComponent<Renderer>().material.color = new Color(
                    oneman.GetComponent<Renderer>().material.color.r,
                    oneman.GetComponent<Renderer>().material.color.g,
                    oneman.GetComponent<Renderer>().material.color.b,
                    //会根据你输入的时间进行渐变
                    oneman.GetComponent<Renderer>().material.color.a - Time.deltaTime / temptime);
                yield return null;
            }
        }
        //虽然是透明的但是还在渲染，为了减少Drawcall，可以
        //1.隐藏物体2.摧毁物体3.移除到摄像机拍不到的地方
        //con.next = false;
        onewall.gameObject.SetActive(false);
        onewoman.gameObject.SetActive(false);
        oneman.gameObject.SetActive(false);
        two.SetActive(true);
        
        particle.GetComponent<ParticleSystem>().Stop();
    }
   
}