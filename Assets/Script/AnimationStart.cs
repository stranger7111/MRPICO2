using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRSimpleInteractable))]
public class AnimationStart: MonoBehaviour
{
    public XRRayInteractor rayInteractor;
    private Animator targetAnimator;
    public XRGrabInteractable interactable;
    // Start is called before the first frame update
    void Start()
    {
        targetAnimator = GetComponent<Animator>();
        interactable = GetComponent<XRGrabInteractable>();
        rayInteractor.selectEntered.AddListener(OnRaySelect);
        
    }


    public void OnRaySelect(SelectEnterEventArgs args)
    {
        if (targetAnimator != null)
        {
            targetAnimator.SetTrigger("Trigger"); // 确保触发器名称与 Animator 中一致
                                                // 标记动画开始
            Debug.Log("动画开启");
        }
    }
    private void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnRaySelect);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
