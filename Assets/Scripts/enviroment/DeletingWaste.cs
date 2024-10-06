using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletingWaste : MonoBehaviour
{

    private float _deleteDuration = 2f;
    private float _interactionDistance = 2f;

    private bool _isDeleting = false;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!_isDeleting) CheckForInteraction();
        else if (Character.Instance != null && Character.Instance.Running != Run.No) StopDeletion();
    }

    private void CheckForInteraction()
    {
        if (Character.Instance == null) return;

        if (Vector3.Distance(transform.position, Character.Instance.GetCharacterPosition()) <= _interactionDistance &&
            Input.GetKey(KeyCode.Space) && Character.Instance.Running == Run.No)
        {
            StartCoroutine(DeleteItem());
        }
    }

    IEnumerator DeleteItem()
    {
        // Защита от многократного запуска корутины
        if (_isDeleting) yield break;

        _isDeleting = true;
        _animator.SetBool("isDeleting", true);

        float elapsedTime = 0f;
        while (elapsedTime < _deleteDuration)
        {
            if (!_isDeleting) yield break;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (_isDeleting)
        {
            GiveResource();
            Destroy(gameObject);
            
        }
    }

    void StopDeletion()
    {
        _isDeleting = false;
        _animator.SetBool("isDeleting", false);
    }

    protected virtual void GiveResource() { }
}

