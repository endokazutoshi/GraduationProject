using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Itemrespawn : MonoBehaviour
{
    [SerializeField] GameObject item;//生成するアイテムのプレハブ
    float time;
    bool isSpawn;
    public float x, y;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isSpawn = false;

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0 && !isSpawn)
        {
            // アイテムを生成（位置は2D空間上で指定）
            Instantiate(item, new Vector3(x, y, 0), Quaternion.identity);
            isSpawn = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // アイテムと衝突した場合の処理
        if (other.gameObject.CompareTag("Item"))
        {
            //Destroy(other.gameObject);  // アイテムを消去
            time = 1.0f;  // アイテム生成までの時間をリセット
            isSpawn = false;  // 再度アイテムを生成できるように
        }
    }
}

