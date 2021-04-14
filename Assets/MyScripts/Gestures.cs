using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using Unity.Collections;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARStand;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class Gestures : ARStandGuesture
{
    private ARCameraManager arCameraManager;
    private Camera m_camera;
    private XRCameraImage image;
    private bool hasImage = false;
    List<Vector3> fingerPoint;
    private StringBuilder stringBuilder;
    [SerializeField]
    private Text text;
    protected override void Start()
    {
        base.Start();
        arCameraManager = gameObject.GetComponent<ARCameraManager>();
        m_camera = gameObject.GetComponent<Camera>();
        fingerPoint = new List<Vector3>();
        stringBuilder = new StringBuilder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("story");
    }
    public override void SetGuestureInfo(ARStandGuestureData guestureInfo)
    {
        base.SetGuestureInfo(guestureInfo);
        if (m_Manager != null)
        {
            //if (is2D)
            //{
            m_Manager.GetGesture2DPoints();
            //}
            //else
            //{
            //    m_Manager.GetGesture3DPoints();
            //}
        }
        if (guestureInfo.HandGestureType == ArHandGestureType.FINGER_HEART)
        {
            Invoke("LoadScene", 3f);
            
        }
        stringBuilder.Clear();
        stringBuilder.Append("GestureType: ").Append(guestureInfo.HandGestureType.ToString()).Append("\n");
        /*stringBuilder.Append("HandSide: ").Append(guestureInfo.HandSide.ToString()).Append("\n");
        stringBuilder.Append("HandTowards: ").Append(guestureInfo.HandTowards.ToString()).Append("\n");
        stringBuilder.Append("Rect: ").Append(guestureInfo.Rect.ToString()).Append("\n");
        stringBuilder.Append("PalmCenter: ").Append(guestureInfo.PalmCenter.ToString()).Append("\n");
        stringBuilder.Append("PalmNormal: ").Append(guestureInfo.PalmNormal.ToString()).Append("\n");
        stringBuilder.Append("Confidence: ").Append(guestureInfo.Confidence.ToString());*/

        text.text = stringBuilder.ToString();
    }
    float ratiox;
    float ratioy;
    public override void SetPoints(List<Vector3> points)
    {
        base.SetPoints(points);
        if (arCameraManager == null)
            return;
        hasImage = false;
        image.Dispose();

        hasImage = arCameraManager.TryGetLatestImage(out image);

        ratiox = Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight ?
            (float)Screen.height / (float)Screen.width : 1f;
        ratioy = Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight ?
            1f : (float)Screen.width / (float)Screen.height;

    }
    public override void ClearInfos()
    {
        base.ClearInfos();
    }

    private void OnPostRender()
    {

        if (!hasImage)
            return;
        //Debug.LogError("OnPostRender " +
        //    m_Points == null);
        fingerPoint.Clear();

        if (m_Points == null || m_Points.Count == 0)
        {
            //Debug.Log("OnPostRender clear" + fingerPoint.Count);
            //DrawFingers(fingerPoint);
            return;
        }

        int index;
        //if (is2D)
        //{
        for (int i = 0; i < 5; i++)
        {
            fingerPoint.Clear();
            if (i != 0)
                fingerPoint.Add(ARStandGestureUtil.TrasnPosition2D(m_Points[0], image.width, image.height));
            for (int j = 0; j < 4; j++)
            {
                index = i * 4 + j;
                if (index >= m_Points.Count)
                    continue;

                fingerPoint.Add(ARStandGestureUtil.TrasnPosition2D(m_Points[index], image.width, image.height));
            }
            //DrawFingers(fingerPoint);
        }
        

    }
}
