using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller, IInitializable
{
    [SerializeField] private PaddleMooving _paddleMooving;
    [SerializeField] private SimpleBall _ball;
    [SerializeField] private MediaMaterialController _mediaMaterialController;

    public void Initialize()
    {
        var ball = Container.InstantiatePrefab(_ball.gameObject);
        ball.transform.position = _paddleMooving.transform.position + Vector3.up;
        GlobalVariables.MEDIA = _mediaMaterialController;

    }

    public override void InstallBindings()
    {
        BindSceneInstalletInterfaces();
        BindPaddleMoovingScript();
        BindBallFactory();
        BindMediaController();

    }

    private void BindMediaController()
    {
        Container
                    .Bind<MediaMaterialController>()
                    .FromInstance(_mediaMaterialController)
                    .NonLazy();
    }

    private void BindSceneInstalletInterfaces()
    {
        Container
             .BindInterfacesTo<SceneInstaller>()
             .FromInstance(this)
             .AsSingle()
             .NonLazy();
    }

    private void BindBallFactory()
    {
        Container
            .BindFactory<SimpleBall, SimpleBall.Factory>()
            .FromComponentInNewPrefab(_ball);
    }

    private void BindPaddleMoovingScript()
    {
        Container
           .Bind<PaddleMooving>()
           .FromInstance(_paddleMooving)
           .AsSingle();
    }
}
