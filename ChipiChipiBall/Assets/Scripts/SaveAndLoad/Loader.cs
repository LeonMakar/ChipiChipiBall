using UnityEngine.SceneManagement;
using YG;

public class Loader
{
    public void LoadScene()
    {
        SceneManager.LoadScene(YandexGame.savesData.NextLvlID);
    }
}
