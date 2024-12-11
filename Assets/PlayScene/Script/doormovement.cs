using UnityEngine;

public class Doormovement : MonoBehaviour
{
    public Transform targetPosition1;  // プレイヤー1の移動先位置
    public Transform targetPosition2;  // プレイヤー2の移動先位置
    private bool canOpenDoor1 = false; // プレイヤー1がドアを開ける状態
    private bool canOpenDoor2 = false; // プレイヤー2がドアを開ける状態
    private GameObject player1;        // プレイヤー1のオブジェクト
    private GameObject player2;        // プレイヤー2のオブジェクト

    void Start()
    {
        // 初期設定
    }

    void Update()
    {
        // プレイヤー1がBボタンを押した場合
        if (canOpenDoor1 && Input.GetButtonDown("B_Button_1P"))
        {
            Debug.Log("Player 1's Bボタンが押されました！");
            OpenDoor("Player1");
        }

        // プレイヤー2がBボタンを押した場合
        if (canOpenDoor2 && Input.GetButtonDown("B_Button_2P"))
        {
            Debug.Log("Player 2's Bボタンが押されました！");
            OpenDoor("Player2");
        }
    }

    // プレイヤーがオブジェクトに触れたとき
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            canOpenDoor1 = true;  // プレイヤー1が触れたらBボタンが効く
            Debug.Log("Player 1 がオブジェクトに触れました！");
            player1 = other.gameObject;  // プレイヤー1のオブジェクトを設定
        }
        else if (other.CompareTag("Player2"))
        {
            canOpenDoor2 = true;  // プレイヤー2が触れたらBボタンが効く
            Debug.Log("Player 2 がオブジェクトに触れました！");
            player2 = other.gameObject;  // プレイヤー2のオブジェクトを設定
        }
    }

    // プレイヤーがオブジェクトから離れたとき
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            canOpenDoor1 = false;  // プレイヤー1が離れたらBボタンが効かなくなる
            Debug.Log("Player 1 がオブジェクトから離れました！");
            player1 = null;  // プレイヤー1のオブジェクトをリセット
        }
        else if (other.CompareTag("Player2"))
        {
            canOpenDoor2 = false;  // プレイヤー2が離れたらBボタンが効かなくなる
            Debug.Log("Player 2 がオブジェクトから離れました！");
            player2 = null;  // プレイヤー2のオブジェクトをリセット
        }
    }

    // ドアを開けるメソッド
    void OpenDoor(string playerTag)
    {
        if (playerTag == "Player1" && player1 != null && targetPosition1 != null)
        {
            // プレイヤー1が触れた場合
            Debug.Log("Player 1 のドアを開けます！");
            player1.transform.position = targetPosition1.position;  // プレイヤー1を移動
        }
        else if (playerTag == "Player2" && player2 != null && targetPosition2 != null)
        {
            // プレイヤー2が触れた場合
            Debug.Log("Player 2 のドアを開けます！");
            player2.transform.position = targetPosition2.position;  // プレイヤー2を移動
        }
    }
}
