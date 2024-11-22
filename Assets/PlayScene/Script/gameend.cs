using UnityEngine;

public class gameend : MonoBehaviour
{
    // 他のオブジェクトと触れたときの処理
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("boxに触れました");
        // プレイヤータグが付いたオブジェクトに触れた場合
        if (other.CompareTag("Player1"))
        {
            // 実行を終了する
            Debug.Log("プレイヤーがオブジェクトに触れました。終了します。");
            Application.Quit();
        }
    }
}
