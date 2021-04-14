using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Item.itemuse
{
    public class package : MonoBehaviour
    {
        //道具UI预设物
        public GameObject UIprefabs;
        //字典 UI与道具
        Dictionary<ItemUI,Item> items;
        void Start()
        {
            //调用构造函数 赋予指针
            items = new Dictionary<ItemUI, Item>();
        }

        // Update is called once per frame
        void Update()
        {
        }
        public void Additems(Item item)
        {
            // 背包中UI显示 
            //位置有grid layout 控制 角度不变 创建到父物体下
            //实例化UI
             GameObject ui=Instantiate(UIprefabs, new Vector3(0, 0, 0),Quaternion.identity,transform) as GameObject;
            //ui.GetComponent<ItemUI>().image.sprite = item.GetComponentInChildren<SpriteRenderer>().sprite;
            //字典中添加
            //Debug.Log("1122");
            items.Add(ui.GetComponent<ItemUI>(), item);
            
        }
    }
}