using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro; // Cần thiết cho Coroutines

public class StartGameManager : MonoBehaviour
{
    public Image raccoon;
    public float moveSpeed;

    public Button runBtn;
    public Button settingBtn;
    public Button backBtn;
    public TMP_Text soundText;
    public Slider soundSlider;
    public AudioSource sound;
    public SettingData settingData;
    public AudioClip buttonSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        runBtn.gameObject.SetActive(true);
        settingBtn.gameObject.SetActive(true);
        backBtn.gameObject.SetActive(false);
        soundText.gameObject.SetActive(false);
        soundSlider.gameObject.SetActive(false);

        soundSlider.value = 100;
        settingData.volume = soundSlider.value;
        sound.volume = settingData.volume;
    }

    public void StartGame()
    {
        sound.PlayOneShot(buttonSound);
        if (raccoon != null)
        {
            StartCoroutine(MoveRaccoonAndLoadScene());
        }
        else
        {
            SceneManager.LoadScene("GamePlay");
        }
    }
    private IEnumerator MoveRaccoonAndLoadScene()
    {
        RectTransform rectTransform = raccoon.GetComponent<RectTransform>();

        float screenHeight = Screen.height;
        float targetY = rectTransform.anchoredPosition.y - (rectTransform.rect.height + 30);

        while (rectTransform.anchoredPosition.y > targetY)
        {
            // Di chuyển xuống bằng cách giảm tọa độ Y
            float newY = rectTransform.anchoredPosition.y - moveSpeed * Time.deltaTime;
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newY);

            yield return null; // Đợi một frame
        }

        // 2. Đợi một khoảng thời gian (Delay)
        yield return new WaitForSeconds(0.5f);

        // 3. Tải Scene "level 1"
        SceneManager.LoadScene("GamePlay");
    }
    public void OpenSettings()
    {
        sound.PlayOneShot(buttonSound);
        runBtn.gameObject.SetActive(false);
        settingBtn.gameObject.SetActive(false);
        backBtn.gameObject.SetActive(true);
        soundText.gameObject.SetActive(true);
        soundSlider.gameObject.SetActive(true);
    }
    public void BackToMainMenu()
    {
        sound.PlayOneShot(buttonSound);
        runBtn.gameObject.SetActive(true);
        settingBtn.gameObject.SetActive(true);
        backBtn.gameObject.SetActive(false);
        soundText.gameObject.SetActive(false);
        soundSlider.gameObject.SetActive(false);
    }
    public void SetVolumn() {
        float volume = soundSlider.value;
        sound.volume = volume;
        settingData.volume = volume;
    }
}