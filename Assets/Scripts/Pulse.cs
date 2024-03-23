using UnityEngine;

public class Pulse : MonoBehaviour
{
    [SerializeField] GameObject Explosion;
    void Update()
    {
        transform.parent.Translate(Vector2.right * 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Respawn"){
            FindObjectOfType<BossUI>().UpdateUI();
        } else
        if(other.tag == "Player"){
            FindObjectOfType<PlayerController>().Death();
        }

        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(transform.parent.gameObject);
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     print(other.gameObject.name);
    //     if(other.gameObject.tag == "Respawn"){
    //         FindObjectOfType<BossUI>().UpdateUI();
    //         FindObjectOfType<Gunner>().LowerHealth();
    //     }

    //     Instantiate(Explosion, transform.position, transform.rotation);
    //     Destroy(transform.parent.gameObject);
    // }
}
