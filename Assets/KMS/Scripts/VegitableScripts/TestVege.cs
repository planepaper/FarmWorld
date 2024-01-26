using UnityEngine;
public enum VegetableState
{
    Idle,
    Run,
    Catched,
    Hide
}

public class TestVege : MonoBehaviour, iInteraction
{
    private Vector3 InitPosition;
    private VegetableState vegeState = VegetableState.Idle;
    public Canvas CanvasPrefab;
    
    private Canvas currentCanvas = null;



    private void Start()
    {
        //var vegeInstance = Instantiate(gameObject,Random(InitPosition ,Vector3.zero,Vector3.one),Quaternion.identity);
        //InitPosition = vegeInstance.transform.position;
    }

    public void OpenUi()
    {
        if (currentCanvas == null)
        {
            var canvas = Instantiate(CanvasPrefab, this.transform);
            currentCanvas = canvas;
        }
        currentCanvas.enabled = true;
    }
    public void CloseUi()
    {
        currentCanvas.enabled = false;
    }

    public void InteractionWork(Transform player)
    {
        if(vegeState != VegetableState.Catched)
        {
            vegeState = VegetableState.Catched;
            transform.SetParent(player.transform);
            transform.position = player.transform.position;
            CloseUi();
        }
        Debug.Log(vegeState.ToString());
    }

    public void Escape()
    {
        // Jump throw wall
        // Run to Init Position
        // Vege Animation
        transform.position = InitPosition;
    }

    
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
