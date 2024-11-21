using UnityEngine;
using System.Collections;

public class RangeChecker : MonoBehaviour
{
    public Transform player1;               // プレイヤー1のTransform
    public Transform player2;               // プレイヤー2のTransform
    public Vector2 rangeCenter;             // 範囲の中心座標
    public Vector2 rangeSize = new Vector2(5f, 5f); // 範囲のサイズ

    public GameObject imageObjectPlayer1;   // プレイヤー1用画像
    public GameObject imageObjectPlayer2;   // プレイヤー2用画像

    private Camera mainCamera; // プレイヤー1用カメラ
    private Camera secondCamera; // プレイヤー2用カメラ

    private bool isPlayer1ImageVisible = false; // プレイヤー1画像の表示状態
    private bool isPlayer2ImageVisible = false; // プレイヤー2画像の表示状態

    void Start()
    {
        // タグでカメラを探して設定
        GameObject cameraObject = GameObject.FindGameObjectWithTag("MCamera");

        if (cameraObject.CompareTag("MCamera"))
        {
            mainCamera = cameraObject.GetComponent<Camera>();
        }
        GameObject cameraObject2 = GameObject.FindGameObjectWithTag("SCamera");

        if (cameraObject2.CompareTag("SCamera"))
        {
            secondCamera = cameraObject2.GetComponent<Camera>();
        }

        // 画像を非表示に設定
        if (imageObjectPlayer1 != null) imageObjectPlayer1.SetActive(false);
        if (imageObjectPlayer2 != null) imageObjectPlayer2.SetActive(false);

        // Display 2を有効化
        if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate();
            Debug.Log("Display 2 Active: " + Display.displays[1].active); // 修正: isActive -> active
        }
    }

    void Update()
    {
        // プレイヤー1とプレイヤー2が範囲内にいるかを確認
        bool isPlayer1InRange = IsPlayerInRange(player1);
        bool isPlayer2InRange = IsPlayerInRange(player2);

        // プレイヤー1が範囲内にいて対応ボタンが押された場合
        if (isPlayer1InRange && Input.GetButtonDown("B_Button_1P"))
        {
            ToggleImage(imageObjectPlayer1, ref isPlayer1ImageVisible);
            if (mainCamera != null)
            {
                mainCamera.targetDisplay = 0; // Player 1の画像をDisplay 1に表示
            }
        }

        // プレイヤー2が範囲内にいて対応ボタンが押された場合
        if (isPlayer2InRange && Input.GetButtonDown("B_Button_2P"))
        {
            ToggleImage(imageObjectPlayer2, ref isPlayer2ImageVisible);
            if (secondCamera != null)
            {
                // 少し遅延してディスプレイを切り替え
                StartCoroutine(SwitchToSecondDisplay());
            }
        }
    }

    // 指定されたプレイヤーが範囲内にいるか判定する
    private bool IsPlayerInRange(Transform player)
    {
        if (player == null) return false;

        Vector2 playerPos = new Vector2(player.position.x, player.position.y);

        // 範囲の左下と右上を計算
        Vector2 bottomLeft = rangeCenter - rangeSize / 2;
        Vector2 topRight = rangeCenter + rangeSize / 2;

        // プレイヤーの位置が範囲内か判定
        return playerPos.x >= bottomLeft.x && playerPos.x <= topRight.x &&
               playerPos.y >= bottomLeft.y && playerPos.y <= topRight.y;
    }

    // 画像の表示と非表示を切り替える
    private void ToggleImage(GameObject imageObject, ref bool isVisible)
    {
        if (imageObject != null)
        {
            isVisible = !isVisible; // 表示状態を切り替える
            imageObject.SetActive(isVisible);
        }
    }

    // 範囲をシーンビューで可視化する（デバッグ用）
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(rangeCenter, rangeSize);
    }

    // 1フレーム遅延してDisplay 2に切り替えるコルーチン
    private IEnumerator SwitchToSecondDisplay()
    {
        yield return null; // 1フレーム遅延
        secondCamera.targetDisplay = 1; // Display 2にカメラを設定
        Debug.Log("Display 2に切り替え完了");
    }
}
