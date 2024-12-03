using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public bool hasItem = false; // アイテムを持っているか
    private GameObject heldItem; // 持っているアイテム
    public Transform holdPosition; // アイテムを持つ位置（例えばプレイヤーの手の位置）

    void Update()
    {
        // アイテムを持つ処理
        if (Input.GetButtonDown("B_Button_1P") && !hasItem)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f);
            if (hit.collider != null && hit.collider.CompareTag("Item"))
            {
                heldItem = hit.collider.gameObject;
                PickUpItem(heldItem);
            }
        }
        // アイテムを手放す処理
        else if (Input.GetButtonDown("B_Button_1P") && hasItem)
        {
            DropItem();
        }

        // アイテムをボックスに入れる処理
        if (hasItem && Input.GetButtonDown("B_Button_1P")) // Fキーでアイテムをボックスに入れる
        {
            PlaceItemInBox();
        }
    }

    // アイテムを持つ処理
    void PickUpItem(GameObject item)
    {
        item.transform.SetParent(holdPosition);
        item.transform.localPosition = Vector3.zero; // 持つ位置を調整

        Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = true; // 物理演算を無効にする
        }

        hasItem = true;
        Debug.Log("アイテムを持ちました: " + item.name);
    }

    // アイテムを手放す処理
    void DropItem()
    {
        if (heldItem != null)
        {
            heldItem.transform.SetParent(null); // アイテムの親を解除

            Rigidbody2D rb = heldItem.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = false; // 物理演算を有効にする
            }

            Debug.Log("アイテムを手放しました: " + heldItem.name);
            heldItem = null;
            hasItem = false;
        }
    }

    // アイテムをボックスに入れる処理
    void PlaceItemInBox()
    {
        if (heldItem != null)
        {
            // アイテムをボックスの位置に移動
            heldItem.transform.position = transform.position;

            // アイテムをボックスに入れる
            Debug.Log("アイテムをボックスに入れました: " + heldItem.name);

            // ボックスの正誤判定を呼び出す
            BoxCheck boxCheck = FindObjectOfType<BoxCheck>(); // シーン内のBoxCheckスクリプトを探す
            if (boxCheck != null)
            {
                boxCheck.CheckItem(heldItem); // アイテムがボックスに入れられた際に正誤判定を行う
            }

            // アイテムを消去
            Destroy(heldItem);

            // アイテムを手放す
            DropItem();
        }
    }
}
