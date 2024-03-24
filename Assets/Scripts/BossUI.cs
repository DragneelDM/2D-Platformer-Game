using UnityEngine;

public class BossUI : MonoBehaviour
{
    [SerializeField] private GameObject _healthFill;
    [SerializeField] private GameObject _layout;
    [SerializeField] private Animator _animator;
    private Animator _bossAnim;

    private int _bossHealth = 0;
    private void Start()
    {
        _healthFill.SetActive(false);
        _layout.SetActive(false);
    }

    private void Update()
    {
        _animator.SetInteger(StringConsts.BossHealth, _bossHealth);
    }

    public void Enable()
    {
        _healthFill.SetActive(true);
        _layout.SetActive(true);
    }

    public void SetBoss(Animator anim)
    {
        _bossAnim = anim;
    }

    public void UpdateUI()
    {
        _bossHealth++;
        if (_bossHealth == 3f)
        {
            _bossAnim.SetBool(StringConsts.Died, true);
        }
    }

}
