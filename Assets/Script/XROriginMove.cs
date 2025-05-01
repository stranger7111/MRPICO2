using UnityEngine;
using UnityEngine.XR;

public class XROriginMove: MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float rotateSpeed = 30.0f;
    private Transform vrCamera;

    void Start()
    {
        vrCamera = Camera.main.transform; // 获取Pico VR摄像机
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    // 左摇杆控制移动
    private void HandleMovement()
    {
        Vector2 leftStick = new Vector2(
            Input.GetAxis("XRI_Left_Primary2DAxis_Horizontal"),
            Input.GetAxis("XRI_Left_Primary2DAxis_Vertical")
        );
        // 基于摄像机方向计算移动向量
        Vector3 moveDirection = (vrCamera.forward * leftStick.y + vrCamera.right * leftStick.x).normalized;
        moveDirection.y = 0; // 保持水平移动
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    // 右摇杆控制视角旋转
    private void HandleRotation()
    {
        Vector2 rightStick = new Vector2(
            Input.GetAxis("XRI_Right_Primary2DAxis_Horizontal"),
            Input.GetAxis("XRI_Right_Primary2DAxis_Vertical")
        );
        // 绕Y轴旋转（水平视角）
        transform.Rotate(0, rightStick.x * rotateSpeed * Time.deltaTime, 0);
    }
}