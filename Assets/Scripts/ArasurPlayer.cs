using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArasurPlayer : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    float horizontal;
    float vertical;
    Vector3 position;

    Animator animator;

    [SerializeField]float speed = 2f;
    [SerializeField]float jump = 2f;
    [SerializeField]float maxHeight = 5f;
    [SerializeField] ForceMode2D forceMode;
    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Setup Variables
        horizontal = Input.GetAxisRaw("Horizontal");
        position = transform.position;

        // Set logic
        Walk();

        Jump();
    }

    void Walk()
    {

        animator.SetBool("onMove", horizontal != 0);

        //Movement
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

        //Turn Backwards
        Vector3 Backface = transform.localScale;
        Backface.x = horizontal < 0 ? (-1 * Mathf.Abs(Backface.x)) : Mathf.Abs(Backface.x);

        transform.localScale = Backface;
    }

    void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && transform.position.y < maxHeight){
            rigidBody2D.AddForce(new Vector2(0, jump), forceMode);
        }

    }

        public void Death(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
