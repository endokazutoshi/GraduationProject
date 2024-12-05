using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public Transform holdPosition;
    private GameObject heldItem;
    public LayerMask itemLayer;
    private BoxCheck boxCheck;

    void Start()
    {
        boxCheck = FindObjectOfType<BoxCheck>();
    }

    void Update()
    {
        if (Input.GetButtonDown("B_Button_1P"))
        {
            if (heldItem == null)
            {
                TryPickUpItem();
            }
            else
            {
                TryPlaceItemInBox();
            }
        }
        if (Input.GetButtonDown("B_Button_2P"))
        {
            if (heldItem == null)
            {
                TryPickUpItem();
            }
            else
            {
                TryPlaceItemInBox();
            }
        }
    }

    void TryPickUpItem()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f, itemLayer);
        if (hit.collider != null)
        {
            heldItem = hit.collider.gameObject;
            heldItem.transform.SetParent(holdPosition);
            heldItem.transform.localPosition = Vector3.zero;

            Rigidbody2D rb = heldItem.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.isKinematic = true;

            Debug.Log("アイテムを持ちました: " + heldItem.name);
        }
    }

    void TryPlaceItemInBox()
    {
        Collider2D boxCollider = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("Box"));
        if (boxCollider != null)
        {
            boxCheck.CheckItem(heldItem);
            Destroy(heldItem);
            heldItem = null;
        }
        else
        {
            Debug.Log("ボックスが近くにありません");
        }
    }
}
