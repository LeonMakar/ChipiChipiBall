
using Zenject;
public class ProjectInstaller : MonoInstaller, IInitializable
{
    public void Initialize()
    {
        Container.Resolve<DefaultActionMap>().Simple.Enable();
    }

    public override void InstallBindings()
    {
        BindInstallerInterfases();
        BindDefaultActionMap();
        BindLoader();
        BindSaver();
    }

    private void BindSaver()
    {
        Container
            .Bind<Saver>()
            .AsSingle()
            .NonLazy();
    }

    private void BindLoader()
    {
        Container
            .Bind<Loader>()
            .AsSingle()
            .NonLazy();
    }

    private void BindDefaultActionMap()
    {
        Container
            .Bind<DefaultActionMap>()
            .AsSingle()
            .NonLazy();
    }

    private void BindInstallerInterfases()
    {
        Container
             .BindInterfacesTo<ProjectInstaller>()
             .FromInstance(this)
             .AsSingle()
             .NonLazy();
    }
}
