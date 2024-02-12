using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    Animator animator;
    float horizontal;
    float vertical;
    Vector3 position;
    [SerializeField]float speed = 2f;
    [SerializeField]float jump = 2f;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        // Setup Variables
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Jump");
        position = transform.position;

        // Set Animatioms and logic
        Walk();
        Crouch();
        Jump();
    }

    void Walk()
    {
        //Movement
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

        //Turn Backwards
        Vector3 Backface = transform.localScale;
        Backface.x = horizontal < 0 ? (-1 * Mathf.Abs(Backface.x)) : Mathf.Abs(Backface.x);
        transform.localScale = Backface;

        //Animate
        animator.SetFloat("HorizontalSpeed", Mathf.Abs(horizontal));
    }

    private void Jump()
    {
        //Jump
        if(vertical > 0){
            rigidBody2D.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
            // animator.SetBool("Jump", true);
        }
        // else
        //     animator.SetBool("Jump", false);
    }

    void Crouch()
    {
        // Crouch
        bool isCrouched = false;
        if (Input.GetKey(KeyCode.LeftControl))
            isCrouched = true;
        else
            isCrouched = false;

        animator.SetBool("Crouching", isCrouched);
    }
}
