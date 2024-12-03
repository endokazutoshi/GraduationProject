using UnityEngine;

public class InputItem : MonoBehaviour
{
    public GameObject box; // 対象のボックス
    public GameObject playerTouchItem; // PlayerTouchItemの参照

    private PlayerTouchItem playerScript; // PlayerTouchItemのスクリプト参照
    private bool isInBoxRange = false; // プレイヤーがボックス内にいるかどうか

    void Start()
    {
        // PlayerTouchItemスクリプトを取得
        playerScript = playerTouchItem.GetComponent<PlayerTouchItem>();
    }

    void Update()
    {
        // プレイヤーがボックス範囲内にいる場合
        if (isInBoxRange && playerScript != null && playerScript.GetCurrentItem() != null)
        {
            // Bボタンが押されたとき
            if (Input.GetButtonDown("Y_Button_1P"))
            {
                Debug.Log("Bボタンが押されました。");

                // プレイヤースクリプトが正しく取得できている場合
                if (playerScript.GetCurrentItem() != null)
                {
                    GameObject currentItem = playerScript.GetCurrentItem();

                    // アイテムをボックスに配置
                    PlaceItemInBox(currentItem);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            isInBoxRange = true;
            Debug.Log("ボックス範囲内にプレイヤーが入りました");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            isInBoxRange = false;
            Debug.Log("ボックス範囲からプレイヤーが出ました");
        }
    }

    void PlaceItemInBox(GameObject item)
    {
        // アイテムをボックス内に配置（ボックスの位置にアイテムを配置）
        item.transform.position = box.transform.position;

        // アイテムをボックスに入れた際に消去する
        Destroy(item);

        // PlayerTouchItemの持ち物をリセット
        playerScript.ClearCurrentItem();

        Debug.Log("アイテムをボックスに入れました: " + item.name);
    }
}
