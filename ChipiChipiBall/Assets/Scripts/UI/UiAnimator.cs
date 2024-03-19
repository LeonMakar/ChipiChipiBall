using UnityEngine;
using DG.Tweening;
using System.Collections;

public class UiAnimator : MonoBehaviour
{
    [SerializeField] private GameObject[] TipPanel;

    private void Start()
    {
        StartCoroutine(WaitingCoroutine());
    }

    private IEnumerator WaitingCoroutine()
    {
        while (true)
        {
            foreach (GameObject go in TipPanel)
            {
                go.transform.DOShakeScale(1, 1, 2, 1, false);
            }
            yield return new WaitForSeconds(1);
            //go.transform.DORestart();

            //yield return null;
        }
    }
}
