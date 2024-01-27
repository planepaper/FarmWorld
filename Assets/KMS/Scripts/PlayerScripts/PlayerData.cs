using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] TestVege nearTarget = null;
    List<TestVege> vegeLists = new List<TestVege>();
    Stack<TestVege> vegeStacks = new Stack<TestVege>();

    public GameObject fullnotifyPopUpPrefab;
    private GameObject notifyPopUp = null;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out TestVege vege))
        {
            nearTarget = vege;
            vege.OpenUi();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TestVege vege))
        {
            nearTarget = null;
            vege.CloseUi();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Interaction(nearTarget);
        }
    }

    private void Interaction(TestVege target)
    {
        if (vegeStacks.Count < 5 && nearTarget != null)
        {
            target.GetComponent<iInteraction>().InteractionWork(transform);
            target.RemoveAction(() => vegeStacks.Pop());
            vegeStacks.Push(target);
        }
        else if(vegeStacks.Count > 0 && nearTarget == null)
        {
            var vege = vegeStacks.Peek();
            vege.InteractionWork(transform);
        }
        else
        {
            StartCoroutine(ShowFullPopUp());
        }
    }

    IEnumerator ShowFullPopUp()
    {
        if (notifyPopUp == null)
        {
            notifyPopUp = Instantiate(fullnotifyPopUpPrefab);
        }
        yield return new WaitForSeconds(2f);
        Destroy(notifyPopUp);
    }
}
