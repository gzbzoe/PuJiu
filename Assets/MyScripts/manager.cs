using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARStand;
using UnityEngine.UI;
public class manager : MonoBehaviour
{
    public GameObject ob;
    public GameObject ob2;
    public Text text;
    
    void Awake()
    {
        Debug.Log("123");
        this.GetComponent<manager>().enabled = true;
        ob.SetActive(true);
        ob2.SetActive(true);
        ob.GetComponent<ARSession>().enabled = true;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (ARSession.state == ARSessionState.None || ARSession.state == ARSessionState.CheckingAvailability)
        {
            //设备状态未知
            Debug.Log("设备状态未知");
            text.text = "设备状态未知";
        }
        if (ARSession.state == ARSessionState.Unsupported)
        {
            // 设备不支持AR
            Debug.Log("设备不支持AR");
            text.text = "设备不支持AR";
        }
        else
        {
            // 设备支持AR
            Debug.Log("设备支持AR");
            text.text = "设备支持AR";
        }
        
    }
 

}
