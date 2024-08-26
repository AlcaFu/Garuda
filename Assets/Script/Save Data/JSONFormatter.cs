using System.IO;
using UnityEngine;

public static class JSONFormatter
{
    public static void Initialization()
    {
        if (!File.Exists(Application.persistentDataPath + "/Player.json"))
        {
            GameData gameData = new GameData();
            gameData.levelStars = new int[PlayerPrefs.GetInt("LevelTotal")];
            gameData.highestLevel = 1;
            string json = JsonUtility.ToJson(gameData);
            File.WriteAllText(Application.persistentDataPath + "/Player.json", json);
            Debug.Log(File.Exists(Application.persistentDataPath + "/Player.json"));
        }
    }

    public static void SaveJSON(int currentLevelPlayed, int levelStars)
    {
        GameData gameData = new GameData();
        string json = File.ReadAllText(Application.persistentDataPath + "/Player.json");
        gameData = JsonUtility.FromJson<GameData>(json);
        if (currentLevelPlayed >= gameData.highestLevel) gameData.highestLevel = currentLevelPlayed + 1;
        gameData.levelStars[currentLevelPlayed] = levelStars;
        json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + "/Player.json", json);
    }

    public static void LoadJSON(int highestLevel, int[] levelStars)
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/Player.json");
        GameData gameData = JsonUtility.FromJson<GameData>(json);
        highestLevel = gameData.highestLevel;
        levelStars = gameData.levelStars;
    }
}
