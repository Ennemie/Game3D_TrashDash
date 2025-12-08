using UnityEngine;
using UnityEngine.AI;

public class DogController : MonoBehaviour
{
    public SettingData settingData;
    public GameObject player;
    private NavMeshAgent agent;
    public float speed;
    private bool isActive = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 15, player.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if(isActive && settingData.isDead)
        {
            agent.SetDestination(player.transform.position);
        }
    }
}
