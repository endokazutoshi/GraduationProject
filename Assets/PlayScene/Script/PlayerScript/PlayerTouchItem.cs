using UnityEngine;

public class PlayerTouchItem : MonoBehaviour
{
    // プレイヤーオブジェクトへの参照
    public GameObject player;

    private GameObject currentItem;
    private GameObject itemInRange;
    private bool isInBoxRange = false;  // Box内にアイテムがあるかどうかの判定

    // 入れられるアイテムをObject型の配列にする
    public Object[] validItems; // ボックスに入れられるアイテムのObject配列

    // 正解アイテムの設定
    public GameObject correctItem;  // 正解のアイテムを設定する

    void Update()
    {
        if (currentItem != null)
        {
            currentItem.transform.position = player.transform.position + new Vector3(0, 1, 0);
        }

        if (CompareTag("Player1"))
        {
            if (Input.GetButtonDown("B_Button_1P"))
            {
                Debug.Log("Player1: Bボタンが押されています");
                if (currentItem == null)
                {
                    TryPickUpItem();
                }
                else
                {
                    if (isInBoxRange)
                    {
                        PlaceItemInBox();
                    }
                    else
                    {
                        DropItem();
                    }
                }
            }
        }

        if (CompareTag("Player2"))
        {
            if (Input.GetButtonDown("B_Button_2P"))
            {
                Debug.Log("Player2: Bボタンが押されています");
                if (currentItem == null)
                {
                    TryPickUpItem();
                }
                else
                {
                    if (isInBoxRange)
                    {
                        PlaceItemInBox();
                    }
                    else
                    {
                        DropItem();
                    }
                }
            }
        }
    }

    // アイテムを拾う処理
    void TryPickUpItem()
    {
        if (itemInRange != null)
        {
            currentItem = itemInRange;
            Debug.Log("アイテムを持ちました: " + currentItem.name);

            currentItem.transform.position = player.transform.position + new Vector3(0, 1, 0);
            Debug.Log("アイテムの位置: " + currentItem.transform.position);

            Rigidbody2D rb = currentItem.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            currentItem.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    // アイテムをBoxに入れる処理
    void PlaceItemInBox()
    {
        // ボックス内に入れられるアイテムかをチェック
        if (IsValidItem(currentItem))
        {
            BoxCollider2D boxCollider = itemInRange.GetComponent<BoxCollider2D>();

            if (boxCollider != null)
            {
                currentItem.transform.position = itemInRange.transform.position;
                Debug.Log("アイテムをBox内に配置しました: " + currentItem.name);

                // アイテムが正解かどうかをチェック
                if (IsCorrectItem(currentItem)) // 正解の場合
                {
                    // アイテムを削除
                    Destroy(currentItem);
                    currentItem = null;
                    // 正解だった場合、指定のオブジェクトを削除
                    RemoveObjectByName("Square (9)");
                    RemoveObjectByName("Square (10)");
                    RemoveObjectByName("Square (25)");
                    RemoveObjectByName("Square (26)");


                    // アイテムの物理挙動を再度有効化
                    Rigidbody2D rb = currentItem.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        rb.isKinematic = true;
                    }

          
                    // "Box"にアイテムを入れた後、状態をリセット
                    isInBoxRange = false;
                }
                else
                {

                    Destroy(currentItem);
                    currentItem = null;
                    Debug.Log("不正解のアイテムが入れられました");
                    // 正解でなければ、アイテムはそのままボックスに置くだけ
                    // 特に削除などの処理は行わない
                }
            }
        }
        else
        {
            Debug.Log("このアイテムはボックスに入れられません: " + currentItem.name);
        }
    }

    // 正解のアイテムかを判定するメソッド
    bool IsCorrectItem(GameObject item)
    {
        // ここで正解のアイテムかどうかを判定
        return item == correctItem;  // ボックスに入れられたアイテムが正解かを確認
    }

    // アイテムをドロップする処理
    void DropItem()
    {
        if (currentItem != null)  // アイテムを持っている場合
        {
            // ドロップ先の位置を計算（プレイヤーの右側）
            Vector3 dropPosition = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z);

            // アイテムをドロップ
            currentItem.transform.position = dropPosition;
            Debug.Log("アイテムをドロップしました: " + currentItem.name);

            // アイテムの物理挙動を再度有効化
            Rigidbody2D rb = currentItem.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true; // 物理シミュレーションを有効化
            }

            // アイテムを持っていない状態にする
            currentItem = null;
        }
    }

    // アイテムが範囲内に入ると呼び出される
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            itemInRange = other.gameObject;
            Debug.Log("アイテムが範囲に入りました: " + other.name);
        }

        if (other.CompareTag("Box"))
        {
            isInBoxRange = true;
            Debug.Log("Box内に入った");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            itemInRange = null;
            Debug.Log("アイテムが範囲から出ました: " + other.name);
        }

        if (other.CompareTag("Box"))
        {
            isInBoxRange = false;
            Debug.Log("Boxから出た");
        }
    }

    // アイテムがボックスに入れるかどうかを判定
    bool IsValidItem(GameObject item)
    {
        foreach (Object validItem in validItems)
        {
            if (validItem != null && validItem is GameObject && ((GameObject)validItem).CompareTag(item.tag))
            {
                return true;  // アイテムが有効なObjectを持っていればボックスに入れられる
            }
        }
        return false;  // 有効なObjectがない場合、ボックスに入れられない
    }

    // 名前でオブジェクトを検索して削除する
    void RemoveObjectByName(string objectName)
    {
        GameObject objectToDelete = GameObject.Find(objectName);

        if (objectToDelete != null)
        {
            Destroy(objectToDelete);  // オブジェクトを削除
            Debug.Log(objectName + " を削除しました");
        }
        else
        {
            Debug.LogWarning(objectName + " がシーン内に見つかりませんでした");
        }
    }
}
