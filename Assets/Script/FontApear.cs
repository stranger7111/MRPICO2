using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class FontApear : MonoBehaviour
{
    // XR交互组件
    private XRSimpleInteractable interactable;

    // 要控制的Canvas对象
    public Canvas targetCanvas;

    // 控制Canvas显示/隐藏的标记
    bool isActive;

    // 初始化方法
    void Start()
    {
        // 获取XR交互组件
        interactable = GetComponent<XRSimpleInteractable>();

        // 初始状态设为隐藏
        isActive = false;

        // 初始化Canvas状态
        if (targetCanvas != null)
        {
            targetCanvas.gameObject.SetActive(isActive);
        }

        // 绑定交互选择事件
        interactable.selectEntered.AddListener(OnSelected);
    }

    // 交互选择事件处理
    private void OnSelected(SelectEnterEventArgs args)
    {
        // 反转显示状态
        isActive = !isActive;

        // 设置Canvas显示状态
        targetCanvas.gameObject.SetActive(isActive);
    }

    // 销毁时清理事件监听
    private void OnDestroy()
    {
        if (interactable != null)
        {
            // 移除事件监听防止内存泄漏
            interactable.selectEntered.RemoveListener(OnSelected);
        }
    }
}