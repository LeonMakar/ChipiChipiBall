using UnityEngine;
using Zenject;

public abstract class Bonus : MonoBehaviour
{
    protected BallsController BallController;

    [Inject]
    private void Construct(BallsController ballsController)
    {
        BallController = ballsController;
    }

}
