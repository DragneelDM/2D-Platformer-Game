using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gunner : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform ShootingPoint;
    [SerializeField] Vector3[] patrolPoints;
    float health = 3f;
    float elapsedTime;
    Animator anims;
    [SerializeField] float lerpTime = 5f;
    bool facingLeft = true;
    bool patrol = false;


    private void Start() {
        anims = GetComponent<Animator>();
    }

    void Update()
    {
        Patrol();
    }

    void Patrol(){
        if(!patrol) { return; }
        elapsedTime += Time.deltaTime;

        if (elapsedTime < lerpTime)
        {
            float t = elapsedTime / lerpTime;
            transform.position = Vector3.Lerp(patrolPoints[0], patrolPoints[1], t);
        }
        else
        {
            // Reset the timer when reaching the destination
            elapsedTime = 0f;
            SwapPoints();
        }
    }

    void SwapPoints()
    {
        Vector3 temp = patrolPoints[0];

        transform.localScale = facingLeft == true ? new Vector3(1,1,1) : new Vector3(-1,1,1);
        facingLeft = !facingLeft;

        patrolPoints[0] = patrolPoints[1];
        patrolPoints[1] = temp;

    }

    void SetPatrol(){
        patrol = true;
        FindObjectOfType<BossUI>().CallGuys();
    }

    void Projectile(){
        FindObjectOfType<BossAttack>().Shoot();
    }

    void FootStep(){
        SoundManager.Instance.Play(Sounds.GunnerFootstep);
    }

    void Death(){
        Destroy(gameObject);
        SceneManager.LoadScene("Win");
    }
}
