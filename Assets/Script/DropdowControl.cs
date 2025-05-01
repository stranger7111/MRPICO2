using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;


public class PicoDropdownController : MonoBehaviour
{
    public XRRayInteractor rayInteractor; // 绑定的手柄射线交互器
    private Dropdown dropdown;
    private bool isExpanded = false;

    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(OnDropdownSelect);
    }

    void Update()
    {
        // 检测手柄射线是否命中当前下拉列表
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit) &&
            hit.collider.gameObject == gameObject)
        {
            // 检测手柄 Trigger 键按下（Pico 默认映射）
            if (Input.GetButtonDown("XRI_Right_TriggerButton") ||
                Input.GetButtonDown("XRI_Left_TriggerButton"))
            {
                ToggleDropdown();
            }
        }
    }

    private void ToggleDropdown()
    {
        isExpanded = !isExpanded;
        if (isExpanded)
        {
            dropdown.Show(); // 展开下拉列表[1,4](@ref)
        }
        else
        {
            dropdown.Hide(); // 关闭下拉列表[4](@ref)
        }
    }

    private void OnDropdownSelect(int index)
    {
        dropdown.Hide(); // 选择后自动关闭[4](@ref)
        isExpanded = false;
    }
}