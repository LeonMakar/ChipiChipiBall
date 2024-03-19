using Cysharp.Threading.Tasks;
using UnityEngine;

public class X3Bonus : Bonus
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (BallsController.BALLS_COUNT < 800)
        {
            if (collision.tag == GlobalVariables.PLATFORM_TAG)
            {
                gameObject.SetActive(false);
                BallController.MultiPlyBy3AllBallsAsync();
            }
        }
        else
            gameObject.SetActive(false);
    }
}
