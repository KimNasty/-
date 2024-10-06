using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSurface : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjects;

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        for (int i = -20; i < 20; i++)
        {
            for (int j = -20; j < 20; j++) 
            {
                int index = Random.Range(0, _gameObjects.Length - 1);
                Instantiate(_gameObjects[index], new Vector3(j*2.5f, i*2.5f , 0), transform.rotation);
            }
        }
    }
}
