using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.XR.PXR;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System.Threading.Tasks;

//[RequireComponent(typeof(XRSimpleInteractable))]
//public class SpatialAnchor : MonoBehaviour
//{
//    private XRBaseInteractable interactable;

//    [HideInInspector]
//    public ulong anchorHandle;

//    [SerializeField]
//    private Text anchorID;

//    [SerializeField]
//    private GameObject saveIcon;

//    [SerializeField]
//    private GameObject uiCanvas;

//    [SerializeField]
//    private Button btnPersist;

//    [SerializeField]
//    private Button btnDestroyAnchor;

//    [SerializeField]
//    private Button btnDeleteAnchor;
//    private readonly object PXRSample_SpatialAnchorManager;

//    private void Awake()
//    {
//        uiCanvas.SetActive(false);
//        uiCanvas.GetComponent<Canvas>().worldCamera = Camera.main;
//        btnPersist.onClick.AddListener(OnBtnPressedPersist);
//        //btnDestroyAnchor.onClick.AddListener(OnBtnPressedDestroy);
//        //btnDeleteAnchor.onClick.AddListener(OnBtnPressedUnpersist);

//    }
//    protected void OnEnable()
//    {
//        interactable = GetComponent<XRBaseInteractable>();
//     //   interactable.firstHoverEntered.AddListener(OnFirstHoverEntered);
////        interactable.lastHoverExited.AddListener(OnLastHoverExited);
////        interactable.firstSelectEntered.AddListener(OnFirstSelectEntered);​
////58
////        interactable.lastSelectExited.AddListener(OnLastSelectExited);
////    }
//    private void OnDisable()
//    {

//    }
//    private async void OnBtnPressedPersist()
//    {
//        var result = await PXR_MixedReality.PersistSpatialAnchorAsync(anchorHandle);
//        //PXRSample_SpatialAnchorManager.Instance.SetLogInfo("PersistSpatialAnchorAsync:" + result.ToString());
//    }

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (uiCanvas.activeSelf)
//        {
//            uiCanvas.transform.LookAt(Camera.main.transform.position);
//        }
//    }
//    private void LateUpdate()
//    {
//        // 尝试定位空间锚点
//        var result = PXR_MixedReality.LocateAnchor(anchorHandle, out var position, out var rotation);
//        if (result == PxrResult.SUCCESS)
//        {
//            // 如果成功，更新当前对象的位置和旋转
//            transform.position = position;
//            transform.rotation = rotation;
//        }
//        else
//        {
//            // 记录定位锚点的结果
//            PXRSample_SpatialAnchorManager.Instance.SetLogInfo("LocateSpatialAnchor:" + result.ToString());
//        }
//    }
//   // protected virtual void OnFirstHoverEntered(HoverEnterEventArgs args) => UpdateColor();

