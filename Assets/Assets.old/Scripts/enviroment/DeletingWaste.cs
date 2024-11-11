using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletingWaste : MonoBehaviour
{

    private float _deleteDuration = 2f;
    private float _interactionDistance = 1.2f;
    private Vector3 _deletingPlayerPosition;
    private bool _isDeleting = false;
    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    private void OnMouseDown()
    {
        if (!_isDeleting)
        {
            Vector3 playerPosition = Player.Instance.GetPlayerPosition();

            if (Vector3.Distance(playerPosition, transform.position) < _interactionDistance)
            {
                _deletingPlayerPosition = playerPosition; 
                StartCoroutine(DeleteItem()); 
            }
        }
    }

    private IEnumerator DeleteItem()
    {
        _isDeleting = true;
        _animator.SetBool("isDeleting", true);

        float elapsedTime = 0f;

        while (elapsedTime < _deleteDuration)
        {
            if (_deletingPlayerPosition != Player.Instance.GetPlayerPosition())
            {
                StopDeletion(); 
                yield break; 
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }

    private void StopDeletion()
    {
        _isDeleting = false;
        _animator.SetBool("isDeleting", false);
    }
}



