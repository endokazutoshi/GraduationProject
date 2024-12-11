using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemRespawn : MonoBehaviour
{
    [SerializeField] GameObject item;  // 生成するアイテムのプレハブ
<<<<<<< HEAD
    float time = 0;
    bool isSpawn;
=======
    public float respawnTime = 3.0f;  // アイテムがリスポーンするまでの時間
    private float timeRemaining;  // 残り時間
    public float x, y; //リスポーンの座標
>>>>>>> b2ba948a76161793199e120b2c525b8e38316696

    // プレイヤー1とプレイヤー2のタグ名
    public string player1Tag = "Player1";
    public string player2Tag = "Player2";
<<<<<<< HEAD
    public float x, y;

    private bool isPlayerInRange = false; // プレイヤーが範囲内にいるかどうか

    // Start is called before the first frame update
    void Start()
    {
        isSpawn = false;
        time = 0;
=======

    private bool isPlayerInItemLayer = false; // プレイヤーがItemレイヤー内にいるかどうか
    private bool isRespawnTriggered = false; // リスポーンがトリガーされたかどうか

    private Vector2 spawnPosition; // アイテムの生成位置

    void Start()
    {
        timeRemaining = 0f;
        isRespawnTriggered = false;
>>>>>>> b2ba948a76161793199e120b2c525b8e38316696
    }

    void Update()
    {
<<<<<<< HEAD
        // プレイヤーが範囲内にいるかつBボタンが押されたときにアイテムをリスポーン
        if (isPlayerInRange && Input.GetButtonDown("B_Button_1P"))
        {
            Debug.Log("Bボタンが押された！アイテムをリスポーン");
            // アイテム生成までの時間をリセット
            time = 3.0f;  // 3秒間のタイマーをスタート
            isSpawn = true;
=======
        // プレイヤー1がItemレイヤー内にいてBボタンが押された場合にタイマーを開始
        if (isPlayerInItemLayer && Input.GetButtonDown("B_Button_1P")&& !isRespawnTriggered)
        {
            Debug.Log("Bボタンが押された！アイテムをリスポーン");
            timeRemaining = respawnTime;  // タイマーをセット
            isRespawnTriggered = true;
        }

        // プレイヤー2がItemレイヤー内にいてBボタンが押された場合にタイマーを開始
        if (isPlayerInItemLayer && Input.GetButtonDown("B_Button_2P") && !isRespawnTriggered)
        {
            Debug.Log("Bボタンが押された！アイテムをリスポーン");
            timeRemaining = respawnTime;  // タイマーをセット
            isRespawnTriggered = true;
        }

        // タイマーが進行し、0になるとアイテムをリスポーン
        if (isRespawnTriggered && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            Debug.Log("Remaining Time: " + timeRemaining);
        }
        else if (timeRemaining <= 0 && isRespawnTriggered)
        {
            RespawnItem();
>>>>>>> b2ba948a76161793199e120b2c525b8e38316696
        }

        // プレイヤーが範囲内にいなくても、常にタイマーが減少
        if (time > 0)
        {
            time -= Time.deltaTime;  // 時間が経過するごとに減少
            Debug.Log("Remaining Time: " + time);
        }

        // タイマーが0になったらアイテムを生成
        if (time <= 0 && isSpawn)
        {
            Itemspawn();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
<<<<<<< HEAD
        // プレイヤー1またはプレイヤー2が範囲に入ったとき、範囲内フラグをセット
        if (other.CompareTag(player1Tag) || other.CompareTag(player2Tag))
        {
            Debug.Log("プレイヤーが範囲内に入った！");
            isPlayerInRange = true;
=======
        // プレイヤー1またはプレイヤー2がItemレイヤー内に入ったとき、範囲内フラグをセット
        if (other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            Debug.Log("プレイヤーがItemレイヤー内に入った！");
            isPlayerInItemLayer = true;
>>>>>>> b2ba948a76161793199e120b2c525b8e38316696
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
<<<<<<< HEAD
        // プレイヤーが範囲外に出たとき、範囲内フラグをリセット
        if (other.CompareTag(player1Tag) || other.CompareTag(player2Tag))
        {
            Debug.Log("プレイヤーが範囲外に出た！");
            isPlayerInRange = false;
        }
    }

    void Itemspawn()
    {
        // アイテムを生成（指定された位置で生成）
        Instantiate(item, new Vector2(x, y), Quaternion.identity);
        Debug.Log("Itemspawn: アイテムをリスポーン");
        isSpawn = false;  // アイテム生成後、フラグをリセット
=======
        // プレイヤーがItemレイヤーから出たとき、範囲内フラグをリセット
        if (other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            Debug.Log("プレイヤーがItemレイヤーから出た！");
            isPlayerInItemLayer = false;
        }
    }

    void RespawnItem()
    {
        // アイテムを指定された位置で生成
        Instantiate(item, new Vector2(x, y), Quaternion.identity);
        Debug.Log("アイテムをリスポーンしました！");
        isRespawnTriggered = false;  // リスポーンフラグをリセット
    }

    // アイテムのリスポーン位置を設定するメソッド
    public void SetSpawnPosition(Vector2 position)
    {
        spawnPosition = position;
>>>>>>> b2ba948a76161793199e120b2c525b8e38316696
    }
}
