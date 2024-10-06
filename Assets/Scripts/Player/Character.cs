using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Run
{
    Face,
    Side,
    Back,
    No
}

public class Character : MonoBehaviour
{
    public static Character Instance { get; private set; }

    private float _movingSpeed = 1.5f;
    private Vector2 _inputVector = new Vector2 (0, 0);
    private Rigidbody2D _rb;
    public bool IsActivated { get; set; }
    public Run Running {  get; private set; }
    public bool IsRunRight { get; private set; } // для определения надо ли развернуть в право спрайт


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        Instance = this;
    }

    private void FixedUpdate()
    {
        if(IsActivated)Movement();
    }

    private void Movement()
    {

        if (Input.GetKey(KeyCode.W))
        {
            _inputVector.y = 1f;
            Running = Run.Back;
            IsRunRight = false;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _inputVector.y = -1f;
            Running = Run.Face;
            IsRunRight = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _inputVector.x = -1f;
            Running = Run.Side;
            IsRunRight = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _inputVector.x = 1f;
            Running = Run.Side;
            IsRunRight = false;
        }
        else
        {
            _inputVector = Vector2.zero;
            Running = Run.No;
        }

        if (_inputVector != Vector2.zero)
        {
            _inputVector = _inputVector.normalized;
            _rb.MovePosition(_rb.position + _inputVector * Time.fixedDeltaTime * _movingSpeed);
        }
    }

    public Vector3 GetCharacterPosition()
    {
        return _rb.position;
    }


}
