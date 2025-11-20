using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    public float speed;
    public float jumpForce;
    public SettingData settingData;
    public GameObject fishBoneEffect;

    private Rigidbody rb;
    private BoxCollider collider;
    private float moveX;
    private bool isGrounded;
    private bool canJump;
    private bool canSprint;

    private int randomIdle;
    private Animator animator;

    public AudioSource sound;
    public AudioClip jumpSound;
    public AudioClip slideSound;
    public AudioClip deadSound;
    public AudioClip fishBoneCollectedSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();

        randomIdle = Random.Range(0, 4);
        animator.SetInteger("RandomIdle", randomIdle);
        collider.center = new Vector3(0, 0.5f, 0);
        collider.size = new Vector3(0.6382446f, 1f, 0.3884315f);

        canJump = true;
        canSprint = true;
    }

    void FixedUpdate()
    {
        if (settingData.gameStart == false)
        {
            return;
        }
        else
        {
            // Di chuyển trái-phải
            Vector3 velocity = rb.linearVelocity;
            velocity.x = moveX * speed;   // chỉ thay đổi trục X
            rb.linearVelocity = velocity;
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveX = input.x;   // lấy mỗi trục X
    }

    public void OnJump(InputValue value)
    {
        if(isGrounded && settingData.gameStart && canJump)
        {
            sound.PlayOneShot(jumpSound);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("Jumping", true);
            isGrounded = false;
            canJump = false;
            StartCoroutine(StopJump());
        }
    }
    private IEnumerator StopJump()
    {
         yield return new WaitForSeconds(0.5f);
        animator.SetBool("Jumping", false);
        canJump = true;
    }
    public void OnSprint(InputValue value)
    {
        if(settingData.gameStart && canSprint)
        {
            sound.PlayOneShot(slideSound);
            animator.SetBool("Sliding", true);
            canSprint = false;
            rb.position = new Vector3(rb.position.x, 0.28f, rb.position.z);
            collider.center = new Vector3(0, 0.2110513f, 0);
            collider.size = new Vector3(0.6382446f, 0.4221026f, 0.3884315f);
            StartCoroutine(StopSprint());
        }
    }
    private IEnumerator StopSprint()
    {
        yield return new WaitForSeconds(0.6f);
        animator.SetBool("Sliding", false);
        canSprint = true;
        collider.center = new Vector3(0, 0.478f, 0);
        collider.size = new Vector3(0.6382446f, 1f, 0.3884315f);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish Bone"))
        {
            sound.PlayOneShot(fishBoneCollectedSound);
            if (fishBoneEffect != null)
            {
                var effectClone = Instantiate(fishBoneEffect, transform.position, Quaternion.identity);
                Destroy(effectClone, 1f);
            }
        }
        if (other.CompareTag("DeadCollider"))
        {
            sound.PlayOneShot(deadSound);
            settingData.gameEnd = true;
            settingData.gameStart = false;
            animator.SetBool("Dead", true);
            animator.SetTrigger("Hit");
        }
    }
}
