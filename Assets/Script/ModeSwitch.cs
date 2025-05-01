using UnityEngine;
using Unity.XR.PXR;

public class VideoSeeThroughController : MonoBehaviour
{
    void Start()
    {
        // 直接启用视频透视[1,3](@ref)
        PXR_Manager.EnableVideoSeeThrough = false;
    }

    // 若需动态切换，可绑定按钮事件
    public void ToggleVideoSeeThrough(bool enable)
    {
        PXR_Manager.EnableVideoSeeThrough = enable;
    }
}