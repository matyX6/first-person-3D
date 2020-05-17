using Zenject;

public class ContextInstaller : MonoInstaller<ContextInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<GamePauseEventDispatcher>().AsSingle();
        Container.Bind<AmmoPickupEventDispatcher>().AsSingle();
    }
}
