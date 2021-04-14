using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterStory : MonoBehaviour
{
    //public Camera mainCrma;//ARCamera下的相机
   //private RaycastHit hitInfo;
   // private Ray ray;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//从摄像机发出一条射线,到点击的坐标
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.tag == "img")
                {
                    if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        if (Input.GetTouch(0).tapCount == 2)
                        {
                            SceneManager.LoadScene("storyy");
                        }
                    }
                }
                if (hitInfo.transform.gameObject.tag == "img2")
                {
                    if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        if (Input.GetTouch(0).tapCount == 2)
                        {
                            SceneManager.LoadScene("story_2");
                        }
                    }
                }
                if (hitInfo.transform.gameObject.tag == "scrollpainting3")
                {
                    if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        if (Input.GetTouch(0).tapCount == 2)
                        {
                            SceneManager.LoadScene("story_3");
                        }
                    }
                }
            }
        }

    }
}
