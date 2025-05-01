using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRSimpleInteractable))] // 强制要求挂载XR交互组件
public class CanvasOccur : MonoBehaviour
{
    // 要控制显示/隐藏的目标Canvas
    public Canvas targetcanvas;

    // XR交互组件引用
    public XRSimpleInteractable interactable;

    // Canvas激活状态标志位
    bool isActive;

    // 初始化方法
    void Start()
    {
        isActive = false; // 初始状态设置为隐藏

        // 获取XR交互组件
        interactable = GetComponent<XRSimpleInteractable>();

        // 绑定选择事件监听器
        interactable.selectEntered.AddListener(OnSelectEnter);

        // 初始化Canvas状态
        if (targetcanvas != null)
        {
            targetcanvas.gameObject.SetActive(isActive);
        }
    }

    // 交互选择事件处理
    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        isActive = !isActive; // 反转激活状态

        // 设置Canvas显示状态
        if (targetcanvas != null)
        {
            targetcanvas.gameObject.SetActive(isActive);
        }
    }

    // 对象销毁时的清理
    private void OnDestroy()
    {
        // 移除事件监听防止内存泄漏
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnSelectEnter);
        }
    }
}