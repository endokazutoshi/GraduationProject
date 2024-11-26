using UnityEngine;
using System.Collections;

public class RangeChecker : MonoBehaviour
{
    public string player1Tag = "Player1";           // プレイヤー1のTag
    public string player2Tag = "Player2";           // プレイヤー2のTag

    public GameObject rangeObject;                  // 範囲を指定するオブジェクト(Square)
    public GameObject imageObjectPlayer1;           // プレイヤー1用画像
    public GameObject imageObjectPlayer2;           // プレイヤー2用画像

    private Camera mainCamera;                      // プレイヤー1用カメラ
    private Camera secondCamera;                    // プレイヤー2用カメラ

    private bool isPlayer1ImageVisible = false;     // プレイヤー1画像の表示状態
    private bool isPlayer2ImageVisible = false;     // プレイヤー2画像の表示状態

    private Collider2D rangeCollider;               // 範囲オブジェクトのCollider2D

    void Start()
    {
        // `rangeObject`からCollider2Dを取得
        if (rangeObject != null)
        {
            rangeCollider = rangeObject.GetComponent<Collider2D>();
            if (rangeCollider == null)
            {
                Debug.LogError("範囲オブジェクトにCollider2Dが設定されていません。");
            }
        }
        else
        {
            Debug.LogError("範囲オブジェクトが設定されていません。");
        }

        // タグでカメラを探して設定
        GameObject cameraObject = GameObject.FindGameObjectWithTag("MCamera");
        if (cameraObject != null)
        {
            mainCamera = cameraObject.GetComponent<Camera>();
        }

        GameObject cameraObject2 = GameObject.FindGameObjectWithTag("SCamera");
        if (cameraObject2 != null)
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
            Debug.Log("Display 2 Active: " + Display.displays[1].active);
        }
    }

    void Update()
    {
        // プレイヤー1とプレイヤー2のTagを使って範囲内にいるかを確認
        GameObject player1Object = GameObject.FindGameObjectWithTag(player1Tag);
        GameObject player2Object = GameObject.FindGameObjectWithTag(player2Tag);

        bool isPlayer1InRange = IsPlayerInRange(player1Object);
        bool isPlayer2InRange = IsPlayerInRange(player2Object);

        // プレイヤー1が範囲内にいて対応ボタンが押された場合
        if (isPlayer1InRange && Input.GetButtonDown("Y_Button_1P"))
        {
            ToggleImage(imageObjectPlayer1, ref isPlayer1ImageVisible);
            if (mainCamera != null)
            {
                mainCamera.targetDisplay = 0; // Player 1の画像をDisplay 1に表示
            }
        }
        // プレイヤー1が範囲外に出た場合、画像を非表示にする
        else if (!isPlayer1InRange && isPlayer1ImageVisible)
        {
            ToggleImage(imageObjectPlayer1, ref isPlayer1ImageVisible); // 非表示にする
        }

        // プレイヤー2が範囲内にいて対応ボタンが押された場合
        if (isPlayer2InRange && Input.GetButtonDown("Y_Button_2P"))
        {
            ToggleImage(imageObjectPlayer2, ref isPlayer2ImageVisible);
            if (secondCamera != null)
            {
                StartCoroutine(SwitchToSecondDisplay());
            }
        }
        // プレイヤー2が範囲外に出た場合、画像を非表示にする
        else if (!isPlayer2InRange && isPlayer2ImageVisible)
        {
            ToggleImage(imageObjectPlayer2, ref isPlayer2ImageVisible); // 非表示にする
        }
    }

    // 指定されたプレイヤーが範囲内にいるか判定する
    private bool IsPlayerInRange(GameObject playerObject)
    {
        if (playerObject == null || rangeCollider == null) return false;

        // プレイヤーの位置を取得して範囲内かをチェック
        bool isInRange = rangeCollider.bounds.Contains(playerObject.transform.position);
        Debug.Log($"Player {playerObject.name} is in range: {isInRange}");
        return isInRange;
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
        if (rangeObject != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(rangeObject.transform.position, rangeObject.transform.localScale);
        }
    }

    // 1フレーム遅延してDisplay 2に切り替えるコルーチン
    private IEnumerator SwitchToSecondDisplay()
    {
        yield return null; // 1フレーム遅延
        secondCamera.targetDisplay = 1; // Display 2にカメラを設定
        Debug.Log("Display 2に切り替え完了");
    }
}
