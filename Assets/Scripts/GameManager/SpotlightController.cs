using UnityEngine;
using UnityEngine.InputSystem; // QUAN TRỌNG

public class SpotlightController : MonoBehaviour
{
    public Light spotLight;

    void Update()
    {
        if (Keyboard.current.upArrowKey.isPressed)
            spotLight.intensity += Time.deltaTime;

        if (Keyboard.current.downArrowKey.isPressed)
            spotLight.intensity -= Time.deltaTime;
    }
}
