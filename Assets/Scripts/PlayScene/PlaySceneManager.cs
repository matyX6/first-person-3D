using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlaySceneManager : MonoBehaviour
{
    private const string EnemyTag = "Enemy";
    private const string GreenCubeTag = "GreenCube";
    private const string YellowCubeTag = "YellowCube";


    [Inject] private readonly GamePauseEventDispatcher _gamePauseEventDispatcher = null;
    [SerializeField] private GameObject _player = null;
    [SerializeField] private GameObject _playerUi = null;
    [SerializeField] private PlayerMovement _playerMovement = null;
    [SerializeField] private MouseLook _mouseLook = null;
    [SerializeField] private Gun _gun = null;
    [Header("Ui number elements")]
    [SerializeField] private Text _enemyText = null;
    [SerializeField] private Text _greenCubeText = null;
    [SerializeField] private Text _yellowCubeText = null;
    private int _enemiesMax = 0;
    private int _greenCubesMax = 0;
    private int _yellowCubesMax = 0;
    GameObject[] enemies = null;
    GameObject[] greenCubes = null;
    GameObject[] yellowCubes = null;
    private bool _inputCheckEnabled = true;


    private void Awake()
    {
        CursorService.HideAndLock();
        _gamePauseEventDispatcher.OnGamePaused += DisablePlayerComponents;
        _gamePauseEventDispatcher.OnGameResumed += EnablePlayerComponents;
        _gamePauseEventDispatcher.OnPlayerDeath += DisableInputCheck;
    }

    private void Start()
    {
        CheckForEnemiesAndCubes();

        _enemiesMax = enemies.Length;
        _greenCubesMax = greenCubes.Length;
        _yellowCubesMax = yellowCubes.Length;

        UpdateUiText();
    }

    private void CheckForEnemiesAndCubes()
    {
        enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        greenCubes = GameObject.FindGameObjectsWithTag(GreenCubeTag);
        yellowCubes = GameObject.FindGameObjectsWithTag(YellowCubeTag);
    }

    private void UpdateUiText()
    {
        int killedEnemies = _enemiesMax - enemies.Length;
        int collectedGreenCubes = _greenCubesMax - greenCubes.Length;
        int collectedYellowCubes = _yellowCubesMax - yellowCubes.Length;

        _enemyText.text = killedEnemies + "/" + _enemiesMax;
        _greenCubeText.text = collectedGreenCubes + "/" + _greenCubesMax;
        _yellowCubeText.text = collectedYellowCubes + "/" + _yellowCubesMax;
    }

    private void OnDestroy()
    {
        _gamePauseEventDispatcher.OnGamePaused -= DisablePlayerComponents;
        _gamePauseEventDispatcher.OnGameResumed -= EnablePlayerComponents;
        _gamePauseEventDispatcher.OnPlayerDeath -= DisableInputCheck;
    }

    private void Update()
    {
        CheckForPauseInput();
    }

    private void CheckForPauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _inputCheckEnabled)
            MenuDialogService.TogglePauseMenuDialog();
    }

    private void EnablePlayerComponents()
    {
        if (_player != null)
        {
            _playerMovement.enabled = true;
            _mouseLook.enabled = true;
            _gun.enabled = true;
            _playerUi.SetActive(true);
        }

        CursorService.HideAndLock();
    }

    private void DisablePlayerComponents()
    {
        if (_player != null)
        {
            _playerMovement.enabled = false;
            _mouseLook.enabled = false;
            _gun.enabled = false;
            _playerUi.SetActive(false);
        }

        CursorService.ShowAndUnlock();
    }

    private void DisableInputCheck()
    {
        _inputCheckEnabled = false;
    }
}
