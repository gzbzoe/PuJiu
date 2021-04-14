using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class ManController : MonoBehaviour
{
    private Transform picked_Object = null;//操控物体
    private Vector3 lastplanepoint;

    private float x;
    private float y;
    private float z;
    // 移动加权，使移动与手指移动同步
    private float xSpeed = 0.025f;

    private Touch oldtouch1;
    private Touch oldtouch2;
    private Touch touch;
    
    void Start()
    {
       
    }
    
    void Update()
    {
        //创建一个平面
        Plane target_Plane = new Plane(transform.up, transform.position);
        foreach (Touch touch in Input.touches)
        {
            
            //获取屏幕触摸点到摄像头近平面的射线
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            //射线距离
            float dist = 0.0f;
            target_Plane.Raycast(ray, out dist);
            //在距离dist位置的点
            Vector3 plane_Point = ray.GetPoint(dist);  
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit = new RaycastHit();
                // 判断是否有碰撞到对象
                if (Physics.Raycast(ray, out hit, 1000))
                {
              
                    picked_Object = hit.transform;
                    lastplanepoint = plane_Point;
                }
                else
                {
                   
                    picked_Object = null;
                }
            }
            else if (touch.phase == TouchPhase.Moved) //选中模型后拖拽
            {
                if (picked_Object != null)
                {
               
                    // 设置移动位移
                    x = Input.GetAxis("Mouse X") * xSpeed;
                    y = Input.GetAxis("Mouse Y") * xSpeed;
                    z = Input.GetAxis("Mouse Z") * xSpeed;
                    picked_Object.position += new Vector3(x, y, z);
                    lastplanepoint = plane_Point;
                }

            }
            else if (touch.phase == TouchPhase.Ended)  //释放
            {
                
                picked_Object = null;
            }
            if (Input.touchCount == 2)//双指放大缩小
            {
                //多点触摸 放大缩小
                //获取触摸位置
              
                Touch newtouch1 = Input.GetTouch(0);
                Touch newtouch2 = Input.GetTouch(1);
                if (newtouch2.phase == TouchPhase.Began)
                {
                    oldtouch1 = newtouch1;
                    oldtouch2 = newtouch2;
                    return;
                }
                float oldDistance = Vector2.Distance(oldtouch1.position, oldtouch2.position);
                float newDistance = Vector2.Distance(newtouch1.position, newtouch2.position);

                float offset = newDistance - oldDistance;
                float scale_offset = offset / 50f;

                Vector3 localscale = picked_Object.transform.localScale;
                Vector3 scale = new Vector3(localscale.x + scale_offset, localscale.y + scale_offset, localscale.z + scale_offset);
                //最小缩短到0.3倍
                if (scale.x > 0.3f && scale.y > 0.3f && scale.z > 0.3f)
                {
                    picked_Object.transform.localScale = scale;
                }
                //记住最新的触摸点 下一次使用
                oldtouch1 = newtouch1;
                oldtouch2 = newtouch2;
            }
        }
     }
}
