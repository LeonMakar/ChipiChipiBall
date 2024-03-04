using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag != GlobalVariables.DEFAULT_TAG)
        {
            Destroy(gameObject);
        }
    }
}
