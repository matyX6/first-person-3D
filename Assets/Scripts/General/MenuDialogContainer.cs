using UnityEngine;

public class MenuDialogContainer : MonoBehaviour
{
    public static MenuDialog Instance { get; private set; }


    [SerializeField] private MenuDialog _instance = null;


    private void Awake()
    {
        Instance = _instance;
    }
}