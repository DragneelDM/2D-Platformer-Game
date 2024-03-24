using UnityEngine;

public class BossAttackManager : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private bool _autoShoot = false;
    [SerializeField] private float _durationTime = 3f;
    [SerializeField] private float _elaspedTime = 0f;
    [SerializeField] private float _maxRange = 32f;
    private Transform _player;

    private void Start()
    {
        _player = GameManager.Instance.PlayerController.transform;
    }


    private void Update()
    {
        if (_autoShoot)
        {
            if (_player.position.x < _maxRange)
            {
                _elaspedTime += Time.deltaTime;

                if (_elaspedTime > _durationTime)
                {
                    Instantiate(_projectile, new Vector2(_player.position.x, transform.position.y), transform.rotation);
                    _elaspedTime = 0f;
                }
            }
        }
    }

    public void Shoot()
    {
        Instantiate(_projectile, new Vector2(_player.position.x, transform.position.y), transform.rotation);
    }
}
