using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectAppearance : MonoBehaviour
{
    public GameObject objectToSpawn; // 待生成的预制体
    public Transform spawnAnchor;     // 固定生成点（可设为空物体）
    private GameObject spawnedObject; // 当前生成的物体实例
    private bool isVisible = false;   // 物体可见状态
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(OnClick);
        ani = GetComponent<Animator>();
    }
    private void OnClick(SelectEnterEventArgs args)
    {
        if (isVisible)
        {
            // 如果物体已存在则销毁
            if (spawnedObject != null)
            {
                Destroy(spawnedObject);
                spawnedObject = null;
            }
        }
        else
        {
            // 生成新物体
            Vector3 spawnPos = spawnAnchor ? spawnAnchor.position : Vector3.zero;
            spawnedObject = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
           
        }

        isVisible = !isVisible; // 切换状态

        // Pico手柄震动反馈
        // PXR_Input.VibrateController(0.3f, 0.2f, Controller.Right);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
