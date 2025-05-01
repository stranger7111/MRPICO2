using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))] // 强制要求挂载Dropdown组件
public class SceneSwitcher : MonoBehaviour
{
    [SerializeField]
    private Dropdown sceneDropdown; // Inspector面板绑定的下拉菜单组件

    public Animator animator; // 动画控制器组件

    void Start()
    {
        // 获取组件引用
        animator = GetComponent<Animator>(); // 获取当前对象的Animator
        sceneDropdown = gameObject.GetComponent<Dropdown>(); // 获取当前对象的Dropdown

        // 添加下拉菜单值变化监听
        sceneDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    // 下拉菜单值变化事件处理
    public void OnDropdownValueChanged(int index)
    {
        // 当选择第一个选项时触发动画
        if (index == 0)
        {
            animator.SetTrigger("Click"); // 需要Animator中存在"Click"触发器
        }

        // 加载对应场景（所有选项通用）
        if (sceneDropdown != null)
        {
            SceneManager.LoadScene(index); // 根据下拉菜单索引加载场景
        }
    }
}