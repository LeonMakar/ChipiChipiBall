using UnityEngine;

public class X3Bonus : Bonus
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != GlobalVariables.DEFAULT_TAG)
        {
            BallController.MultiPlyBy3AllBallsAsync().Forget();
            gameObject.SetActive(false);
        }
    }
}
