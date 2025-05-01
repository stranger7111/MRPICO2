using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionTest: MonoBehaviour
{
    // Start is called before the first frame update
    public InputActionReference menu;
    public Canvas canvas;
    private void Start()
    {
        if (menu != null)
        {
            menu.action.Enable();
            menu.action.performed += ToggleMenu;
        }
    }
    public void ToggleMenu(InputAction.CallbackContext context)
    {
        canvas.enabled = !canvas.enabled;
    }
}
