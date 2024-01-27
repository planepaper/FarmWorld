using CJ.Scripts.Common;
using CJ.Scripts.Crops;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Math = System.Math;

public class VegetableSpawner : MonoSingleton<VegetableSpawner>
{
    private Dictionary<int, List<GameObject>> _spawnedInfo = new Dictionary<int, List<GameObject>>();
    [SerializeField] private BoxCollider2D _mapCollider;

    public GameObject SpawnVegetable()
    {
        int id = -1;
        CropData data = null;

        for (var i = 0; i < CropScriptableObject.Instance.Count; ++i)
        {
            data = CropScriptableObject.Instance.GetData(i);

            if (!_spawnedInfo.ContainsKey(i))
            {
                _spawnedInfo.Add(i, new List<GameObject>());

                id = i;
                break;
            }

            var list = _spawnedInfo[i];

            if (list.Count < data.maximumSpawnCount) { id = i; break; }
        }

        if (id == -1) { return null; }

        int loopCount = 0;
        Vector3 pos = GetSpawnPosition(id);

        do
        {
            pos = GetSpawnPosition(id);
            loopCount++;
        } while (!_mapCollider.bounds.Contains(pos) && !Physics.CheckBox(pos, data.prefab.transform.localScale * 2) && loopCount < 100);

        if (loopCount == 100)
        {
            Debug.LogError("Failed to get position inside of map");
            return null;
        }

        GameObject go = Instantiate(data.prefab, pos, Quaternion.identity);

        _spawnedInfo[id].Add(go);

        return go;
    }

    Vector3 GetSpawnPosition(int id)
    {
        var data = CropScriptableObject.Instance.GetData(id);
        if (data == null)
        {
            return Vector3.zero;
        }

        float ratio = (float) data.minSpawnDistance / (float) data.maxSpawnDistance;
        float radius = Mathf.Sqrt(Random.Range(ratio * ratio, 1f)) * data.maxSpawnDistance;

        float angle = Random.Range(0f, 2f * (float) Math.PI);
        var dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        return dir * radius;
    }
}
