using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainUI : MonoBehaviour
{
    public GameObject SelectingPanel;//选择人物面板
    public GameObject HintPanel;//选择人物面板
    //public GameObject Rect;
    private ScrollRect rect;
    void Start()
    {
        rect = this.transform.Find("Scroll View").GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HideSelectingPanel()
    {
        SelectingPanel.SetActive(false);
       rect.enabled = true;
       // Rect.GetComponent<ScrollRect>().enabled = true;
    }
    public void ShowHintPanel()
    {
        HintPanel.SetActive(true);
        //Rect.GetComponent<ScrollRect>().enabled = false;
    }
    public void HideHintPanel()
    {
        HintPanel.SetActive(false);
       // Rect.GetComponent<ScrollRect>().enabled = true;
    }
    public void EnterStoryBtn()
    {
        //SceneManager.LoadSceneAsync("sotry_gesture");
       // Debug.Log("11");

        //Application.LoadLevel(Application.loadedLevelName);
        SceneManager.LoadScene("sotry_gesture");
    }
}
