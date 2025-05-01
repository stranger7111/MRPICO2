using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

// 继承XR抓取交互组件，实现物体释放后返回原位功能
public class BackToOrigin : XRGrabInteractable
{
    // 保存物体初始位置
    private Vector3 originalPosition;
    // 保存物体初始旋转
    private Quaternion originalRotation;

    // 初始化方法（XR交互组件的生命周期）
    protected override void Awake()
    {
        base.Awake(); // 调用父类初始化
        // 记录物体初始状态
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    // 当物体被释放时触发
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args); // 调用父类释放逻辑
        ResetToOriginalPosition(); // 执行位置重置
    }

    // 物体复位核心方法
    private void ResetToOriginalPosition()
    {
        // 物理模拟控制代码（当前被注释）
        // GetComponent<Rigidbody>().isKinematic = true; // 临时启用运动学防止物理冲突

        // 强制设置物体状态
        transform.position = originalPosition; // 恢复初始位置
        transform.rotation = originalRotation; // 恢复初始旋转

        // GetComponent<Rigidbody>().isKinematic = false; // 恢复物理模拟（当前被注释）
    }
}