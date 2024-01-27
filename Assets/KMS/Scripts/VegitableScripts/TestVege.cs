using CJ.Scripts.GamePlay;
using System;
using UnityEngine;
using CJ.Scripts.Crops;

public enum VegetableState
{
    Idle,
    Run,
    Catched,
    Stored,
    Hide
}

public class TestVege : MonoBehaviour
{
    [SerializeField]
    private int id;
    private CropData cropData;

    private Vector3 initPosition;
    [SerializeField]
    private float returnSpeed = 2f;

    [SerializeField]
    private VegetableState vegeState = VegetableState.Idle;
    public Canvas CanvasPrefab;

    [Header("EscapeTime")]
    private float timeForWaitingToEscape;

    [SerializeField]
    private float willEscapeTime;

    private Canvas currentCanvas = null;

    private void Start()
    {
        //var vegeInstance = Instantiate(gameObject,Random(InitPosition ,Vector3.zero,Vector3.one),Quaternion.identity);
        //InitPosition = vegeInstance.transform.position;

        initPosition = transform.position;
        cropData = CropScriptableObject.Instance.GetData(id);
        willEscapeTime
         = UnityEngine.Random.Range(cropData.minEscapeTime, cropData.maxEscapeTime);
    }

    private void Update()
    {
        if (vegeState == VegetableState.Stored)
        {
            Debug.Log(timeForWaitingToEscape);
            timeForWaitingToEscape += Time.deltaTime;
            if (timeForWaitingToEscape > willEscapeTime)
            {
                StartToEscape();
            }
        }
    }

    public int GetID()
    {
        return id;
    }

    private void StartToEscape()
    {
        transform.position
        = Vector3.MoveTowards(transform.position, initPosition, returnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            OpenUi();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CloseUi();
        }
    }

    public void OpenUi()
    {
        if (currentCanvas == null)
        {
            var canvas = Instantiate(CanvasPrefab, this.transform);
            canvas.transform.position = new Vector2(transform.position.x, transform.position.y + 2.5f);
            currentCanvas = canvas;
        }
        currentCanvas.enabled = true;
    }
    public void CloseUi()
    {
        currentCanvas.enabled = false;
    }

    public void PickIt(Transform player)
    {
        if (vegeState != VegetableState.Catched)
        {
            vegeState = VegetableState.Catched;
            transform.SetParent(player.transform);
            transform.position = player.transform.position;
            CloseUi();
        }
    }

    public void DropItToOutside()
    {
        if (vegeState == VegetableState.Catched)
        {
            vegeState = VegetableState.Idle;
            transform.SetParent(null);
            OpenUi();
        }
    }

    public void DropItOnInnerFence()
    {
        if (vegeState == VegetableState.Catched)
        {
            vegeState = VegetableState.Stored;
            transform.SetParent(null);
            OpenUi();
            //TODO(Seungpyo): Ready to Escape
            timeForWaitingToEscape = 0f;
        }
    }

    // public void InteractionWork(Transform player)
    // {
    //     if (vegeState != VegetableState.Catched)
    //     {
    //         // 잡기가 실패하면 그냥 리턴
    //         if (!GameManager.Instance.TryCatchCrop(id, gameObject))
    //         {
    //             return;
    //         }

    //         vegeState = VegetableState.Catched;
    //         transform.SetParent(player.transform);
    //         transform.position = player.transform.position;
    //         CloseUi();


    //     }
    //     else if (vegeState == VegetableState.Catched)
    //     {
    //         vegeState = VegetableState.Idle;
    //         transform.SetParent(null);
    //         OpenUi();
    //     }
    //     else if ()

    //         Debug.Log(vegeState.ToString());
    // }
}

//public Vector3 Random(Vector3 myVector, Vector3 min, Vector3 max)
//{
//    return myVector = new Vector3(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y), UnityEngine.Random.Range(0, 0));
//}

//private VegiState vegiState = VegiState.Idle;
//private GameObject CanvasPrefab;

//private Canvas UiCanvas;
//public List<Canvas> UiPool;
//private Canvas currentCanvas;

//private void Start()
//{
//    UiCanvas = null;
//}

//public void OpenUi()
//{
//    currentCanvas = UiPool.Count > 0 ? UiPool[0] : IncreaseList();
//    UiCanvas = currentCanvas;
//    UiPool.Remove(UiPool[0]);

//    if (UiCanvas.enabled == false)
//    {
//        UiCanvas.enabled = true;
//    }
//}
//public void CloseUi()
//{
//    //if (currentCanvas != null)
//    //{
//    //    UiPool.Add(currentCanvas);
//    //}
//    UiPool.Add(currentCanvas);

//    if (UiCanvas.enabled == true)
//    {
//        UiCanvas.enabled = false;
//    }
//}

//public void InteractionWork(Transform player)
//{
//    transform.SetParent(player.transform);
//    CloseUi();
//}

//Canvas IncreaseList()
//{
//    var canvas = Instantiate(CanvasPrefab.GetComponent<Canvas>());
//    UiPool.Add(canvas);
//    canvas.enabled = false;
//    return canvas;
//}
