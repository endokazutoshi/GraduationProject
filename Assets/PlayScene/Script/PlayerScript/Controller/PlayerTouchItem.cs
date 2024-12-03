using UnityEngine;

public class PlayerTouchItem : MonoBehaviour
{
    public Transform holdPosition; // プレイヤーがアイテムを持つ位置
    private GameObject currentItem; // 持っているアイテム

    void Update()
    {
        // アイテムを持つ
        if (Input.GetButtonDown("B_Button_1P") && currentItem == null) // 持つボタン
        {
            Collider2D item = Physics2D.OverlapCircle(transform.position, 1.0f, LayerMask.GetMask("Item"));
            if (item != null)
            {
                currentItem = item.gameObject;
                PickUpItem(currentItem);
            }
        }

        // アイテムを落とす
        if (Input.GetButtonDown("Y_Button_1P") && currentItem != null) // 落とすボタン
        {
            DropItem();
        }
    }

    void PickUpItem(GameObject item)
    {
        // アイテムをプレイヤーの頭の上に配置
        item.transform.SetParent(holdPosition);
        item.transform.localPosition = Vector3.zero;

        // アイテムの物理挙動を無効化
        Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        Debug.Log("アイテムを持ちました: " + item.name);
    }

    void DropItem()
    {
        // アイテムを親オブジェクトから切り離す
        currentItem.transform.SetParent(null);

        // アイテムの物理挙動を有効化
        Rigidbody2D rb = currentItem.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        Debug.Log("アイテムを落としました: " + currentItem.name);
        currentItem = null;
    }

    public GameObject GetCurrentItem()
    {
        return currentItem;
    }

    public void ClearCurrentItem()
    {
        currentItem = null;
    }
}
