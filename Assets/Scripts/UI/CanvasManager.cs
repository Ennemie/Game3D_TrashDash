using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Image panel;
    public Image pauseHub;
    public Image settingHub;
    public Image endHub;
    public AudioSource sound;
    public Slider soundSlider;
    public AudioClip buttonSound;

    [Header("Fish Bone Count")]
    public List<TMP_Text> fishBoneCountTexts;
    public SettingData settingData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(WaitToOpenPanel());
        pauseHub.gameObject.SetActive(false);
        settingHub.gameObject.SetActive(false);
        endHub.gameObject.SetActive(false);

        sound.volume = settingData.volume;
        soundSlider.value = settingData.volume;
    }
    public void DisplayFishBoneCount()
    {
        foreach (var fishBoneCount in fishBoneCountTexts)
        {
            fishBoneCount.text = settingData.fishBoneCount.ToString();
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        panel.gameObject.SetActive(false);
        pauseHub.gameObject.SetActive(true);
        sound.PlayOneShot(buttonSound);
    }
    public void ResumeGame()
    {
        sound.PlayOneShot(buttonSound);
        Time.timeScale = 1f;
        panel.gameObject.SetActive(true);
        pauseHub.gameObject.SetActive(false);
    }
    public void OpenSettingHub()
    {
        sound.PlayOneShot(buttonSound);
        pauseHub.gameObject.SetActive(false);
        settingHub.gameObject.SetActive(true);
    }
    public void CloseSettingHub()
    {
        sound.PlayOneShot(buttonSound);
        settingHub.gameObject.SetActive(false);
        pauseHub.gameObject.SetActive(true);
    }
    public void OpenEndHub()
    {
        StartCoroutine(WaitToEndGame());
    }
    private IEnumerator WaitToEndGame()
    {
        panel.gameObject.SetActive(false);
        yield return new WaitForSeconds(5f);
        endHub.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        sound.PlayOneShot(buttonSound);
        Time.timeScale = 1f;
        SceneManager.LoadScene("GamePlay");
    }
    public void SetVolumn()
    {
        float volume = soundSlider.value;
        sound.volume = volume;
        settingData.volume = volume;
    }
    public IEnumerator WaitToOpenPanel()
    {
        panel.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        panel.gameObject.SetActive(true);
    }
}
