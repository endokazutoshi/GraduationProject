using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemRespawn2 : MonoBehaviour
{
    [SerializeField] GameObject item;  // 生成するアイテムのプレハブ
    public float respawnTime = 3.0f;  // アイテムがリスポーンするまでの時間
    private float timeRemaining;  // 残り時間
    public float x, y; //リスポーンの座標

    // プレイヤー1とプレイヤー2のタグ名
   // public string player1Tag = "Player1";
    public string player2Tag = "Player2";
    public string ItemtagName; //アイテムの名前
                               // private bool isPlayer1InItemLayer = false; // プレイヤーがItemレイヤー内にいるかどうか
    private bool isPlayer2InItemLayer = false; // プレイヤーがItemレイヤー内にいるかどうか
    private bool isRespawnTriggered = false; // リスポーンがトリガーされたかどうか

    private Vector2 spawnPosition; // アイテムの生成位置

    void Start()
    {
        timeRemaining = 0f;
        isRespawnTriggered = false;
    }

    void Update()
    {

        // プレイヤー2がItemレイヤー内にいてBボタンが押された場合にタイマーを開始
        if (isPlayer2InItemLayer && Input.GetButtonDown("B_Button_2P") && !isRespawnTriggered)
        {
            Debug.Log("Bボタンが押された！アイテムをリスポーン");
            timeRemaining = respawnTime;  // タイマーをセット
            isRespawnTriggered = true;
        }

        // タイマーが進行し、0になるとアイテムをリスポーン
        if (isRespawnTriggered && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            //Debug.Log("Remaining Time: " + timeRemaining);
        }
        else if (timeRemaining <= 0 && isRespawnTriggered)
        {
            RespawnItem();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        // プレイヤー2がItemレイヤー内に入ったとき、範囲内フラグをセット
        if (other.CompareTag(ItemtagName))
        {
            Debug.Log("プレイヤー2がItemレイヤー内に入った！");
            isPlayer2InItemLayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("other"+other);
        
        // プレイヤー2がItemレイヤーから出たとき、範囲内フラグをリセット
        if (other.CompareTag(ItemtagName))
        {
            Debug.Log("プレイヤー2がItemレイヤーから出た！");
            isPlayer2InItemLayer = false;
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
    }
}
