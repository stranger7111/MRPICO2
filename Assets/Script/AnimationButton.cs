using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class AnimationButton : MonoBehaviour
{
    // XR交互组件
    public XRSimpleInteractable interactable;
    // 按钮动画控制器
    public Animator ButtonAnimator;
    // 需要控制的UI图片组件1
    public Image targetImage1;
    // 需要控制的UI图片组件2
    public Image targetImage2;
    // 图片显示状态标志位
    private bool isVisible;
    // 对象激活状态标志位
    private bool isActive;
    // 需要控制显示的目标物体
    public GameObject targetObject;

    // 初始化方法
    void Start()
    {
        // 获取XR交互组件
        interactable = GetComponent<XRSimpleInteractable>();
        // 绑定选择事件监听器
        interactable.selectEntered.AddListener(OnButtonClicked);
    }

    // 按钮点击事件处理
    public void OnButtonClicked(SelectEnterEventArgs args)
    {
        // 触发按钮动画
        if (ButtonAnimator != null)
        {
            ButtonAnimator.ResetTrigger("Click"); // 重置动画触发器防止冲突
            ButtonAnimator.SetTrigger("Click");   // 触发点击动画
        }
        Toggle(); // 切换UI显示状态
        Spawn();  // 切换目标物体状态
    }

    // 切换UI图片显示状态的方法
    public void Toggle()
    {
        isVisible = !isVisible; // 反转显示状态
        targetImage1.gameObject.SetActive(isVisible); // 设置图片1的激活状态
        targetImage2.gameObject.SetActive(isVisible); // 设置图片2的激活状态
    }

    // 切换目标物体状态的方法
    public void Spawn()
    {
        isActive = targetObject.activeSelf; // 获取当前激活状态
        targetObject.SetActive(!isActive); // 反转目标物体激活状态
    }

    // 当组件禁用时的清理方法
    private void OnDisable()
    {
        Debug.Log("监听器被移除"); // 调试日志输出
        if (interactable != null)
        {
            // 移除事件监听防止内存泄漏
            interactable.selectEntered.RemoveListener(OnButtonClicked);
        }
    }
}