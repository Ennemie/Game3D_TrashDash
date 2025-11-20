using UnityEngine;

public class MovingMap : MonoBehaviour
{
    public SettingData settingData;
    private float speed;

    private Vector3 startPos;
    private Vector3 endPos;

    private void Start()
    {
        speed = 5f;
        startPos = new Vector3(250, 0.2f, 200);
        endPos = new Vector3(250, 0.2f, 0);
    }
    void Update()
    {
        if (settingData.gameStart == true)
        {
            // Đi lùi về endPos
            if (Vector3.Distance(transform.position, endPos) > 0.05f)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            }
            else
            {
                // Reset về vị trí ban đầu ngay lập tức
                transform.position = startPos;
            }
        }
    }
}
