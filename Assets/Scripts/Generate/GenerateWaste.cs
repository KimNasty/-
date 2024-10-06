using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWaste : MonoBehaviour
{
    private float _minDistance = 2f;
    [SerializeField] private List<GameObject> _prefabs; 
    private int _numberOfElements = 50;

    private List<Vector2> _spawnPositions = new List<Vector2>();

    void Start()
    {
        GenerateRandomElements();
    }

    private void GenerateRandomElements()
    {
        for (int i = 0; i < _numberOfElements; i++)
        {
            Vector2 spawnPosition = GetRandomPosition();

            int attempts = 0;
            while (!IsValidPosition(spawnPosition) && attempts < 200)
            {
                spawnPosition = GetRandomPosition();
                attempts++;
            }

            if (attempts < 100)
            {
                _spawnPositions.Add(spawnPosition);
                SpawnElement(spawnPosition);
            }
        }
    }

    private Vector2 GetRandomPosition()
    {
        float x = Random.Range(-20, 20);
        float y = Random.Range(-20, 20);
        return new Vector2(x, y);
    }

    private bool IsValidPosition(Vector2 position)
    {
        foreach (Vector2 existingPosition in _spawnPositions)
        {
            if (Vector2.Distance(existingPosition, position) < _minDistance)
            {
                return false;
            }
        }
        return true;
    }

    private void SpawnElement(Vector2 position)
    {
        int prefabIndex = Random.Range(0, _prefabs.Count);
        GameObject prefab = _prefabs[prefabIndex];
        Instantiate(prefab, position, Quaternion.identity);
    }
}

