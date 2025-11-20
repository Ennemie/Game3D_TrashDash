using System.Collections;
using UnityEngine;

public class FishBoneController : MonoBehaviour
{
    public SettingData settingData;
    private CanvasManager canvasManager;

    private MeshRenderer mesh;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        canvasManager = FindAnyObjectByType<CanvasManager>();
        canvasManager.DisplayFishBoneCount();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            settingData.fishBoneCount++;
            canvasManager.DisplayFishBoneCount();
            StartCoroutine(WaitToRespawn());
        }
    }
    private IEnumerator WaitToRespawn()
    {
        mesh.enabled = false;
        yield return new WaitForSeconds(3f);
        mesh.enabled = true;
    }
}
