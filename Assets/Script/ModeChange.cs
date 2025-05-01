using UnityEngine;
using UnityEngine.UI;
using Pico.Platform;
using Pico.Platform.Samples;

public class MRModeSwitcher : MonoBehaviour
{
    //[Header("绑定参数")]
    //public Button switchButton;   // UI切换按钮
    //public GameObject vrScene;    // VR场景根物体
    //public Text modeText;          // 模式状态文本
    //private bool isMRMode = false;

    //async void Start()
    //{
    //    // 初始化Pico SDK
    //    await CoreService.InitializeAsync("YOUR_APP_ID"); // 替换为Pico开发者平台申请的APP ID
    //    await PassThroughService.InitializeAsync();

    //    // 绑定按钮事件
    //    switchButton.onClick.AddListener(ToggleMode);
    //    UpdateUI();
    //}

    //public async void ToggleMode()
    //{
    //    if (!PassThroughService.IsPassThroughSupported())
    //    {
    //        Debug.LogWarning("设备不支持MR模式");
    //        return;
    //    }

    //    isMRMode = !isMRMode;

    //    // 切换穿透模式（MR模式）
    //    var result = await PassThroughService.SetPassThroughEnabledAsync(isMRMode);
    //    if (result.IsError) return;

    //    // 控制VR场景显示
    //    vrScene.SetActive(!isMRMode);
    //    UpdateUI();
    //}

    //void UpdateUI()
    //{
    //    modeText.text = isMRMode ? "MR模式" : "VR模式";
    //    modeText.color = isMRMode ? Color.green : Color.white;
    //}
}