using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private const string ISRUNFACE = "isRunFace";
    private const string ISRUNSIDE = "isRunSide";
    private const string ISRUNBACK = "isRunBack";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetBoolIsRunFace(bool b) { _animator.SetBool(ISRUNFACE, b); }
    public void SetBoolIsRunBack(bool b) { _animator .SetBool(ISRUNBACK, b);}
    public void SetBoolIsRunSide(bool b) { _animator.SetBool(ISRUNSIDE, b); }
    public void IsFlipX(bool b) { _spriteRenderer.flipX = b; }

}
