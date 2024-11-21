using UnityEngine;
using UnityEngine.UI;

public class InputItem: MonoBehaviour
{
    public GameObject item; // プレイヤーが持っているアイテム
    public Transform boxPosition; // 箱の位置
    public Text promptText; // UIのテキスト（箱に入れるメッセージ）
    public float interactDistance = 2f; // インタラクト可能な距離

    void Start()
    {
        // 最初に「箱に入れる」のテキストを非表示にする
        promptText.gameObject.SetActive(false);
    }

    void Update()
    {
        // プレイヤーが箱の近くにいるかチェック
        if (Vector3.Distance(transform.position, boxPosition.position) <= interactDistance)
        {
            // プレイヤーが持っているアイテムが「Item」タグを持っている場合
            if (item != null && item.CompareTag("Item"))
            {
                promptText.gameObject.SetActive(true); // 近くにいる場合はメッセージを表示
                promptText.text = "箱に入れる (E)"; // メッセージを表示

                // 箱のX-1の位置にテキストを配置
                Vector3 textPosition = new Vector3(boxPosition.position.x - 1f, boxPosition.position.y, boxPosition.position.z);
                promptText.transform.position = textPosition; // テキストの位置を設定

                // ボタン「E」を押したときにアイテムを箱に入れる
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StoreItemInBox();
                }
            }
        }
        else
        {
            promptText.gameObject.SetActive(false); // 箱から離れるとメッセージを非表示
        }
    }

    void StoreItemInBox()
    {
        if (item != null && item.CompareTag("Item"))
        {
            // アイテムを箱に入れる処理（インベントリに移動、アイテムオブジェクトの削除等）
            Debug.Log("アイテムを箱に入れました");
            Destroy(item); // アイテムを箱に入れた後、アイテムを削除
            item = null; // プレイヤーのインベントリからアイテムを削除
            promptText.gameObject.SetActive(false); // メッセージを非表示にする
        }
    }

    // プレイヤーがBoxの範囲に入った場合の処理
    private void OnTriggerEnter(Collider other)
    {
        // 相手が"Box"タグを持っている場合に反応
        if (other.CompareTag("Box"))
        {
            Debug.Log("プレイヤーがBoxの範囲に入りました");
        }
    }

    // プレイヤーがBoxの範囲から出た場合の処理
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Debug.Log("プレイヤーがBoxの範囲から出ました");
        }
    }
}
