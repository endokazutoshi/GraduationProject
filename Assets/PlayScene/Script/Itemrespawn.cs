using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemrespawn : MonoBehaviour
{
    [SerializeField] GameObject item;  // 生成するアイテムのプレハブ
    float time = 0;
    bool isSpawn;

    // プレイヤー1とプレイヤー2のタグ名
    public string player1Tag = "Player1";
    public string player2Tag = "Player2";
    public float x, y;

    private bool isPlayerInRange = false; // プレイヤーが範囲内にいるかどうか

    // Start is called before the first frame update
    void Start()
    {
        isSpawn = false;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーが範囲内にいるかつBボタンが押されたときにアイテムをリスポーン
        if (isPlayerInRange && Input.GetButtonDown("B_Button_1P"))
        {
            Debug.Log("Bボタンが押された！アイテムをリスポーン");
            // アイテム生成までの時間をリセット
            time = 3.0f;  // 3秒間のタイマーをスタート
            isSpawn = true;
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
        // プレイヤー1またはプレイヤー2が範囲に入ったとき、範囲内フラグをセット
        if (other.CompareTag(player1Tag) || other.CompareTag(player2Tag))
        {
            Debug.Log("プレイヤーが範囲内に入った！");
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
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
    }
}
