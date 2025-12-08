using System.Collections;
using UnityEngine;

public class LightningFlash : MonoBehaviour
{
    public Light flashLight;
    public float minDelay = 3f;
    public float maxDelay = 8f;

    private void Start()
    {
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        while (true)
        {
            // đợi ngẫu nhiên giữa các tia sét
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            // nhá nhanh
            flashLight.intensity = Random.Range(1.5f, 3.5f);
            yield return new WaitForSeconds(0.05f);

            flashLight.intensity = 0;
            yield return new WaitForSeconds(0.05f);

            // nhá nhá nhẹ lần 2 (hiệu ứng thật)
            flashLight.intensity = Random.Range(0.5f, 1.5f);
            yield return new WaitForSeconds(0.05f);

            flashLight.intensity = 0;
        }
    }
}
