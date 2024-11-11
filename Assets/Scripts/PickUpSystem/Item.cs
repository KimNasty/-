using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [field: SerializeField]
    public ItemSO InventoryItem { get; private set; }

    [field: SerializeField]
    public int Quantity { get; set; } = 1;

    [SerializeField]
    private AudioSource pickupSound;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = InventoryItem.ItemImage;
    }

    public void DestroyItem()
    {
        Debug.Log("Calling AudioSource.Play()...");
        pickupSound.Play();

        StartCoroutine(DestroyAfterSound());
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.enabled = false;

        yield return new WaitForSeconds(pickupSound.clip.length - 0.2f);
        Destroy(gameObject);
    }
}