using UnityEngine;

public class PlayerTouchItem : MonoBehaviour
{
    // プレイヤーオブジェクトへの参照
    public GameObject player; // プレイヤーオブジェクトをインスペクタで設定

    private GameObject currentItem;
    private GameObject itemInRange;

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
                    DropItem(); // アイテムを離す
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
                    DropItem(); // アイテムを離す
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

            // Rigidbody2DのisKinematicを有効にして物理シミュレーションを無効化
            currentItem.GetComponent<Rigidbody2D>().isKinematic = true;

            // BoxCollider2DのIs Triggerを有効にして、物理的衝突を無視
            currentItem.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    void DropItem()
    {
        if (currentItem != null)  // アイテムを持っている場合
        {
            // ドロップ先の位置を計算（プレイヤーの右側）
            Vector3 dropPosition = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z);

            // アイテムの範囲（BoxCollider2Dの大きさを使う）
            BoxCollider2D itemCollider = currentItem.GetComponent<BoxCollider2D>();

            // アイテムのドロップ位置に対して、重なっているものがあるかをチェック
            Collider2D[] colliders = Physics2D.OverlapBoxAll(dropPosition, itemCollider.size, 0f); // 0fで回転を無視

            bool isWallDetected = false;

            // 重なっているコライダーの中にWallタグがあるかをチェック
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Wall"))
                {
                    isWallDetected = true;
                    break;  // Wallが見つかれば、ループを終了
                }
            }

            if (isWallDetected)
            {
                // 壁がある場合、アイテムをプレイヤーの位置に戻す
                dropPosition = player.transform.position;
                Debug.Log("右側に壁があるため、アイテムをプレイヤーの位置に戻しました");
            }

            // アイテムをドロップ
            currentItem.transform.position = dropPosition;
            Debug.Log("アイテムをドロップしました: " + currentItem.name);

            // アイテムのRigidbody2DのisKinematicを無効にして物理シミュレーションを有効化
            Rigidbody2D rb = currentItem.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true; // アイテムをドロップする際に物理シミュレーションを有効化
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
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            itemInRange = null;  // 範囲外に出たアイテムを記録
            Debug.Log("アイテムが範囲から出ました: " + other.name);
        }
    }
}
