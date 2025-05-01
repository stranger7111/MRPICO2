using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

// 抓取射线控制器类
public class GrabRayController : MonoBehaviour
{
    // 射线交互器
    public XRRayInteractor grabRayInteractor;
    // 直接交互器
    //public XRDirectInteractor grabDirectInteractor;

    // 旋转锚点动作引用
    public InputActionReference rotateAnchorReference;
    // 平移锚点动作引用
  //  public InputActionReference translateAnchorReference;
    // 传送激活动作引用
  //  public InputActionReference teleportActivateReference;
    // 移动动作引用
    public InputActionReference moveReference;
    // 转向动作引用
    public InputActionReference turnReference;

    private void Start()
    {
        if (grabRayInteractor == null)
        {
            Debug.LogError("未分配 grabRayInteractor！", this);
            enabled = false;
            return;
        }
        // 为射线交互器的 selectEntered 事件添加监听器，当抓取开始时调用 OnEnterGrab 方法
        grabRayInteractor.selectEntered.AddListener(OnEnterGrab);
        // 为射线交互器的 selectExited 事件添加监听器，当抓取结束时调用 OnExitGrab 方法
        grabRayInteractor.selectExited.AddListener(OnExitGrab);
    }

    private void OnDestroy()
    {

        if (grabRayInteractor != null)
        {
            grabRayInteractor.selectEntered.RemoveListener(OnEnterGrab);
            grabRayInteractor.selectExited.RemoveListener(OnExitGrab);
        }
        // 在对象销毁时，移除 selectEntered 事件的监听器
       // grabRayInteractor.selectEntered.RemoveListener(OnEnterGrab);
        // 在对象销毁时，移除 selectExited 事件的监听器
      //  grabRayInteractor.selectExited.RemoveListener(OnExitGrab);
    }

    private void OnEnterGrab(SelectEnterEventArgs arg)
    {
        var lineVisual = grabRayInteractor.GetComponent<XRInteractorLineVisual>();
        lineVisual.enabled = false;
        lineVisual.enabled = true;
        // 禁用传送激活动作
        // DisableAction(teleportActivateReference);
        // 禁用移动动作
        DisableAction(moveReference);
        // 禁用转向动作
        DisableAction(turnReference);
        // 启用旋转锚点动作
        EnableAction(rotateAnchorReference);
        // 启用平移锚点动作
       // EnableAction(translateAnchorReference);
    }

    private void OnExitGrab(SelectExitEventArgs arg)
    {
        
        // 启用传送激活动作
        // EnableAction(teleportActivateReference);
        // 启用移动动作
        EnableAction(moveReference);
        // 启用转向动作
        EnableAction(turnReference);
        // 禁用旋转锚点动作
        DisableAction(rotateAnchorReference);
        // 禁用平移锚点动作
       // DisableAction(translateAnchorReference);
    }

    private void EnableAction(InputActionReference actionReference)
    {
        // 根据动作引用获取输入动作
        var action = GetInputAction(actionReference);
        // 如果动作不为空且未启用，则启用该动作
        if (action != null && !action.enabled)
            action.Enable();
    }

    private void DisableAction(InputActionReference actionReference)
    {
        // 根据动作引用获取输入动作
        var action = GetInputAction(actionReference);
        // 如果动作不为空且已启用，则禁用该动作
        if (action != null && action.enabled)
            action.Disable();

    }

    private InputAction GetInputAction(InputActionReference actionReference)
    {
        // 如果动作引用不为空，则返回对应的输入动作，否则返回 null
        return actionReference != null ? actionReference.action : null;
    }
}
