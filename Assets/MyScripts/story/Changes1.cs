using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Changes1 : MonoBehaviour
{
    private float temptime;
    //public Controller con;
    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject man1;
    public GameObject man2;
    public TwoTrigger npc;
    public GameObject three;
    //public GameObject twotree;
    //private List<Material> materials = new List<Material>();
    void start()
    {
        this.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (temptime < 10)
        {
            temptime = temptime + Time.deltaTime;
        }
      
        if (npc.next2 == true&&temptime>10f)
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
            
           
            if (tree1.GetComponent<Renderer>().material.color.a > 0)
            {
                tree1.gameObject.GetComponent<Renderer>().material.color = new Color(
                    tree1.GetComponent<Renderer>().material.color.r,
                    tree1.GetComponent<Renderer>().material.color.g,
                    tree1.GetComponent<Renderer>().material.color.b,
                    //会根据你输入的时间进行渐变
                    tree1.GetComponent<Renderer>().material.color.a - Time.deltaTime / temptime);
                
            }
            if (tree2.GetComponent<Renderer>().material.color.a > 0)
            {
                tree2.gameObject.GetComponent<Renderer>().material.color = new Color(
                    tree2.GetComponent<Renderer>().material.color.r,
                    tree2.GetComponent<Renderer>().material.color.g,
                    tree2.GetComponent<Renderer>().material.color.b,
                    //会根据你输入的时间进行渐变
                    tree2.GetComponent<Renderer>().material.color.a - Time.deltaTime / temptime);
                yield return null;
            }
            
          
            if (tree3.GetComponent<Renderer>().material.color.a > 0)
            {
                tree3.gameObject.GetComponent<Renderer>().material.color = new Color(
                    tree3.GetComponent<Renderer>().material.color.r,
                    tree3.GetComponent<Renderer>().material.color.g,
                    tree3.GetComponent<Renderer>().material.color.b,
                    //会根据你输入的时间进行渐变
                    tree3.GetComponent<Renderer>().material.color.a - Time.deltaTime / temptime);
                yield return null;
            }
            if (man1.GetComponent<Renderer>().material.color.a > 0)
            {
                man1.gameObject.GetComponent<Renderer>().material.color = new Color(
                    man1.GetComponent<Renderer>().material.color.r,
                    man1.GetComponent<Renderer>().material.color.g,
                    man1.GetComponent<Renderer>().material.color.b,
                    //会根据你输入的时间进行渐变
                    man1.GetComponent<Renderer>().material.color.a - Time.deltaTime / temptime);
                yield return null;
            }
            if (man2.GetComponent<Renderer>().material.color.a > 0)
            {
                man2.gameObject.GetComponent<Renderer>().material.color = new Color(
                    man2.GetComponent<Renderer>().material.color.r,
                    man2.GetComponent<Renderer>().material.color.g,
                    man2.GetComponent<Renderer>().material.color.b,
                    //会根据你输入的时间进行渐变
                    man2.GetComponent<Renderer>().material.color.a - Time.deltaTime / temptime);
                yield return null;
            }
        }
        //虽然是透明的但是还在渲染，为了减少Drawcall，可以
        //1.隐藏物体2.摧毁物体3.移除到摄像机拍不到的地方
        //con.next = false;
        tree1.gameObject.SetActive(false);
        tree2.gameObject.SetActive(false);
        tree3.gameObject.SetActive(false);
        man1.gameObject.SetActive(false);
        man2.gameObject.SetActive(false);
        three.SetActive(true);
        this.enabled = false;
    }
   
}