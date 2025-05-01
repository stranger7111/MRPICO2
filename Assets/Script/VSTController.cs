using UnityEngine;
using Unity.XR.PXR;
using UnityEngine.UI;

public class VSTSwitchController : MonoBehaviour
{
    [Header("UI 组件")]
    public Button switchButton;  // 绑定切换按钮
    public Text buttonText;       // 按钮显示的文本组件

    private bool isVSTEnabled = false;

    void Start()
    {
        // 初始状态设置为 VR 模式
        PXR_Manager.EnableVideoSeeThrough = true;
        UpdateButtonText();

        // 监听透视状态变化事件
        PXR_Manager.VstDisplayStatusChanged += OnVSTStatusChanged;

        // 绑定按钮点击事件
        switchButton.onClick.AddListener(ToggleVST);
    }

    private void ToggleVST()
    {
        isVSTEnabled = !isVSTEnabled;
        PXR_Manager.EnableVideoSeeThrough = isVSTEnabled;
    }

    private void OnVSTStatusChanged(PxrVstStatus status)
    {
        switch (status)
        {
            case PxrVstStatus.Enabled:
                isVSTEnabled = true;
                Debug.Log("视频透视已激活");
                break;
            case PxrVstStatus.Disabled:
                isVSTEnabled = false;
                Debug.Log("VR 模式已激活");
                break;
        }
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        buttonText.text = isVSTEnabled ? "切换至 VR" : "切换至透视";
    }

    void OnDestroy()
    {
        // 清理事件监听
        PXR_Manager.VstDisplayStatusChanged -= OnVSTStatusChanged;
    }
}