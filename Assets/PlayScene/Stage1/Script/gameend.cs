using UnityEngine;
using UnityEngine.SceneManagement;  // SceneManagerを使うためにインポート

public class gameend : MonoBehaviour
{
    // 他のオブジェクトと触れたときの処理
    void OnTriggerEnter2D(Collider2D collider)
    {
        // プレイヤー1が触れた場合
        if (collider.CompareTag("Player1"))
        {
            Debug.Log("プレイヤー1がオブジェクトに触れました。リザルトシーンに遷移します。");

            // プレイヤー1のゴール数を保存
            PlayerPrefs.SetInt("Player1Goal", 1);  // プレイヤー1のゴールを1に設定
            PlayerPrefs.SetInt("Player2Goal", 0);  // プレイヤー2のゴールを0に設定

            SceneChange();
        }
        // プレイヤー2が触れた場合
        else if (collider.CompareTag("Player2"))
        {
            Debug.Log("プレイヤー2がオブジェクトに触れました。リザルトシーンに遷移します。");

            // プレイヤー2のゴール数を保存
            PlayerPrefs.SetInt("Player1Goal", 0);  // プレイヤー1のゴールを0に設定
            PlayerPrefs.SetInt("Player2Goal", 1);  // プレイヤー2のゴールを1に設定

            SceneChange();
        }
    }

    void SceneChange()
    {
        SceneManager.LoadScene("ResultScene2");  // リザルトシーンに遷移
    }
}
