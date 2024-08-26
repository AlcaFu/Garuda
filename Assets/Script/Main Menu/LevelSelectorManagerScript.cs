using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class LevelSelectorManagerScript : MonoBehaviour
{
    private GameData gameData;
    public GameObject[] levels;
    public int highestLevel;
    public int[] starslevel;
    [SerializeField] Sprite[] starsSprite;

    private void Awake()
    {
        Button[] buttonLevel = GetComponentsInChildren<Button>();
        PlayerPrefs.SetInt("LevelTotal", buttonLevel.Length);
        JSONFormatter.Initialization();
    }

    private void Start()
    {
        Initialization();
    }

    private void Initialization()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/Player.json");
        gameData = JsonUtility.FromJson<GameData>(json);
        highestLevel = gameData.highestLevel;
        starslevel = gameData.levelStars;
        Debug.Log(starslevel[0]);

        Button[] buttonLevel = GetComponentsInChildren<Button>();
        levels = new GameObject[buttonLevel.Length];
        for (int i = 0; i < buttonLevel.Length; i++)
        {
            levels[i] = buttonLevel[i].gameObject;
            int levelIndex = i;
            buttonLevel[i].onClick.AddListener(() => LevelButtonOnClick(levelIndex));
            buttonLevel[i].onClick.AddListener(() => GetCurrentLevelPlayed(levelIndex));
            TextMeshProUGUI levelNumber = levels[i].transform.Find("Logo").transform.Find("Number").GetComponent<TextMeshProUGUI>();
            levelNumber.text = (i + 1).ToString();
            Image[] transformsStar = levels[i].transform.Find("Stars").GetComponentsInChildren<Image>();
            for (int j = 0; j < starslevel[i] ; j++)
            {
                transformsStar[j].sprite = starsSprite[1];
            }
            if (i + 1 > highestLevel)
            {
                levels[i] = buttonLevel[i].gameObject;
                levels[i].GetComponent<Button>().enabled = false;
                GameObject number = levels[i].transform.Find("Logo").transform.Find("Number").gameObject;
                GameObject lockLevel = levels[i].transform.Find("Logo").transform.Find("Lock").gameObject;
                GameObject starsLevel = levels[i].transform.Find("Stars").gameObject;
                number.SetActive(false);
                lockLevel.SetActive(true);
                starsLevel.SetActive(false);
            }
        }
    }

    private void LevelButtonOnClick(int levelNumber)
    {
        SceneManagerScript.levelTransition = "level" + (levelNumber + 1).ToString();
        SceneManager.LoadScene("Loading");
    }

    private void GetCurrentLevelPlayed(int levelNumber)
    {
        SceneManagerScript.currentLevelPlayed = levelNumber + 1;
    }
}
