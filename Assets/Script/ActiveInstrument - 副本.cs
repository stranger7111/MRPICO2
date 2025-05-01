using PXR_Audio.Spatializer;  // PICO VR音频空间化插件
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;  // Unity可视化脚本系统
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;  // XR交互工具包

//public class ActiveInstrument : MonoBehaviour
//{
//    // XR交互组件
//    private XRSimpleInteractable interactable;

//    // 需要控制激活状态的3个目标对象
//    public GameObject targetObject1;
//    public GameObject targetObject2;
//    public GameObject targetObject3;

//    // 需要触发动画的3个Animator组件
//    public Animator ani1;
//    public Animator ani2;
//    public Animator ani3;

//    // 主乐器动画控制器
//    public Animator InstrumentAni;

//    // 激活状态标志位
//    bool isActive;

//    // 初始化方法
//    private void Start()
//    {
//        isActive = false;  // 初始状态设置为未激活
//        interactable = GetComponent<XRSimpleInteractable>();  // 获取XR交互组件
//        interactable.selectEntered.AddListener(OnSelectEntered);  // 绑定选择事件监听器
//    }

//    // XR交互选择事件处理
//    public void OnSelectEntered(SelectEnterEventArgs args)
//    {
//        isActive = !isActive;  // 切换激活状态

//        // 根据激活状态设置目标对象显示/隐藏
//        if (targetObject1 != null)
//        {
//            targetObject1.SetActive(isActive);  // 设置对象1激活状态
//        }
//        if (targetObject2 != null)
//        {
//            targetObject2.SetActive(isActive);  // 设置对象2激活状态
//        }
//        if (targetObject3 != null)
//        {
//            targetObject3.SetActive(isActive);  // 设置对象3激活状态
//        }

//        // 触发各个Animator的动画
//        if (ani1 != null)
//        {
//            ani1.SetTrigger("Click");  // 触发对象1的点击动画
//        }
//        if (ani2 != null)
//        {
//            ani2.SetTrigger("Click");  // 触发对象2的点击动画
//        }
//        if (ani3 != null)
//        {
//            ani3.SetTrigger("Click");  // 触发对象3的点击动画
//        }

//        // 触发主乐器动画
//        if (InstrumentAni != null)
//        {
//            InstrumentAni.SetTrigger("Click");  // 触发主乐器点击动画
//        }
//    }

//    // 对象销毁时的清理
//    private void OnDestroy()
//    {
//        if (interactable != null)
//        {
//            // 移除事件监听防止内存泄漏
//            interactable.selectEntered.RemoveListener(OnSelectEntered);
//        }
//    }
