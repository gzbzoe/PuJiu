using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    public GameObject packpanel;
    public GameObject questionpanel;
    public GameObject paint2;
    public GameObject three;
    void Start()
    {
        //this.GetComponentInParent<Animator>().enabled = false;
    }


    void Update()
    {
       
       

    }
    public void Show()
    {
        packpanel.SetActive(true);
    }
    public void Hide()
    {
        packpanel.SetActive(false);
    }
    public void Correct()
    {
        if (packpanel.transform.childCount == 3)
        {
            paint2.SetActive(true);
            three.SetActive(false);
        }
        
        questionpanel.SetActive(false);
        
        
    }
    public void Error()
    {
        questionpanel.GetComponentInChildren<Animator>().enabled = true;

    }
    public void BacktoStory()
    {
        SceneManager.LoadScene("sotry_gesture");
    }

}
