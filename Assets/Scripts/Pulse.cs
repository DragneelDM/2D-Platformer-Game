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
            print("Get it down");
        }

        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(transform.parent.gameObject);
    }
}
