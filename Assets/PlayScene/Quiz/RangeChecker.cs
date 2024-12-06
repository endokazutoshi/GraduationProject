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
        // rangeObjectが設定されているか確認し、Collider2Dを取得
        if (rangeObject != null)
        {
            rangeCollider = rangeObject.GetComponent<Collider2D>(); // Collider2Dを取得
            if (rangeCollider == null)
            {
                Debug.LogError("範囲オブジェクトにCollider2Dが設定されていません。"); // Collider2Dが設定されていない場合にエラー表示
            }
        }
        else
        {
            Debug.LogError("範囲オブジェクトが設定されていません。"); // rangeObjectが設定されていない場合にエラー表示
        }

        // タグでカメラを探して設定
        GameObject cameraObject = GameObject.FindGameObjectWithTag("MCamera"); // "MCamera"というタグのついたオブジェクトを検索
        if (cameraObject != null)
        {
            mainCamera = cameraObject.GetComponent<Camera>(); // 見つかったカメラオブジェクトのCameraコンポーネントを取得
        }

        GameObject cameraObject2 = GameObject.FindGameObjectWithTag("SCamera"); // "SCamera"というタグのついたオブジェクトを検索
        if (cameraObject2 != null)
        {
            secondCamera = cameraObject2.GetComponent<Camera>(); // 見つかったカメラオブジェクトのCameraコンポーネントを取得
        }

        // 画像を非表示に設定
        HideAllImages(imageObjectsPlayer1); // プレイヤー1の画像をすべて非表示
        HideAllImages(imageObjectsPlayer2); // プレイヤー2の画像をすべて非表示

        // 2つ目のディスプレイが存在する場合、ディスプレイを有効化
        if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate(); // 2番目のディスプレイを有効化
            Debug.Log("Display 2 Active: " + Display.displays[1].active); // ディスプレイが有効かどうかを表示
        }
    }

    void Update()
    {
        // プレイヤー1の範囲内チェックと処理
        GameObject player1Object = GameObject.FindGameObjectWithTag(player1Tag); // プレイヤー1をタグで検索
        bool isPlayer1InRange = IsPlayerInRange(player1Object); // プレイヤー1が範囲内にいるか判定
        ProcessPlayerInput(
            player1Object, // プレイヤー1のオブジェクト
            ref selectedImagePlayer1, // プレイヤー1の選ばれた画像
            imageObjectsPlayer1, // プレイヤー1の画像配列
            ref mainCamera, // プレイヤー1用カメラ
            0, // プレイヤー1用のディスプレイインデックス
            "Y_Button_1P", // プレイヤー1用のボタン名
            isPlayer1InRange // プレイヤー1が範囲内にいるかの情報
        );

        // プレイヤー2の範囲内チェックと処理
        GameObject player2Object = GameObject.FindGameObjectWithTag(player2Tag); // プレイヤー2をタグで検索
        bool isPlayer2InRange = IsPlayerInRange(player2Object); // プレイヤー2が範囲内にいるか判定
        ProcessPlayerInput(
            player2Object, // プレイヤー2のオブジェクト
            ref selectedImagePlayer2, // プレイヤー2の選ばれた画像
            imageObjectsPlayer2, // プレイヤー2の画像配列
            ref secondCamera, // プレイヤー2用カメラ
            1, // プレイヤー2用のディスプレイインデックス
            "Y_Button_2P", // プレイヤー2用のボタン名
            isPlayer2InRange // プレイヤー2が範囲内にいるかの情報
        );
    }

    // プレイヤー入力を処理するメソッド
    private void ProcessPlayerInput(
        GameObject playerObject, // プレイヤーのオブジェクト
        ref GameObject selectedImage, // 選ばれた画像
        GameObject[] imageObjects, // 画像配列
        ref Camera camera, // カメラ
        int displayIndex, // ディスプレイインデックス
        string buttonName, // ボタン名
        bool isPlayerInRange // プレイヤーが範囲内にいるか
    )
    {
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
        {
            Debug.Log($"{playerObject.name} が範囲内で {buttonName} を押しました。");

            // 画像をランダムで選択して表示
            // 画像をランダムで選択して表示
            if (selectedImage == null)
            {
                selectedImage = GetRandomImage(imageObjects); // まだ画像が選ばれていなければランダムに選択
            }

            if (selectedImage != null)
            {
                // QuizManagerの問題配列からランダムに問題番号を選ぶ
                int randomQuestionIndex = Random.Range(0, QuizManager.Instance.questionAnswerPairs.Length);  // ランダムなインデックスを取得
                int questionNumber = QuizManager.Instance.questionAnswerPairs[randomQuestionIndex].questionNumber;  // ランダムな問題番号を取得

                // QuizManagerに問題番号を渡す
                QuizManager.Instance.SetQuestion(questionNumber);  // QuizManagerのインスタンスを使って問題番号を設定

                bool isImageVisible = selectedImage.activeSelf; // 現在の画像の表示状態を取得
                ToggleImage(selectedImage, ref isImageVisible); // 画像の表示/非表示を切り替え
            }



            // カメラのターゲットディスプレイを設定
            if (camera != null)
            {
                camera.targetDisplay = displayIndex; // 指定されたディスプレイインデックスにカメラを設定
            }
        }
    }

    // プレイヤーが範囲内にいるか確認するメソッド
    private bool IsPlayerInRange(GameObject playerObject)
    {
        if (playerObject == null || rangeCollider == null) return false; // プレイヤーが存在しない、または範囲オブジェクトが設定されていない場合は範囲外

        return rangeCollider.bounds.Contains(playerObject.transform.position); // プレイヤーの位置が範囲内にあるかを確認
    }

    // 画像の表示/非表示を切り替えるメソッド
    private void ToggleImage(GameObject imageObject, ref bool isVisible)
    {
        if (imageObject != null)
        {
            isVisible = !isVisible; // 表示状態を反転
            imageObject.SetActive(isVisible); // 画像の表示/非表示を設定
        }
    }

    // すべての画像を非表示にするメソッド
    private void HideAllImages(GameObject[] imageObjects)
    {
        foreach (var imageObject in imageObjects) // 配列内のすべての画像に対して
        {
            if (imageObject != null)
            {
                imageObject.SetActive(false); // 画像を非表示にする
            }
        }
    }

    // ランダムに非表示の画像を選ぶメソッド
    private GameObject GetRandomImage(GameObject[] imageObjects)
    {
        foreach (var imageObject in imageObjects)
        {
            if (imageObject != null && !imageObject.activeSelf) // 画像が非表示の場合
            {
                return imageObject; // 非表示の画像を返す
            }
        }
        return null; // 非表示の画像がなければnullを返す
    }
}
