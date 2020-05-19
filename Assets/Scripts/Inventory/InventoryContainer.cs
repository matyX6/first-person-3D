using UnityEngine;

public class InventoryContainer : MonoBehaviour
{
    public static Inventory Instance { get; private set; }


    [SerializeField] private Inventory _instance = null;


    private void Awake()
    {
        Instance = _instance;
    }
}