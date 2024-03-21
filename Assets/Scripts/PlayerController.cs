using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody2D;
    Animator animator;
    float horizontal;
    bool jumpInput;
    bool maxHeightCondition = true;
    bool jumpCondition;
    bool isGrounded = false;
    Vector3 position;
    [HideInInspector] public int Health { get; private set;} = 3;
    [SerializeField] float speed = 5f;
    [SerializeField, Range(100,500)]float jump = 300f;
    [SerializeField] bool setMaxHeight = true;
    [SerializeField] float maxHeight = 0f;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        FindObjectOfType<UIManager>().gameObject?.SetActive(true);
    }
    void Update()
    {
        // Setup Variables
        horizontal = Input.GetAxisRaw("Horizontal");
        jumpInput = Input.GetButtonDown("Jump");
        position = transform.position;

        // Max height condition Logic
        maxHeightCondition = setMaxHeight && transform.position.y < maxHeight;

        // Set Animatioms and logic
        Walk();
        Crouch();
        if(isGrounded) { Jump(); }
        Reset();
    }

    void Walk()
    {
        //Movement
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //Turn Backwards
        if(horizontal != 0)
            spriteRenderer.flipX = horizontal < 0;

        //Animate
        animator.SetFloat("HorizontalSpeed", Mathf.Abs(horizontal));
    }

    void Jump()
    {
        //Making it even more complicated but it's all boolean calculation so it is fine
        //Baseline assumption that boolean are good for performance
        // jumpCondition = maxHeightCondition ? jumpInput && maxHeightCondition : jumpInput;
            // But this did not work, Don't Know why

        jumpCondition = jumpInput && maxHeightCondition;

        animator.SetBool("Jump", jumpCondition);

        if(jumpCondition){
            rigidBody2D.AddForce(new Vector2(0f, jump), ForceMode2D.Force); }
    }

    void Crouch()
    {
        // Crouch
        bool isCrouched = false;
        if (Input.GetKey(KeyCode.S))
            isCrouched = true;
        else
            isCrouched = false;

        animator.SetBool("Crouching", isCrouched);
    }

    void Reset()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // isGrounded Logic
    void OnTriggerEnter2D(Collider2D other) {
        isGrounded = true;
    }

void OnTriggerExit2D(Collider2D other) {
        isGrounded = false;
    }

    public void Death(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundManager.Instance?.Play(Sounds.PlayerDeath);
        UIManager.Instance?.ReduceHealth();
    }

    public void Footstep(){
        SoundManager.Instance.Play(Sounds.PlayerFootstep);
    }
}
