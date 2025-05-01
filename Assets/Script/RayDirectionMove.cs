using UnityEngine.XR;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(CharacterController))]
public class PicoVerticalMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;    // 移动速度
    [SerializeField] private float maxHeight = 10f;    // 最大高度
    [SerializeField] private float minHeight = 0.5f;   // 最低高度
    [SerializeField] private XRNode controllerNode = XRNode.RightHand; // 控制手柄

    private CharacterController characterController;
    private InputDevice targetDevice;
    private float verticalInput;
    private float smoothInput;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        InitializeDevice();
    }

    void InitializeDevice()
    {
        targetDevice = InputDevices.GetDeviceAtXRNode(controllerNode);
    }

    void Update()
    {
        // 手柄输入检测
        if (!targetDevice.isValid)
            InitializeDevice();

        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 axis))
            verticalInput = axis.y;

        // 输入平滑处理
        smoothInput = Mathf.Lerp(smoothInput, verticalInput, Time.deltaTime * 10f);

        // 计算移动向量
        Vector3 movement = Vector3.up * smoothInput * moveSpeed * Time.deltaTime;

        // 应用移动并限制高度
        characterController.Move(movement);
        ClampHeight();
    }

    void ClampHeight()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minHeight, maxHeight);
        transform.position = pos;
    }
}