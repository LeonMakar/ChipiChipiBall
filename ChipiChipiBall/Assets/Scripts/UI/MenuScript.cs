using TMPro;
using UnityEngine;
using YG;

public class MenuScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _lvlText;


    private void Awake()
    {
        YandexGame.GetDataEvent += SetLvlPaasedAmmount;
    }
    void Start()
    {
        if (YandexGame.GetDataEvent != null)
            SetLvlPaasedAmmount();
    }

    private void SetLvlPaasedAmmount()
    {
        _lvlText.text = (YandexGame.savesData.NextLvlID - 1).ToString();
    }
}
