using TMPro;
using UnityEngine;

public class GraphicsSettingsScript : MonoBehaviour
{
    private TextMeshProUGUI graphicsText, vsyncText, windowModeText, refreshRateText, resolutionText;
    private float graphicsState, windowModeState, refreshRateState, resolutionState;
    private float vsyncSwitch;

    private void Awake()
    {
        graphicsText = transform.Find("Graphics").transform.Find("Value").GetComponent<TextMeshProUGUI>();
        vsyncText = transform.Find("Vsync").transform.Find("Value").GetComponent<TextMeshProUGUI>();
        windowModeText = transform.Find("Display Mode").transform.Find("Value").GetComponent<TextMeshProUGUI>();
        refreshRateText = transform.Find("Refresh Rate").transform.Find("Value").GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        graphicsState = PlayerPrefs.GetFloat("graphicsStatePP");
        vsyncSwitch = PlayerPrefs.GetFloat("vSyncSwitchPP");
        windowModeState = PlayerPrefs.GetFloat("windowModeStatePP");
        refreshRateState = PlayerPrefs.GetFloat("refreshRateStatePP");

        if (vsyncSwitch == 1)
        {
            vsyncText.text = "On";
        }
        else
        {
            vsyncText.text = "Off";
        }
        ShowGraphicsValue();
        ShowWindowTypeValue();
        ShowRefreshRateValue();
    }

    public void SetGraphicsUp()
    {
        graphicsState = Mathf.Repeat(graphicsState, 2) + 1;
        ShowGraphicsValue();
    }

    public void SetGraphicsDown()
    {
        graphicsState = Mathf.Repeat(graphicsState, 2) + 1;
        ShowGraphicsValue();
    }

    private void ShowGraphicsValue()
    {
        switch (graphicsState)
        {
/*            case 0:
                graphicsText.text = "Low";
                break;*/
            case 1:
                graphicsText.text = "Medium";
                break;
            case 2:
                graphicsText.text = "High";
                break;
        }
    }

    public void VsyncSwitch()
    {
        vsyncSwitch = Mathf.Repeat(vsyncSwitch + 1, 2);
        if (vsyncSwitch == 1)
        {
            vsyncText.text = "On";
        }
        else
        {
            vsyncText.text = "Off";
        }
    }

    public void WindowTypeUp()
    {
        windowModeState = Mathf.Repeat(windowModeState + 1, 3);
        ShowWindowTypeValue();
    }

    public void WindowTypeDown()
    {
        windowModeState = Mathf.Repeat(windowModeState - 1, 3);
        ShowWindowTypeValue();
    }

    private void ShowWindowTypeValue()
    {
        switch (windowModeState)
        {
            case 0:
                windowModeText.text = "Fullscreen";
                break;
            case 1:
                windowModeText.text = "Maximized";
                break;
            case 2:
                windowModeText.text = "Windowed";
                break;
        }
    }

    private void WindowType()
    {
        switch (windowModeState)
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
    }

    public void RefreshRateUp()
    {
        refreshRateState = Mathf.Repeat(refreshRateState + 1, 11);
        ShowRefreshRateValue();
    }

    public void RefreshRateDown()
    {
        refreshRateState = Mathf.Repeat(refreshRateState - 1, 11);
        ShowRefreshRateValue();
    }

    private void ShowRefreshRateValue()
    {
        switch (refreshRateState)
        {
            case 0:
                refreshRateText.text = "30";
                break;
            case 1:
                refreshRateText.text = "60";
                break;
            case 2:
                refreshRateText.text = "75";
                break;
            case 3:
                refreshRateText.text = "90";
                break;
            case 4:
                refreshRateText.text = "120";
                break;
            case 5:
                refreshRateText.text = "144";
                break;
            case 6:
                refreshRateText.text = "165";
                break;
            case 7:
                refreshRateText.text = "180";
                break;
            case 8:
                refreshRateText.text = "240";
                break;
            case 9:
                refreshRateText.text = "360";
                break;
            case 10:
                refreshRateText.text = "540";
                break;
        }
    }

    private void RefreshRateType()
    {
        switch (refreshRateState)
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

    public void GraphicsApply()
    {
        QualitySettings.SetQualityLevel((int)graphicsState);
        QualitySettings.vSyncCount = (int)vsyncSwitch;
        WindowType();
        RefreshRateType();
        PlayerPrefs.SetFloat("graphicsStatePP", graphicsState);
        PlayerPrefs.SetFloat("vSyncSwitchPP", vsyncSwitch);
        PlayerPrefs.SetFloat("windowModeStatePP", windowModeState);
        PlayerPrefs.SetFloat("refreshRateStatePP", refreshRateState);
    }
}
