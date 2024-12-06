using UnityEngine;

public class RangeChecker : MonoBehaviour
{
    public string player1Tag = "Player1";           // プレイヤー1のTag
    public string player2Tag = "Player2";           // プレイヤー2のTag

    public GameObject rangeObject;                  // 範囲を指定するオブジェクト(Square)
    public GameObject[] imageObjectsPlayer1;        // プレイヤー1用画像の配列
    public GameObject[] imageObjectsPlayer2;        // プレイヤー2用画像の配列

    private Camera mainCamera;                      // プレイヤー1用カメラ
    private Camera secondCamera;                    // プレイヤー2用カメラ

    private Collider2D rangeCollider;               // 範囲オブジェクトのCollider2D

    private GameObject selectedImagePlayer1;        // プレイヤー1用に選ばれた画像
    private GameObject selectedImagePlayer2;        // プレイヤー2用に選ばれた画像


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
        HideAllImages(imageObjectsPlayer1);
        HideAllImages(imageObjectsPlayer2);

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

        // プレイヤー1とプレイヤー2の画像表示を統一したメソッドで処理
        HandlePlayerImageDisplay(player1Object, isPlayer1InRange, selectedImagePlayer1, ref mainCamera, 0, "Y_Button_1P");
        HandlePlayerImageDisplay(player2Object, isPlayer2InRange, selectedImagePlayer2, ref secondCamera, 1, "Y_Button_2P");
    }

    // 現在選ばれている問題番号に基づいて画像を更新する
    public void SetCurrentQuestionObject(int player, GameObject questionObject)
    {
<<<<<<< HEAD
<<<<<<< HEAD
        // プレイヤーが存在しない場合は処理を中止
        if (playerObject == null) return;

        // 範囲内でボタンが押された場合
        if (isPlayerInRange && Input.GetButtonDown(buttonName)) // 指定されたボタンが押された場合
=======
        if (player == 1)
        {
            // プレイヤー1用の選ばれた画像をセット
            selectedImagePlayer1 = questionObject;
            Debug.Log($"プレイヤー1の選ばれた画像: {selectedImagePlayer1.name}");
        }
        else if (player == 2)
        {
            // プレイヤー2用の選ばれた画像をセット
            selectedImagePlayer2 = questionObject;
            Debug.Log($"プレイヤー2の選ばれた画像: {selectedImagePlayer2.name}");
        }
        else
        {
            Debug.LogError("無効なプレイヤー番号です。");
        }
    }

    // プレイヤーごとの画像表示処理
    private void HandlePlayerImageDisplay(GameObject playerObject, bool isPlayerInRange, GameObject selectedImage, ref Camera camera, int displayIndex, string buttonName)
    {
        if (playerObject == null || selectedImage == null) return;

        bool isImageVisible = selectedImage.activeSelf;

        // プレイヤーが範囲内にいて対応ボタンが押された場合
        if (isPlayerInRange && Input.GetButtonDown(buttonName))
>>>>>>> origin/kudo
=======
        if (player == 1)
>>>>>>> parent of a6c76c3 (菫ｮ豁｣荳ｭ)
        {
            // プレイヤー1用の選ばれた画像をセット
            selectedImagePlayer1 = questionObject;
            Debug.Log($"プレイヤー1の選ばれた画像: {selectedImagePlayer1.name}");
        }
        else if (player == 2)
        {
            // プレイヤー2用の選ばれた画像をセット
            selectedImagePlayer2 = questionObject;
            Debug.Log($"プレイヤー2の選ばれた画像: {selectedImagePlayer2.name}");
        }
        else
        {
            Debug.LogError("無効なプレイヤー番号です。");
        }　

        // 画像を非表示に設定
        HideAllImages(imageObjectsPlayer1);
        HideAllImages(imageObjectsPlayer2);
    }

    // プレイヤーごとの画像表示処理
    private void HandlePlayerImageDisplay(GameObject playerObject, bool isPlayerInRange, GameObject selectedImage, ref Camera camera, int displayIndex, string buttonName)
    {
        if (playerObject == null || selectedImage == null) return;

        bool isImageVisible = selectedImage.activeSelf;

        // プレイヤーが範囲内にいて対応ボタンが押された場合
        if (isPlayerInRange && Input.GetButtonDown(buttonName))
        {
            ToggleImage(selectedImage, ref isImageVisible);
            if (camera != null)
            {
                camera.targetDisplay = displayIndex; // 対応するディスプレイに切り替え
            }
        }
        // プレイヤーが範囲外に出た場合、画像を非表示にする
        else if (!isPlayerInRange && isImageVisible)
        {
            HideAllImages(new GameObject[] { selectedImage });
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

    // すべての画像を非表示にする
    private void HideAllImages(GameObject[] imageObjects)
    {
        foreach (var imageObject in imageObjects)
        {
            if (imageObject != null)
            {
                imageObject.SetActive(false);
            }
        }
    }
}
