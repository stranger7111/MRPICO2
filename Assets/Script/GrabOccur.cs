using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class GrabOccur : MonoBehaviour
{
    // XR抓取交互组件
    public XRGrabInteractable interactable;
    // 控制Canvas显示状态的标志位
    bool isActive;
    // 要控制的Canvas对象
    public Canvas targetCanvas;

    // 初始化方法
    void Start()
    {
        // 获取XR抓取交互组件
        interactable = GetComponent<XRGrabInteractable>();
        // 初始状态设为隐藏
        isActive = false;

        // 初始化Canvas状态
        if (targetCanvas != null)
        {
            targetCanvas.enabled = isActive;
        }

        // 绑定抓取和释放事件监听
        interactable.selectEntered.AddListener(OnClick);
        interactable.selectExited.AddListener(OnExit);
    }

    // 抓取事件处理
    private void OnClick(SelectEnterEventArgs args)
    {
        // 反转显示状态
        isActive = !isActive;
        // 设置Canvas显示状态
        if (targetCanvas != null)
        {
            targetCanvas.enabled = isActive;
        }
    }

    // 释放事件处理
    private void OnExit(SelectExitEventArgs args)
    {
        // 再次反转显示状态
        isActive = !isActive;
        // 设置Canvas显示状态
        if (targetCanvas != null)
        {
            targetCanvas.enabled = isActive;
        }
    }

    // 对象销毁时的清理
    private void OnDestroy()
    {
        if (interactable != null)
        {
            // 移除事件监听防止内存泄漏
            interactable.selectEntered.RemoveListener(OnClick);
        }
    }
}

