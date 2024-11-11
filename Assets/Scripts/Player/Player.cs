using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float speed = 1.5f;
    public PlayerVisual playerVisual;
    public Rigidbody2D rb;
    private PlayerInputActions _playerInputActions;
    private float _lastInputX;
    public static Player Instance { get; private set; }


    public Vector3 GetPlayerPosition() => transform.position;


    public PlayerInputActions InputActions { get { return _playerInputActions; } }


    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();
        Instance = this;
    }

    private void FixedUpdate()
    {
        Vector3 inputVector = GetMovementVector();
        inputVector = inputVector.normalized;

        rb.MovePosition(transform.position + inputVector * speed * Time.deltaTime);
    }


    private Vector2 GetMovementVector()
    {

        Vector2 _inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
        float angle = Mathf.Atan2(_inputVector.y, _inputVector.x) * Mathf.Rad2Deg;

        if (angle >= 45 && angle < 135) _inputVector = Vector2.up;

        else if (angle >= 135 || angle < -135) _inputVector = Vector2.left;

        else if (angle >= -135 && angle < -45) _inputVector = Vector2.down;

        else if (angle != 0) _inputVector = Vector2.right;

        playerVisual.SetBoolIsRunSide(Math.Abs(_inputVector.x) > Math.Abs(_inputVector.y));
        playerVisual.IsFlipX(_inputVector.x < 0 || _lastInputX < 0);
        playerVisual.SetBoolIsRunBack(_inputVector.y > 0 && Math.Abs(_inputVector.y) >= Math.Abs(_inputVector.x));
        playerVisual.SetBoolIsRunFace(_inputVector.y < 0 && Math.Abs(_inputVector.y) >= Math.Abs(_inputVector.x));

        if (_inputVector.x != 0) _lastInputX = _inputVector.x;

        return _inputVector;
    }

}
