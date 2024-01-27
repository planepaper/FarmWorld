using CJ.Scripts.Audio;
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
    private static int IdleAnim = Animator.StringToHash("Idle");
    private static int GroundAnim = Animator.StringToHash("Ground");
    private static int JumpAnim = Animator.StringToHash("Jump");

    [SerializeField]
    private int id;
    private CropData cropData;

    private Vector3 initPosition;
    [SerializeField]
    private float returnSpeed;

    [SerializeField]
    private VegetableState vegeState = VegetableState.Idle;
    public Canvas CanvasPrefab;

    [Header("EscapeTime")]
    private float timeForWaitingToEscape;

    [SerializeField]
    private float willEscapeTime;

    private Canvas currentCanvas = null;
    private Animator _anim;

    private bool _playJumpAnim = false;

    private void Start()
    {
        //var vegeInstance = Instantiate(gameObject,Random(InitPosition ,Vector3.zero,Vector3.one),Quaternion.identity);
        //InitPosition = vegeInstance.transform.position;

        _anim = GetComponent<Animator>();
        _anim.Play(GroundAnim);

        initPosition = transform.position;
        cropData = CropScriptableObject.Instance.GetData(id);
        willEscapeTime
         = UnityEngine.Random.Range(cropData.minEscapeTime, cropData.maxEscapeTime);
        returnSpeed = cropData.returnSpeed;
    }

    private void Update()
    {
        if (vegeState == VegetableState.Stored)
        {
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
        if (!_playJumpAnim)
        {
            _playJumpAnim = true;
            _anim.Play(JumpAnim);
        }

        transform.position
        = Vector3.MoveTowards(transform.position, initPosition, returnSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, initPosition) < float.Epsilon)
        {
            vegeState = VegetableState.Hide;
            _playJumpAnim = false;
            _anim.Play(GroundAnim);
        }
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
            gameObject.SetActive(false);
            CloseUi();
        }
    }

    public void DropItToOutside()
    {
        if (vegeState == VegetableState.Catched)
        {
            vegeState = VegetableState.Idle;
            transform.SetParent(null);
            gameObject.SetActive(true);
            OpenUi();

            _anim.Play(IdleAnim);
        }
    }

    public void DropItOnInnerFence()
    {
        if (vegeState == VegetableState.Catched)
        {
            vegeState = VegetableState.Stored;
            transform.SetParent(null);
            gameObject.SetActive(true);
            OpenUi();

            timeForWaitingToEscape = 0f;
        }
    }

    public void DestoryIt()
    {
        Destroy(this);
    }

    public void OnJump()
    {
        SfxManager.Instance.Play(SfxType.CropJump);
    }
}
