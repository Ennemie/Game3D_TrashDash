using Unity.Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Cinemachine setting")]
    public CinemachineThirdPersonFollow cinemachine;

    [Header("Setting Data")]
    public SettingData settingData;
    public CanvasManager canvas;

    [Header("Player running")]
    public Animator player;

    public AudioSource sound;
    public AudioClip startSound;
    public AudioClip endSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingData.gameEnd = false;
        settingData.fishBoneCount = 0;
        StartCoroutine(GameStartDelay());
        StartCoroutine(MoveCamera(5f, 1.7f, 2f, 0));

        sound.PlayOneShot(startSound);
    }

    // Update is called once per frame
    void Update()
    {
        if(settingData.gameEnd == true)
        {
            sound.PlayOneShot(endSound);
            StartCoroutine(MoveCamera(1.7f, 5f, 3f, 2f));
            canvas.OpenEndHub();
            settingData.gameEnd = false;
        }
    }
    private IEnumerator MoveCamera(float startY, float endY, float transitionDuration, float delay)
    {
        yield return new WaitForSeconds(delay);
        // Bắt đầu từ vị trí cao
        cinemachine.ShoulderOffset.y = startY;

        // --- BƯỚC CHUYỂN ĐỘNG XUỐNG MƯỢT MÀ ---

        float timeElapsed = 0f;

        while (timeElapsed < transitionDuration)
        {
            // Tính tỷ lệ hoàn thành (0 đến 1)
            float t = timeElapsed / transitionDuration;

            // Sử dụng Lerp để tính giá trị Y ở thời điểm hiện tại
            float newY = Mathf.Lerp(startY, endY, t);

            // Cập nhật vị trí Y của camera
            cinemachine.ShoulderOffset.y = newY;

            // Tăng thời gian đã trôi qua
            timeElapsed += Time.deltaTime;

            // Chờ đến Frame tiếp theo
            yield return null;
        }
        cinemachine.ShoulderOffset.y = endY;
    }
    private IEnumerator GameStartDelay()
    {
        player.SetBool("Moving", false);
        settingData.gameStart = false;
        yield return new WaitForSeconds(3f);
        settingData.gameStart = true;
        player.SetBool("Moving", true);
    }
}
