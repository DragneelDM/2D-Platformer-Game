using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Rigidbody2D _rigidBody2D;
    [SerializeField] Animator _animator;
    private float _horizontal;
    private bool _jumpInput;
    private bool _maxHeightCondition = true;
    private bool _jumpCondition;
    private bool _isGrounded = false;
    private Vector3 _position;
    [SerializeField] float _speed = 5f;
    [SerializeField, Range(100, 500)] float _jump = 300f;
    [SerializeField] bool _setMaxHeight = true;
    [SerializeField] float _maxHeight = 0f;

    private void Start()
    {
        GameManager.Instance?.gameObject.SetActive(true);
        GameManager.Instance.InitKeys();
    }
    private void Update()
    {
        _horizontal = Input.GetAxisRaw(StringConsts.Horizontal);
        _jumpInput = Input.GetButtonDown(StringConsts.Jump);
        _position = transform.position;

        // Max height condition Logic
        _maxHeightCondition = _setMaxHeight && transform.position.y < _maxHeight;

        Walk();
        Crouch();
        if (_isGrounded) { Jump(); }
        Reset();
    }

    private void Walk()
    {
        _position.x += _horizontal * _speed * Time.deltaTime;
        transform.position = _position;

        if (_horizontal != 0)
        {
            _spriteRenderer.flipX = _horizontal < 0;
        }

        _animator.SetFloat(StringConsts.HorizontalSpeed, Mathf.Abs(_horizontal));
    }

    private void Jump()
    {
        _jumpCondition = _maxHeightCondition ? _jumpInput && _maxHeightCondition : _jumpInput;

        // jumpCondition = jumpInput && maxHeightCondition;

        _animator.SetBool(StringConsts.Jump, _jumpCondition);

        if (_jumpCondition)
        {
            _rigidBody2D.AddForce(new Vector2(0f, _jump), ForceMode2D.Force);
        }
    }

    private void Crouch()
    {
        bool isCrouched = false;
        if (Input.GetKey(KeyCode.S))
            isCrouched = true;
        else
            isCrouched = false;

        _animator.SetBool(StringConsts.Crouching, isCrouched);
    }

    private void Reset()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            LevelManager.Instance.Restart();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _isGrounded = false;
    }

    public void Death()
    {
        SoundManager.Instance?.Play(Sounds.PlayerDeath);
        GameManager.Instance?.ReduceHealth();
    }

    public void Footstep()
    {
        SoundManager.Instance.Play(Sounds.PlayerFootstep);
    }
}
