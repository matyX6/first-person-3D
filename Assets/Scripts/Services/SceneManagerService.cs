using UnityEngine.SceneManagement;

public class SceneManagerService
{
    private const string PlaySceneName = "PlayScene";

    public static void LoadPlayScene()
    {
        SceneManager.LoadScene(PlaySceneName);
    }
}
