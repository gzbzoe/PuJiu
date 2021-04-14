using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShot : MonoBehaviour
{

    public Camera ARCamera;
    //public GameObject panel;
    //public GameObject btn;
   public Text text;
    //public Text text1;
    // Use this for initialization
    void Start()
    {
        ARCamera = GameObject.Find("ARCamera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //拍照
     public void OnScreenShotClick()
     {
        
         //获取当前时间
         System.DateTime now = System.DateTime.Now;
         string nowtime = now.ToString();
         nowtime = nowtime.Trim();
         nowtime = nowtime.Replace("/", "-");
         //创建、获取图片名称
         string filename = "ARScreenShot" + nowtime + ".png";
         //运行设备是Android
         if (Application.platform == RuntimePlatform.Android)
         {
            //不包含UI的截图 摄像机 截取屏幕
             RenderTexture tex = new RenderTexture(Screen.width, Screen.height, 1);
             //指定targetTexture
             ARCamera.targetTexture = tex;
             //渲染
             ARCamera.Render();

             RenderTexture.active = tex;

             //创建2D图片 图片宽度、高度、格式、是否映射
             Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
             //读取图片，从当前渲染目标读取像素， 从哪开始、从哪结束
             texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
             texture.Compress(true);
             //调用Apply截屏 
             texture.Apply();

             //截屏成功清除 销毁
             ARCamera.targetTexture = null;
             RenderTexture.active = null;
             Destroy(tex);

             //转化成字节数组 并进行保存
             byte[] bytes = texture.EncodeToPNG();
            //存储的路径
            //string destination = Application.persistentDataPath.Substring(0, Application.persistentDataPath.IndexOf("Android")) + "/DCIM/Camera/";// "/mnt/sdcard/DCIM/ARphoto";
            string destination = Application.persistentDataPath; 
            //如果这个路径不存在
            /*if (!Directory.Exists(destination))
             {
                 //那么就创建路径
                 Directory.CreateDirectory(destination);
             }*/
             //需要保存的路径 
             string allpath = Application.persistentDataPath+"/" + filename;
            text.text = allpath;
             //保存(写入) 将转化成的数组 保存到pathSave路径下面
             File.WriteAllBytes(allpath, bytes);

             //刷新图片
             string[] paths = new string[1];
             paths[0] = allpath;
             ScanFile(paths);

         }
     }


/*public void CaptureScreenshot(string name="")
    {
        string _name = "";
        if (string.IsNullOrEmpty(name))
        {
            _name = "Screenshot_" + GetCurTime() + ".png";
        }
        //编辑器下
        //string path = Application.persistentDataPath + "/" + _name;
        //Application.CaptureScreenshot(path, 0);
        
        // 编辑器下
        // string path = Application.persistentDataPath + "/" + _name;       
        string path = Application.dataPath + "/" + _name;
        ScreenCapture.CaptureScreenshot(path, 0);
        Debug.Log("图片保存地址" + path);
        panel.SetActive(false);
        btn.SetActive(false);
        
        //Android版本
        StartCoroutine(CutImage(_name));
        //text.text = "图片保存地址" + Application.persistentDataPath.Substring(0, Application.persistentDataPath.IndexOf("Android")) + "/DCIM/Camera/" + _name;





    }
    //截屏并保存
    IEnumerator CutImage(string name)
    {
        //图片大小  
        Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        yield return new WaitForEndOfFrame();
        tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, true);
        tex.Apply();
        yield return tex;
        byte[] byt = tex.EncodeToPNG();
        string path = Application.persistentDataPath.Substring(0, Application.persistentDataPath.IndexOf("Android"));
        string savepath = path + "/DCIM/Camera/" + name;
        //File.WriteAllBytes(savepath, byt);
        File.WriteAllBytes(savepath, byt);
        //string[] paths = new string[1];
        //paths[0] = path + "/Pictures/Screenshots/" + name;
        //ScanFile(savepath);
        //string[] paths = new string[1];
        //paths[0] = path;
        ScanFile(savepath);
        //text1.text = "刷新保存地址" + paths;
    }*/

    //刷新图片，显示到相册中
    void ScanFile(string[] path)
    {
        using (AndroidJavaClass PlayerActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject playerActivity = PlayerActivity.GetStatic<AndroidJavaObject>("currentActivity");
            using (AndroidJavaObject Conn = new AndroidJavaObject("android.media.MediaScannerConnection", playerActivity, null))
            {
                Conn.CallStatic("scanFile", playerActivity, path, null, null);
            }
        }
    }

}
