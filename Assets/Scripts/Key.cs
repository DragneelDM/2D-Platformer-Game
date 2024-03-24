using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] Animator _animator;
    private void Start()
    {
        GameManager.Instance.SetKey();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            // Update UI
            GameManager.Instance.IncreaseKey();

            Destroy(gameObject);
        }
    }
}
