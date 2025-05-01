using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using System;

[RequireComponent(typeof(XRSimpleInteractable))] // 强制要求挂载XR交互组件
public class PuzzleBack : MonoBehaviour
{
    // 动画控制器组件
    public Animator animator;

    // XR交互组件
    private XRSimpleInteractable interactable;

    // 存储当前动画状态信息
    AnimatorStateInfo stateInfo;

    // 目标激活对象
    public GameObject targetObject;

    // 初始化方法
    void Start()
    {
        // 获取XR交互组件
        interactable = GetComponent<XRSimpleInteractable>();
        // 绑定选择事件监听
        interactable.selectEntered.AddListener(OnSelected);
        // 初始化目标对象状态
        targetObject.SetActive(false);
    }

    // 每帧更新检测动画状态
    private void Update()
    {
        // 获取当前动画状态
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // 检测特定动画是否播放完成
        if (stateInfo.IsName("Scene") && stateInfo.normalizedTime >= 0.99f)
        {
            animator.speed = 0; // 停止动画播放
            targetObject.SetActive(true); // 激活目标对象
        }
    }

    // 交互选择事件处理
    private void OnSelected(SelectEnterEventArgs args)
    {
        if (animator != null)
        {
            animator.SetTrigger("Click"); // 触发动画状态
        }
    }

    // 对象销毁时的清理
    private void OnDestroy()
    {
        if (interactable != null)
        {
            // 移除事件监听防止内存泄漏
            interactable.selectEntered.RemoveListener(OnSelected);
        }
    }
}