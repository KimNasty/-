using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVisual : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private const string ISRUNFACE = "isRunFace";
    private const string ISRUNBACK = "isRunBack";
    private const string ISRUNSIDE = "isRunSide";

    [SerializeField] private Character _character;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _animator.SetBool(ISRUNFACE, _character.Running == Run.Face);
        _animator.SetBool(ISRUNBACK, _character.Running == Run.Back);
        _animator.SetBool(ISRUNSIDE, _character.Running == Run.Side);
        _spriteRenderer.flipX = _character.IsRunRight;
    }
}
