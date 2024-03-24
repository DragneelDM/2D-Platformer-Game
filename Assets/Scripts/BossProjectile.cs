using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _hit = false;
    [SerializeField, Range(0.1f, 5f)] private float speed = 4.2f;
    void Update()
    {
        if (!_hit)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _hit = true;
        _animator.SetBool(StringConsts.Hit, _hit);

        if (other.TryGetComponent<Gunner>(out Gunner gunner))
        {
            GameManager.Instance.BossUi.UpdateUI();
        }

        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.Death();
        }

        // Recedue for VFX
        _explosion.SetActive(true);
        Destroy(gameObject, 1f);
    }
}
