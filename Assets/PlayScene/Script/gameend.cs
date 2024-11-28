using UnityEngine;

public class gameend : MonoBehaviour
{
    // 他のオブジェクトと触れたときの処理
    void OnTriggerEnter2D(Collider2D collider)
    {
        // プレイヤータグが付いたオブジェクトに触れた場合
        if (collider.CompareTag("Player1"))
        {
            Debug.Log("プレイヤーがオブジェクトに触れました。終了します。");

            // 実行を終了する
            // エディタでも動作確認するためにエディタチェック
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
