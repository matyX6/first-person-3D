using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }

    [SerializeField] private GameObject _objectToPool = null;
    [SerializeField] private int _poolCount = 30;
    private List<GameObject> _objectList = new List<GameObject>();


    public List<GameObject> ObjectList { get { return _objectList; } }
    public GameObject ObjectToPool { get { return _objectToPool; } }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(transform);
    }

    private void Start()
    {
        InstantiatePoolObjects();
    }

    private void InstantiatePoolObjects()
    {
        for (int i = 0; i < _poolCount; i++)
        {
            GameObject objectToPoll = Instantiate(_objectToPool);
            _objectList.Add(objectToPoll);
            objectToPoll.transform.parent = transform;
            objectToPoll.SetActive(false);
        }
    }
}
