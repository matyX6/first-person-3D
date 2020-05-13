using Zenject;

public class PlaySceneInstaller : MonoInstaller<PlaySceneInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<GamePauseEventDispatcher>().AsSingle();
    }
}
