using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRSimpleInteractable))] // 强制要求挂载XR交互组件
public class EntranceButton : MonoBehaviour
{
    // 按钮动画控制器
    public Animator buttonAnimator1;

    // 动画状态标记（代码中未实际使用）
    private bool isAnimating;

    // XR交互组件引用
    private XRSimpleInteractable interactable;

    // 动画状态信息存储
    AnimatorStateInfo stateInfo;

    // 初始化方法
    private void Start()
    {
        // 获取XR交互组件
        interactable = GetComponent<XRSimpleInteractable>();
        // 绑定选择事件监听器
        interactable.selectEntered.AddListener(OnButtonClicked);
    }

    // 每帧更新检测动画状态
    private void Update()
    {
        // 持续获取当前动画状态
        stateInfo = buttonAnimator1.GetCurrentAnimatorStateInfo(0);

        // 检测特定动画是否播放完成
        if (stateInfo.IsName("Scene") && stateInfo.normalizedTime >= 0.99f)
        {
            Debug.Log("动画结束");
            SceneManager.LoadScene(2); // 加载场景2
        }
    }

    // 按钮点击事件处理
    public void OnButtonClicked(SelectEnterEventArgs args)
    {
        if (buttonAnimator1 != null)
        {
            buttonAnimator1.SetTrigger("Click"); // 触发按钮动画
            Debug.Log("动画开启");
        }
    }

    // 对象销毁时的清理
    private void OnDestroy()
    {
        // 移除事件监听防止内存泄漏
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnButtonClicked);
        }
    }
}