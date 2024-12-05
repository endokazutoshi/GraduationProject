using UnityEngine;

public class Doormovement : MonoBehaviour
{
    public Transform targetPosition;  // 移動先の位置
    private bool canOpenDoor = false;  // ドアが開く状態かどうか
    private GameObject objectPlayer;  // 移動させたいオブジェクト

    void Start()
    {
        // 初期設定
    }

    void Update()
    {
        // Bボタンが押されていて、かつ触れている場合にドアを開ける
        if (canOpenDoor && Input.GetButtonDown("B_Button_1P"))
        {
            Debug.Log("Player 1's Bボタンが押されました！");
            OpenDoor("Player1");
        }
        // Bボタンが押されていて、かつ触れている場合にドアを開ける
        if (canOpenDoor && Input.GetButtonDown("B_Button_2P"))
        {
            Debug.Log("Player 2's Bボタンが押されました！");
            OpenDoor("Player2");
        }
    }

    // プレイヤーがオブジェクトに触れたとき
    void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤー1のタグを確認
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            canOpenDoor = true;  // プレイヤーが触れたらBボタンが効くようにする
            Debug.Log("プレイヤーがオブジェクトに触れました！");
            objectPlayer = other.gameObject;  // 触れたプレイヤーオブジェクトを設定
        }
    }

    // プレイヤーがオブジェクトから離れたとき
    void OnTriggerExit2D(Collider2D other)
    {
        // プレイヤーのタグを確認
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            canOpenDoor = false;  // プレイヤーが離れたらBボタンが効かなくなる
            Debug.Log("プレイヤーがオブジェクトから離れました！");
            objectPlayer = null;  // プレイヤーが離れたらオブジェクトをリセット
        }
    }

    // ドアを開けるメソッド
    void OpenDoor(string playerTag)
    {
        if (objectPlayer != null && targetPosition != null)
        {
            // タグによって異なる処理を行う場合もありますが、今回は共通処理にしています
            Debug.Log($"{playerTag} のドアを開けます！");
            // オブジェクトをターゲット位置に移動させる
            objectPlayer.transform.position = targetPosition.position;
        }
    }
}
