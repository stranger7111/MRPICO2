using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;


public class DropdownExtend : MonoBehaviour
{
    public Button button;
    public  Dropdown dropdown;
    XRSimpleInteractable Interactable;
    bool isExpanded;
    private void Start()
    {
        Interactable = GetComponent<XRSimpleInteractable>();
        Interactable.selectEntered.AddListener(OnButtonClicked);
        isExpanded = false;
        dropdown = GetComponent<Dropdown>();
    }
    public void OnButtonClicked(SelectEnterEventArgs args)
    {
        
        if (dropdown != null)
        {
            if (isExpanded == false)
            {
                dropdown.Show();
            }
            else
            {
                dropdown.Hide();
            }
        }
    }
}