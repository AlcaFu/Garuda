using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using HutongGames.PlayMaker;
using TMPro;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelTitle;
    [SerializeField] private TextMeshProUGUI levelSub;
    private int previousStar;
    [HideInInspector] public int levelStars;
    [SerializeField] private Sprite[] starSprite; 
    private Image[] stars;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider staminaSlider;

    private void Awake()
    {
        stars = transform.Find("Canvas").transform.Find("Stars").GetComponentsInChildren<Image>();
        GameData gameData = JsonUtility.FromJson<GameData>(File.ReadAllText(Application.persistentDataPath + "/Player.json"));
        previousStar = gameData.levelStars[SceneManagerScript.currentLevelPlayed];
        LevelTitleChange();
    }

    private void Update()
    {
        healthSlider.value = FsmVariables.GlobalVariables.GetFsmFloat("Health").Value / FsmVariables.GlobalVariables.GetFsmFloat("Max Health").Value;
        staminaSlider.value = FsmVariables.GlobalVariables.GetFsmFloat("Stamina").Value / FsmVariables.GlobalVariables.GetFsmFloat("Max Stamina").Value;
    }

    private void LevelTitleChange()
    {
        levelTitle.text = "Level " + SceneManagerScript.currentLevelPlayed.ToString();
        switch (SceneManagerScript.currentLevelPlayed)
        {
            case 1:
                levelSub.text = "The Beginning";
                break;
            case 2:
                levelSub.text = "Find Your Own Path";
                break;
            case 3:
                levelSub.text = "The Maze";
                break;
            case 4:
                levelSub.text = "Wanna Play With Colour?";
                break;
            case 5: 
                levelSub.text = "Down With the Key!";
                break;
            case 6: 
                levelSub.text = "The Room";
                break;
            case 7: 
                levelSub.text = "The Hall";
                break;
        }
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManagerScript.levelTransition = "Main Menu";
        SceneManager.LoadScene("Loading");
    }

    public void StarIncrease()
    {
        levelStars++;
        for (int i = 0; i < levelStars; i++) 
        {
            Image starImage = stars[i];
            starImage.sprite = starSprite[1];
        }
    }

    public void Win()
    {
        JSONFormatter.SaveJSON(SceneManagerScript.currentLevelPlayed, levelStars);
        EnterNextLevel();
    }

    private void EnterNextLevel()
    {
        SceneManagerScript.currentLevelPlayed += 1;
        SceneManagerScript.levelTransition = "level" + SceneManagerScript.currentLevelPlayed.ToString();
        SceneManager.LoadScene("loading");
    }

    private void EnterPreviousLevel()
    {
        SceneManagerScript.currentLevelPlayed -= 1;
        SceneManagerScript.levelTransition = "level" + SceneManagerScript.currentLevelPlayed.ToString();
        SceneManager.LoadScene("loading");
    }

    private static void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
