using UnityEngine;

public class Pulse : MonoBehaviour
{
    [SerializeField] GameObject Explosion;
    void Update()
    {
        transform.Translate(Vector2.right * 0.4f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Instantiate(Explosion, transform.GetChild(0).position, transform.rotation);
        Destroy(gameObject);
    }
}
