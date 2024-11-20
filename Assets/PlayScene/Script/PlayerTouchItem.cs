using UnityEngine;

public class PlayerTouchItem : MonoBehaviour
{
    // プレイヤーオブジェクトへの参照
    public GameObject player; // プレイヤーオブジェクトをインスペクタで設定

    private GameObject currentItem;
    private GameObject itemInRange;
    private bool isInBoxRange = false;  // Box内にアイテムがあるかどうかの判定

    void Update()
    {
        if (currentItem != null) // アイテムを持っている場合
        {
            // プレイヤーの頭の上にアイテムを追従させる
            currentItem.transform.position = player.transform.position + new Vector3(0, 1, 0);  // Y + 1
        }

        // プレイヤー1の操作
        if (CompareTag("Player1"))
        {
            if (Input.GetButtonDown("B_Button_1P")) // Bボタンで持つ/離す
            {
                Debug.Log("Player1: Bボタンが押されています");
                if (currentItem == null)
                {
                    TryPickUpItem(); // アイテムを持つ
                }
                else
                {
                    if (isInBoxRange)  // Box内に入っている場合は、アイテムをBox内に置く
                    {
                        PlaceItemInBox();  // アイテムをBox内に置く処理
                    }
                    else
                    {
                        DropItem(); // アイテムを離す
                    }
                }
            }
        }

        // プレイヤー2の操作
        if (CompareTag("Player2"))
        {
            if (Input.GetButtonDown("B_Button_2P")) // Bボタンで持つ/離す
            {
                Debug.Log("Player2: Bボタンが押されています");
                if (currentItem == null)
                {
                    TryPickUpItem(); // アイテムを持つ
                }
                else
                {
                    if (isInBoxRange)  // Box内に入っている場合は、アイテムをBox内に置く
                    {
                        PlaceItemInBox();  // アイテムをBox内に置く処理
                    }
                    else
                    {
                        DropItem(); // アイテムを離す
                    }
                }
            }
        }
    }

    // アイテムを拾う処理
    void TryPickUpItem()
    {
        if (itemInRange != null)  // アイテムが範囲内にある場合
        {
            currentItem = itemInRange;  // アイテムを持つ
            Debug.Log("アイテムを持ちました: " + currentItem.name);

            // アイテムの位置をプレイヤーの頭の上に設定（プレイヤーオブジェクトを基準）
            currentItem.transform.position = player.transform.position + new Vector3(0, 1, 0);  // Y + 1
            Debug.Log("アイテムの位置: " + currentItem.transform.position);

            // アイテムの物理挙動を無効化（アイテムを持つ）
            Rigidbody2D rb = currentItem.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true; // 物理シミュレーションを無効化
            }

            // BoxCollider2DのIs Triggerを有効にして、物理的衝突を無視
            currentItem.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    // アイテムをBoxに入れる処理
    void PlaceItemInBox()
    {
        // Boxの範囲内にアイテムを配置
        BoxCollider2D boxCollider = itemInRange.GetComponent<BoxCollider2D>();  // BoxCollider2Dを取得

        if (boxCollider != null)
        {
            // Box内にアイテムを配置（Boxの中心にアイテムを配置）
            currentItem.transform.position = itemInRange.transform.position;
            Debug.Log("アイテムをBox内に配置しました: " + currentItem.name);

            if (currentItem != null)
            {
                Destroy(currentItem);  // アイテムをシーンから削除
                currentItem = null;  // アイテムを持っていない状態に戻す
                Debug.Log("アイテムを削除しました");
            }

            // "ItemBox"という名前のオブジェクトを削除する
            RemoveObjectByName("Square (9)");
            // "ItemBox"という名前のオブジェクトを削除する
            RemoveObjectByName("Square (10)");
            // "ItemBox"という名前のオブジェクトを削除する
            RemoveObjectByName("Square (25)");
            // "ItemBox"という名前のオブジェクトを削除する
            RemoveObjectByName("Square (26)");

            // アイテムの物理挙動を再度有効化
            Rigidbody2D rb = currentItem.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true; // 物理シミュレーションを有効化
            }

            // アイテムを持っていない状態にする
            currentItem = null;
            isInBoxRange = false;  // Box内から出た状態にする
        }
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

    // アイテムが範囲内に入ると呼び出される（範囲チェック用）
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            itemInRange = other.gameObject;  // 範囲内のアイテムを記録
            Debug.Log("アイテムが範囲に入りました: " + other.name);
        }

        if (other.CompareTag("Box"))
        {
            isInBoxRange = true;  // アイテムがBoxの範囲内に入ったことを記録4
                                  // アイテムの物理挙動を再度有効化

            Debug.Log("Box内に入った");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            itemInRange = null;  // 範囲外に出たアイテムを記録
            Debug.Log("アイテムが範囲から出ました: " + other.name);
        }

        if (other.CompareTag("Box"))
        {
            isInBoxRange = false;  // アイテムがBoxの範囲外に出たことを記録
            Debug.Log("Boxから出た");
        }
    }

    // 名前でオブジェクトを検索して削除する
    void RemoveObjectByName(string objectName)
    {
        // 名前でオブジェクトを検索
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
