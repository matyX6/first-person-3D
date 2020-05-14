using UnityEngine;

public class TooltipTextContainer : MonoBehaviour
{
    public static TooltipText Instance { get; private set; }


    [SerializeField] private TooltipText _instance = null;


    private void Awake()
    {
        Instance = _instance;
    }
}