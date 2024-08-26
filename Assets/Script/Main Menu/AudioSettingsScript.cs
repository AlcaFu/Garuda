using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSettingsScript : MonoBehaviour
{
    [SerializeField] public AudioMixer audioMixer;
    private GameObject master, bgm, sfx;
    private TextMeshProUGUI masterText, bgmText, sfxText;
    private float masterValue, bgmValue, sfxValue;

    private void Start()
    {   
        master = gameObject.transform.Find("Master").gameObject;
        bgm = gameObject.transform.Find("Music").gameObject;
        sfx = gameObject.transform.Find("Sound Effect").gameObject;
        masterText = master.transform.Find("Value").GetComponent<TextMeshProUGUI>();
        bgmText = bgm.transform.Find("Value").GetComponent<TextMeshProUGUI>();
        sfxText = sfx.transform.Find("Value").GetComponent<TextMeshProUGUI>();
        AudioInitialization();
    }

    private void OnEnable()
    {
        AudioInitialization();
        SetShowValue("master", masterValue, masterText);
        SetShowValue("bgm", bgmValue, bgmText);
        SetShowValue("sfx", sfxValue, sfxText);
    }

    public void IncreaseVolume(string audioType)
    {
        switch (audioType)
        {
            case "master":
                masterValue += 10;
                masterValue = Mathf.Clamp(masterValue, 0, 100);
                PlayerPrefs.SetFloat("PPMaster", masterValue);
                SetShowValue("master", masterValue, masterText);
                break;
            case "bgm":
                bgmValue += 10;
                bgmValue = Mathf.Clamp(bgmValue, 0, 100);
                PlayerPrefs.SetFloat("PPBgm", bgmValue);
                SetShowValue("bgm", bgmValue, bgmText);
                break;
            case "sfx":
                sfxValue += 10;
                sfxValue = Mathf.Clamp(sfxValue, 0, 100);
                PlayerPrefs.SetFloat("PPSfx", sfxValue);
                SetShowValue("sfx", sfxValue, sfxText);
                break;
        }
    }

    public void DecreaseVolume(string audioType)
    {
        switch (audioType)
        {
            case "master":
                masterValue -= 10;
                masterValue = Mathf.Clamp(masterValue, 0, 100);
                PlayerPrefs.SetFloat("PPMaster", masterValue);
                SetShowValue("master", masterValue, masterText);
                break;
            case "bgm":
                bgmValue -= 10;
                bgmValue = Mathf.Clamp(bgmValue, 0, 100);
                PlayerPrefs.SetFloat("PPBgm", bgmValue);
                SetShowValue("bgm", bgmValue, bgmText);
                break;
            case "sfx":
                sfxValue -= 10;
                sfxValue = Mathf.Clamp(sfxValue, 0, 100);
                PlayerPrefs.SetFloat("PPSfx", sfxValue);
                SetShowValue("sfx", sfxValue, sfxText);
                break;
        }
    }

    public void AudioInitialization()
    {
        if (PlayerPrefs.HasKey("PPMaster") || PlayerPrefs.HasKey("PPBgm") || PlayerPrefs.HasKey("PPSfx"))
        {
            PPGetAll();

        }
        else
        {
            PPSetAll(50);
        }
        SetShowValue("master", masterValue, masterText);
        SetShowValue("bgm", bgmValue, bgmText);
        SetShowValue("sfx", sfxValue, sfxText);
    }

    private void SetShowValue(string audioMixerParameter, float audioValue, TextMeshProUGUI textValue)
    {
        audioMixer.SetFloat(audioMixerParameter, Mathf.Lerp(-80, 10, audioValue / 100));
        if (textValue != null) textValue.text = (audioValue).ToString() + "%";
    }

    private void PPGetAll()
    {
        masterValue = PlayerPrefs.GetFloat("PPMaster");
        bgmValue = PlayerPrefs.GetFloat("PPBgm");
        sfxValue = PlayerPrefs.GetFloat("PPSfx");
    }

    private void PPSetAll(float value)
    {
        PlayerPrefs.SetFloat("PPMaster", value);
        PlayerPrefs.SetFloat("PPBgm", value);
        PlayerPrefs.SetFloat("PPSfx", value);
    }
}
