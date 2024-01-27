using UnityEngine;

public class SpwanTrees : MonoBehaviour
{
    [SerializeField] private Tree treePrefab;
    [SerializeField] private BoxCollider2D spwanArea;
    public int treeNumbers = 50;

    private void Awake()
    {
        GenerateTrees(treePrefab, treeNumbers);
    }
    void GenerateTrees(Tree tree,int treeCount)
    {
        for (int i = 0; i < treeCount; i++)
        {
            var x = Random.Range(0.85f, 1.10f);
            var y = Random.Range(0.85f, 1.10f);
            var treeObj = Instantiate(tree);
            treeObj.GetComponent<Tree>().Init(x,y);
            treeObj.GetComponent<Tree>().SetRandomAction(() =>
            {
                treeObj.transform.position = RandomPose(spwanArea);
            });

            treeObj.transform.position = RandomPose(spwanArea);
        }
    }

    Vector3 RandomPose(BoxCollider2D box)
    {
        float sizeX = box.bounds.size.x;
        float sizeY = box.bounds.size.y;

        Vector3 vec3 = new Vector3(Random.Range((sizeX/2) * -1, sizeX/2),
                                   Random.Range((sizeY/2) * -1, sizeY/2)
                                   , 0);

        return vec3;
    }
}
