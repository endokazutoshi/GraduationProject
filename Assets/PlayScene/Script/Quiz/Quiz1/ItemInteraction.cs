using UnityEngine;

public class ItemInteractio : MonoBehaviour
{
    public Transform holdPosition;  // プレイヤーがアイテムを持つ位置
    private GameObject heldItem;    // 持っているアイテム
    public LayerMask itemLayer;     // アイテムのレイヤーマスク
    private BoxCheck boxCheck;      // ボックスをチェックするための参照
    private BoxCheck1 boxCheck1;
    private bool isHoldingItem = false;  // アイテムを持っているかどうかを判定するフラグ
    public float itemYOffset = 0.5f; // アイテムのY軸位置調整用
    public float dropYOffset = 0.5f;

    void Start()
    {
        boxCheck = FindObjectOfType<BoxCheck>();

        if (boxCheck1 == null)
        {
            Debug.LogError("BoxCheck1 がシーン内に存在しません！");
        }
        else
        {
            Debug.Log("BoxCheck1はシーン内に存在します！");
        }
    }


    void Update()
    {
        // プレイヤー1の操作
        if (CompareTag("Player1"))
        {
            // Bボタンでアイテムを持つ／落とす
            if (Input.GetButtonDown("B_Button_1P"))
            {
                if (!isHoldingItem)
                {
                    // アイテムを持っていない場合、拾う操作を行う
                    TryPickUpItem();
                }
                else
                {
                    // アイテムを持っている場合、アイテムを落とす
                    DropItem(new Vector3(0,dropYOffset,0));
                }
            }

            // アイテムをボックスに入れる操作（Yボタン）
            if (Input.GetButtonDown("Y_Button_1P") && isHoldingItem)
            {
                TryPlaceItemInBox();
           
            }
        }

        // プレイヤー2の操作
        if (CompareTag("Player2"))
        {
            // Bボタンでアイテムを持つ／落とす
            if (Input.GetButtonDown("B_Button_2P"))
            {
                if (!isHoldingItem)
                {
                    // アイテムを持っていない場合、拾う操作を行う
                    TryPickUpItem();
                }
                else
                {
                    // アイテムを持っている場合、アイテムを落とす
                    DropItem(new Vector3(0, dropYOffset, 0));
                }
            }

            // アイテムをボックスに入れる操作（Yボタン）
            if (Input.GetButtonDown("Y_Button_2P") && isHoldingItem)
            {
                TryPlaceItemInBox();
                
            }
        }
    }

    void TryPickUpItem()
    {
        // アイテムを拾う判定: プレイヤーの位置を基準にRaycastでアイテムを検出
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f, itemLayer);
        if (hit.collider != null)
        {
            heldItem = hit.collider.gameObject;
            heldItem.transform.SetParent(holdPosition);
            heldItem.transform.localPosition = new Vector3(0,itemYOffset,0);  // プレイヤーの持つ位置に固定

            Rigidbody2D rb = heldItem.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true;  // アイテムの物理挙動を無効化
            }

            isHoldingItem = true;  // アイテムを持った状態にする
            Debug.Log("アイテムを持ちました: " + heldItem.name);
        }
    }

    void TryPlaceItemInBox()
    {
        // ボックスにアイテムを配置: プレイヤーの持つ位置を基準に
        Collider2D boxCollider = Physics2D.OverlapCircle(holdPosition.position, 1f, LayerMask.GetMask("Box"));
        if (boxCollider != null)
        {
            boxCheck.CheckItem(heldItem);  // アイテムをボックスに入れる処理
            Destroy(heldItem);  // アイテムを破壊（配置後）
            heldItem = null;
            isHoldingItem = false;  // アイテムを手放した状態にする
        }
        else
        {
            Debug.Log("ボックスが近くにありません");
        }
    }

    void DropItem(Vector3 dropOffset)
    {
        // アイテムを親オブジェクトから切り離す
        heldItem.transform.SetParent(null);
        heldItem.transform.position = transform.position + dropOffset;

        // アイテムの物理挙動を再度有効化
        Rigidbody2D rb = heldItem.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = true;  // 物理挙動を再度有効化
        }

        // アイテムを落とした後に情報をログに表示
        Debug.Log("アイテムを落としました: " + heldItem.name);
        heldItem = null;
        isHoldingItem = false;  // アイテムを手放した状態にする
    }
}
