using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Animator _door;
    [SerializeField] Sprite _switchOn;
    [SerializeField] SpriteRenderer _spriteRenderer;
    bool _waiting = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_waiting)
        {
            _spriteRenderer.sprite = _switchOn;
            SoundManager.Instance.Play(Sounds.SwitchActivated);
            _door.SetBool(StringConsts.IntroStart, true);
            _waiting = false;
        }
    }
}
