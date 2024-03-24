using UnityEngine;

public class Gunner : MonoBehaviour
{
    [SerializeField] public BossAttackManager BossAttackManager;
    [SerializeField] private Vector3[] _patrolPoints;
    [SerializeField] private Animator _anims;
    [SerializeField] private float _attackDuration = 3f;
    [SerializeField] private float _patrolDuration = 5f;
    private float _elapsedTime;
    private bool _facingLeft = true;
    private bool _patrol = false;
    private float _health = 3f;

    private void Awake()
    {
        GameManager.Instance.SetBoss(this);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (!_patrol) { return; }

        if (_health == 0f)
        {
            _anims.SetBool(StringConsts.Died, true);
        }

        _elapsedTime += Time.deltaTime;

        _anims.SetFloat(StringConsts.ElapsedTime, _elapsedTime);

        if (_elapsedTime < _patrolDuration)
        {
            // Attack In Middle of Patrol
            if (_elapsedTime < _attackDuration)
            {
                _anims.SetBool(StringConsts.Attack, true);
            }

            float t = _elapsedTime / _patrolDuration;
            transform.position = Vector3.Lerp(_patrolPoints[0], _patrolPoints[1], t);
        }
        else
        {
            _anims.SetBool(StringConsts.Attack, false);
            _elapsedTime = 0f;
            SwapPoints();
        }
    }

    private void SwapPoints()
    {
        Vector3 temp = _patrolPoints[0];

        transform.localScale = _facingLeft == true ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
        _facingLeft = !_facingLeft;

        _patrolPoints[0] = _patrolPoints[1];
        _patrolPoints[1] = temp;

    }

    #region  Animation Events
    private void SetPatrol()
    {
        _patrol = true;
        GameManager.Instance.BossUi.Enable();
    }

    private void Projectile()
    {
        BossAttackManager.Shoot();
    }

    private void FootStep()
    {
        SoundManager.Instance.Play(Sounds.GunnerFootstep);
    }

    private void Death()
    {
        Destroy(gameObject);
        GameManager.Instance.Won();
    }
    #endregion
}
