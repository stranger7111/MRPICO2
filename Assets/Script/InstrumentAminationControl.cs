using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InstrumentAnimationControl: MonoBehaviour
{
   // public GameObject objectToSpawn1; // 待生成的预制体
   // public Transform spawnAnchor1;     // 固定生成点（可设为空物体）
   // private GameObject spawnedObject1; // 当前生成的物体实例
    private bool isVisible = false;   // 物体可见状态
    public Animator buttonAnimator1;
    private XRSimpleInteractable interactable;
    //public GameObject objectToSpawn; // 待生成的预制体
    //public Transform spawnAnchor;     // 固定生成点（可设为空物体）
    //private GameObject spawnedObject; // 当前生成的物体实例
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnButtonClicked);
    }

    public void OnButtonClicked(SelectEnterEventArgs args)
    {

        //if (isVisible)
        //{
        //    // 如果物体已存在则销毁
        //    if (spawnedObject != null)
        //    {
        //        Destroy(spawnedObject);
        //        spawnedObject = null;
        //    }
        //}
        //else
        //{
        //    // 生成新物体
        //    Vector3 spawnPos = spawnAnchor ? spawnAnchor.position : Vector3.zero;
        //    spawnedObject = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
            if (buttonAnimator1 != null)
        {
            buttonAnimator1.SetTrigger("Click");
          //  buttonAnimator1.ResetTrigger("Click");// 确保触发器名称与 Animator 中一致
                                                  // 标记动画开始
        }
  }

       // isVisible = !isVisible; // 切换状态
        
       
        //if (isVisible)
        //{
        //    // 如果物体已存在则销毁
        //    if (spawnedObject1 != null)
        //    {
        //        Destroy(spawnedObject1);
        //        spawnedObject1 = null;
        //    }
        //    else
        //    {
        //        Vector3 spawnPos1 = spawnAnchor1 ? spawnAnchor1.position : Vector3.zero;
        //        spawnedObject1 = Instantiate(objectToSpawn1, spawnPos1, Quaternion.identity);
        //        isVisible = !isVisible; // 切换状态

        //    } 
        //}         
    
    private void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnButtonClicked);
        }
    }
    // Update is called once per frame
}
