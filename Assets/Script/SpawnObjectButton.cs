using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class SpawnObjectButton : MonoBehaviour
{
    [Header("生成设置")]
    public GameObject spawnProfab;  // 需要生成的预制体
    public Vector3 spawnOffset = new Vector3(0, 0,1.5f); // 生成位置偏移
    private GameObject spawnedObject; // 用于跟踪当前生成的物体

    private void Start()
    {
        var button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(ToggleObject);
    }

    private void ToggleObject()
    {
        if (spawnedObject == null)
        {
            // 如果物体未生成，则生成新物体
            SpawnObject();
        }
        else
        {
            // 如果物体已生成，则销毁它
            DestroyObject();
        }
    }

    private void SpawnObject()
    {
        if (spawnProfab != null)
        {
            Vector3 spawnPosition = transform.position + transform.TransformDirection(spawnOffset);
            spawnedObject = Instantiate(spawnProfab, spawnPosition, Quaternion.identity);
        }
    }

    private void DestroyObject()
    {
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
            spawnedObject = null; // 重置引用，避免内存泄漏
        }
    }
}