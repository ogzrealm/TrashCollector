using UnityEngine;
using System.Collections.Generic;

public class TrashSpawnScript : MonoBehaviour
{
    [SerializeField] private List<Transform> trashSpawn;
    [SerializeField] private GameObject trashPrefab;

    private List<int> _usedIndexes = new List<int>();

    private void Start()
    {
        RandomTrashSpawn();
    }

    private void RandomTrashSpawn()
    {
        _usedIndexes.Clear();

        for (int i = 0; i < 10; i++)
        {
            int randIndex = GetUniqueIndex();
            SpawnTrash(randIndex);
        }
    }

    public void SingleTrashSpawn()
    {
        if (_usedIndexes.Count >= trashSpawn.Count) return;

        int randIndex = GetUniqueIndex();
        SpawnTrash(randIndex);
    }

    private int GetUniqueIndex()
    {
        int randIndex;
        do
        {
            randIndex = Random.Range(0, trashSpawn.Count);
        }
        while (_usedIndexes.Contains(randIndex));

        return randIndex;
    }

    private void SpawnTrash(int index)
    {
        GameObject trash = Instantiate(
            trashPrefab,
            trashSpawn[index].position,
            trashSpawn[index].rotation
        );
        trash.transform.SetParent(trashSpawn[index]);
        _usedIndexes.Add(index);
    }
}