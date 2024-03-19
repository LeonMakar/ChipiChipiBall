using YG;

public class Saver
{
    public void SaveCompletedScene(int sceneId)
    {
        //YandexGame.savesData.CompletedSceneID[sceneId] = true;
        YandexGame.savesData.NextLvlID = sceneId + 1;
        YandexGame.SaveProgress();
    }
}

