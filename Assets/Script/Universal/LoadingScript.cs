using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private Image backgroundSlider;

    private void Start()
    {
        StartCoroutine("LoadingCoroutine");
    }

    private IEnumerator LoadingCoroutine()
    {

        AsyncOperation loadedScene = SceneManager.LoadSceneAsync(SceneManagerScript.levelTransition);

        while (!loadedScene.isDone) 
        { 
            float progress = Mathf.Clamp01(loadedScene.progress / .9f);
            loadingSlider.value = progress;
            backgroundSlider.fillAmount = progress;
            yield return null;
        }

    }
}
