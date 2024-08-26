using UnityEngine;
using UnityEngine.Audio;

public class InitializationScript : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    private float windowModeStateHelper, refreshRateStateHelper;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("graphicsStatePP"))
        {
            PlayerPrefs.SetFloat("graphicsStatePP", 1);
            PlayerPrefs.SetFloat("vSyncSwitchPP", 0);
            PlayerPrefs.SetFloat("windowModeStatePP", 0);
            PlayerPrefs.SetFloat("refreshRateStatePP", 1);
        }

        audioMixer.SetFloat("master", Mathf.Lerp(-80, 10, PlayerPrefs.GetFloat("PPMaster") / 100));
        audioMixer.SetFloat("bgm", Mathf.Lerp(-80, 10, PlayerPrefs.GetFloat("PPBgm") / 100));
        audioMixer.SetFloat("sfx", Mathf.Lerp(-80, 10, PlayerPrefs.GetFloat("PPSfx") / 100));

        QualitySettings.SetQualityLevel((int)PlayerPrefs.GetFloat("graphicsStatePP"));
        QualitySettings.vSyncCount = (int)PlayerPrefs.GetFloat("vSyncSwitchPP");

        windowModeStateHelper = PlayerPrefs.GetFloat("windowModeStatePP");
        switch (windowModeStateHelper)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
        }

        refreshRateStateHelper = PlayerPrefs.GetFloat("refreshRateStatePP");
        switch (refreshRateStateHelper)
        {
            case 0:
                Application.targetFrameRate = 30;
                break;
            case 1:
                Application.targetFrameRate = 60;
                break;
            case 2:
                Application.targetFrameRate = 75;
                break;
            case 3:
                Application.targetFrameRate = 90;
                break;
            case 4:
                Application.targetFrameRate = 120;
                break;
            case 5:
                Application.targetFrameRate = 144;
                break;
            case 6:
                Application.targetFrameRate = 165;
                break;
            case 7:
                Application.targetFrameRate = 180;
                break;
            case 8:
                Application.targetFrameRate = 240;
                break;
            case 9:
                Application.targetFrameRate = 360;
                break;
            case 10:
                Application.targetFrameRate = 540;
                break;
        }
    }
}
