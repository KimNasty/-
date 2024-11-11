using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    private Vector3 _playerPosition;
    private void Update()
    {
        _playerPosition = Player.Instance.GetPlayerPosition();
        transform.position = _playerPosition + new Vector3(0, 0, -10);
    }
}
