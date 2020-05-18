using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameProgressManager : MonoBehaviour
{
    private const string EnemyTag = "Enemy";
    private const string GreenCubeTag = "GreenCube";
    private const string YellowCubeTag = "YellowCube";


    [Inject] private readonly ObjectPickupEventDispatcher _objectPickupEventDispatcher = null;
    [SerializeField] private Text _enemyText = null;
    [SerializeField] private Text _greenCubeText = null;
    [SerializeField] private Text _yellowCubeText = null;
    private int _enemiesMax = 0;
    private int _greenCubesMax = 0;
    private int _yellowCubesMax = 0;
    GameObject[] _enemies = null;
    GameObject[] _greenCubes = null;
    GameObject[] _yellowCubes = null;


    private void Awake()
    {
        _objectPickupEventDispatcher.OnGreenCubePickedUp += UpdateGreenCubesCount;
        _objectPickupEventDispatcher.OnYellowCubePickedUp += UpdateYellowCubesCount;
    }

    private void OnDestroy()
    {
        _objectPickupEventDispatcher.OnGreenCubePickedUp -= UpdateGreenCubesCount;
        _objectPickupEventDispatcher.OnYellowCubePickedUp -= UpdateYellowCubesCount;
    }

    private void Start()
    {
        UpdateInitialValues();
    }

    private GameObject[] FindGameObjectsWithTag(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag);
    }

    private void UpdateUiElementCount(Text textToUpdate, int maxCount, int currentCount)
    {
        int leftCount = maxCount - currentCount;
        textToUpdate.text = leftCount + "/" + currentCount;
    }

    private void UpdateYellowCubesCount()
    {
        _yellowCubes = FindGameObjectsWithTag(YellowCubeTag);
        UpdateUiElementCount(_yellowCubeText, _yellowCubesMax, _yellowCubes.Length);
        CheckIfLevelPassed();
    }

    private void UpdateGreenCubesCount()
    {
        _greenCubes = FindGameObjectsWithTag(GreenCubeTag);
        UpdateUiElementCount(_greenCubeText, _greenCubesMax, _greenCubes.Length);
        CheckIfLevelPassed();
    }

    private void UpdateEnemiesKilledCount()
    {
        _enemies = FindGameObjectsWithTag(EnemyTag);
        UpdateUiElementCount(_enemyText, _enemiesMax, _enemies.Length);
        CheckIfLevelPassed();
    }

    private void CheckIfLevelPassed()
    {
        bool levelPassed = _enemies.Length == 0 && _greenCubes.Length == 0 && _yellowCubes.Length == 0;
        if (levelPassed) { }
            //win
    }

    private void UpdateInitialValues()
    {
        _yellowCubes = FindGameObjectsWithTag(YellowCubeTag);
        _greenCubes = FindGameObjectsWithTag(GreenCubeTag);
        _enemies = FindGameObjectsWithTag(EnemyTag);

        _yellowCubesMax = _yellowCubes.Length;
        _greenCubesMax = _greenCubes.Length;
        _enemiesMax = _enemies.Length;

        UpdateYellowCubesCount();
        UpdateGreenCubesCount();
        UpdateEnemiesKilledCount();
    }
}
