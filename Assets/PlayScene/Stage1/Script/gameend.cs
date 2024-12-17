using UnityEngine;
using UnityEngine.SceneManagement;  // SceneManagerを使うためにインポート

public class gameend : MonoBehaviour
{
    // 他のオブジェクトと触れたときの処理
    void OnTriggerEnter2D(Collider2D collider)
    {
        // プレイヤータグが付いたオブジェクトに触れた場合
        if (collider.CompareTag("Player1"))
        {
            Debug.Log("プレイヤー1がオブジェクトに触れました。リザルトシーンに遷移します。");
            SceneChange("Player1");
                        
        }
        // プレイヤータグが付いたオブジェクトに触れた場合
        if (collider.CompareTag("Player2"))
        {
            Debug.Log("プレイヤー2がオブジェクトに触れました。リザルトシーンに遷移します。");
            SceneChange("Player2");

        }
    }
    void SceneChange(string PlayerTag)
    {
        SceneManager.LoadScene("ResultScene");
    }
}
