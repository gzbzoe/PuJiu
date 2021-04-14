using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeController : MonoBehaviour
{
    public GameObject man;
    public GameObject woman;
    public bool isInThree = false;
    private string[] data ={"月色溶溶液","花阴寂寂春",
        "如何临皓魄","不见月中人","兰闺久寂寞","无事度芳春"};
    private int index = 0;//文本索引
    private float intertime = 0;//说话间隔时间
    public GameObject questpanel;
    void Awake()
    {
        isInThree = true;
        this.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ( intertime< 2)
        {
            intertime = intertime + Time.deltaTime;
        }
        if(index <data.Length&& intertime>2)
        {
            
            
            if (index >= 4)
            {
                woman.GetComponentInChildren<TextMesh>().text= data[index];
            }
            else
            {
                man.GetComponentInChildren<TextMesh>().text = data[index];
            }
            index = index + 1;
            intertime = 0;
        }
        if (index == 6)
        {
            Debug.Log("222");
           // man.GetComponentInChildren<TextMesh>().text = null;
            //woman.GetComponentInChildren<TextMesh>().text = null;
            StartCoroutine(Question());
            
        }
    }
    IEnumerator Question()
    {
       
        yield return new WaitForSeconds(5f);
        questpanel.SetActive(true);
        

    }
}
