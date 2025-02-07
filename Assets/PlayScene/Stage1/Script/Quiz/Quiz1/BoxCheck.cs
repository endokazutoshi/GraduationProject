using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class BoxCheck : MonoBehaviour
{
    private QuizManager quizManager;

    public GameObject targetObject;
    public GameObject targetObject2;

    public GameObject openUI1;
    public GameObject openUI2;

    public GameObject targetPlayer1;  // プレイヤー1
    public GameObject targetPlayer2;  // プレイヤー2

    public float timerDuration = 2f;  // 操作不能にさせる秒数
    private float currentTime;

    public float forceMultiplier = 10f;  // 吹き飛ばす力の倍率

    private Vector2 targetPosition1;  // プレイヤー1の最終目的地
    private bool isBlown1 = false;  // プレイヤー1が吹き飛ばされたかどうか

    private Vector2 targetPosition2;  // プレイヤー2の最終目的地
    private bool isBlown2 = false;  // プレイヤー2が吹き飛ばされたかどうか

    private float blowTime = 0f;    // 吹き飛ばしにかかる時間
    float speedFactor = 20f;  // 速さを倍にする（調整可能）
    bool canPlayer1 = false; // プレイヤーが触れているかの確認
    bool canPlayer2 = false; // プレイヤーが触れているかの確認

    public GameObject player1Text;  // プレイヤー1用
    public GameObject player2Text;  // プレイヤー2用
    public float textDisplayDuration = 2f;  // テキストを表示する時間

    private Camera mainCamera;                      // プレイヤー1用カメラ
    private Camera secondCamera;                    // プレイヤー2用カメラ

    public AudioSource correctAudioSource;
    public AudioSource incorrectAudioSource;

    public AudioClip correctSound;
    public AudioClip incorrectSound;

    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
        targetObject.SetActive(false);
        targetObject2.SetActive(false);
        openUI1.SetActive(false);
        openUI2.SetActive(false);
        currentTime = 0f;  // 初期化時にタイマーは0に設定しておく
        // 初期状態ではテキストを非表示にしておく
        if (player1Text != null) player1Text.SetActive(false);
        if (player2Text != null) player2Text.SetActive(false);

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

        // Display 1,2を有効化

        // Display 2を有効

        if (Display.displays.Length > 0)
        {
            Display.displays[0].Activate(); // Display1
            Debug.Log("Display 1 Active: " + Display.displays[0].active);
        }
        if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate(); // Display2
            Debug.Log("Display 2 Active: " + Display.displays[1].active);
        }
        // UIのカメラ設定
        //SetUIForDisplay();
        Debug.Log("Display 0 active: " + Display.displays[0].active);
        Debug.Log("Display 1 active: " + Display.displays[1].active);

        if(correctAudioSource == null || incorrectAudioSource == null)
        {
            Debug.Log("正解音、不正解音のどちらか又は両方が割り当てられていません");
        }


    }

    void Update()
    {
        // 吹き飛ばし処理
        if (isBlown1)
        {
            targetPlayer1.transform.position = Vector2.Lerp(targetPlayer1.transform.position, targetPosition1, blowTime * Time.deltaTime);
            if (Vector2.Distance(targetPlayer1.transform.position, targetPosition1) < 0.1f)
            {
                isBlown1 = false;  // プレイヤー1の吹き飛ばしが終了
            }
        }

        if (isBlown2)
        {
            targetPlayer2.transform.position = Vector2.Lerp(targetPlayer2.transform.position, targetPosition2, blowTime * Time.deltaTime);
            if (Vector2.Distance(targetPlayer2.transform.position, targetPosition2) < 0.1f)
            {
                isBlown2 = false;  // プレイヤー2の吹き飛ばしが終了
            }
        }

        // 吹き飛ばし時間を進める
        blowTime += Time.deltaTime * speedFactor;

        // タイマーが減少する
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else if (currentTime <= 0)
        {
            TimerEnded();  // タイマーが0になったら、TimerEndedを呼び出す
        }
    }

    public void CheckItem(GameObject item)
    {
        // 現在の問題を取得
        QuizManager.QuestionAnswerPair currentQuestion = quizManager.GetCurrentQuestion();

        if (currentQuestion != null)
        {
            // 現在の問題の正解タグを取得
            string correctAnswerTag = currentQuestion.correctAnswerTag;

            // 正解かどうかをチェック
            if (item.CompareTag(correctAnswerTag))
            {
                Debug.Log("正解です！");
                CorrectAnswer();
            }
            else
            {
                Debug.Log("不正解です！");

                // Bボタンが押されていて、かつ触れている場合に判定
                if (canPlayer1 && Input.GetButtonDown("Y_Button_1P"))
                {
                    Debug.Log("Player 1's Bボタンが押されました！");
                    IncorrectAnswer("Player1");
                }
                if (canPlayer2 && Input.GetButtonDown("Y_Button_2P"))
                {
                    Debug.Log("Player 2's Bボタンが押されました！");
                    IncorrectAnswer("Player2");
                }
            }
        }
        else
        {
            Debug.LogError("現在の問題がありません");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤー1のタグを確認
        if (other.CompareTag("Player1"))
        {
            canPlayer1 = true;  // プレイヤーが触れたらBボタンが効くようにする
            Debug.Log("プレイヤー1がオブジェクトに触れました！");
            player1Text.SetActive(true);
        }
        if (other.CompareTag("Player2"))
        {
            canPlayer2 = true;  // プレイヤーが触れたらBボタンが効くようにする
            Debug.Log("プレイヤー2がオブジェクトに触れました！");
            player2Text.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // プレイヤー1のタグを確認
        if (other.CompareTag("Player1"))
        {
            canPlayer1 = false;  // プレイヤーが触れたらBボタンが効くようにする
            Debug.Log("プレイヤー1がオブジェクトから離れました！");
            player1Text.SetActive(false);
        }
        if (other.CompareTag("Player2"))
        {
            canPlayer2 = false;  // プレイヤーが触れたらBボタンが効くようにする
            Debug.Log("プレイヤー2がオブジェクトから離れました！");
            player2Text.SetActive(false);
        }
    }

    // UI表示後に3秒で消すためのコルーチン
    IEnumerator HideUIAfterDelay()
    {
        // 3秒待つ
        yield return new WaitForSeconds(3f);

        // UIを非表示にする
        openUI1.SetActive(false);
        openUI2.SetActive(false);

    }

    void CorrectAnswer()
    {

        if (correctAudioSource != null && correctSound != null)
        {
            correctAudioSource.PlayOneShot(correctSound);
        }
        targetObject.SetActive(true);
        targetObject2.SetActive(true);
        openUI1.SetActive(true);
        openUI2.SetActive(true);
        Debug.Log("openUI1 active: " + openUI1.activeSelf);
        Debug.Log("openUI2 active: " + openUI2.activeSelf);


        // コルーチンを開始して3秒後にUIを消す
        StartCoroutine(HideUIAfterDelay());
    }

    void IncorrectAnswer(string playerTag)
    {
        Debug.Log("IncorrectAnswerを実行します");

        // 各プレイヤーのPlayerMovementコンポーネントを取得
        PlayerMovement playerMovement1 = targetPlayer1.GetComponent<PlayerMovement>();
        PlayerMovement playerMovement2 = targetPlayer2.GetComponent<PlayerMovement>();

        if (playerTag == "Player1" && playerMovement1 != null)
        {
            Debug.Log("プレイヤー１が吹き飛びます");
            // プレイヤー1が不正解なら移動を無効化
            playerMovement1.can_move1 = 1;
            isBlown1 = true;

            // 吹き飛ばし方向と距離を決定
            Vector2 forceDirection1 = -targetPlayer1.transform.right;  // プレイヤー1の吹き飛ばし方向
            float blowDistance = 5f;  // 吹き飛ばし距離（ユニット）
            targetPosition1 = (Vector2)targetPlayer1.transform.position + forceDirection1 * blowDistance;
        }
        if (playerTag == "Player2" && playerMovement2 != null)
        {
            Debug.Log("プレイヤー2が吹き飛びます");
            // プレイヤー2が不正解なら移動を無効化
            playerMovement2.can_move1 = 1;
            isBlown2 = true;

            // 吹き飛ばし方向と距離を決定
            Vector2 forceDirection2 = -targetPlayer2.transform.right;  // プレイヤー2の吹き飛ばし方向
            float blowDistance = 5f;  // 吹き飛ばし距離（ユニット）
            targetPosition2 = (Vector2)targetPlayer2.transform.position + forceDirection2 * blowDistance;
        }

        if (incorrectAudioSource != null && incorrectSound != null)
        {
            incorrectAudioSource.PlayOneShot(incorrectSound);
        }

        blowTime = 0f;  // 吹き飛ばしの時間をリセット
        currentTime = timerDuration;  // タイマーを開始
        Debug.Log("タイマー開始: " + currentTime);
    }
    //void SetUIForDisplay()
    //{
    //    // openUI1のCanvas設定
    //    if (openUI1 != null)
    //    {
    //        Canvas canvas1 = openUI1.GetComponent<Canvas>();
    //        if (canvas1 != null)
    //        {
    //            canvas1.renderMode = RenderMode.ScreenSpaceCamera;
    //            canvas1.worldCamera = mainCamera;  // Display 1 用カメラを設定
    //            canvas1.targetDisplay = 0;  // Display 1に表示
    //            Debug.Log("Canvas 1 targetDisplay: " + canvas1.targetDisplay);

    //        }
    //    }

    //    // openUI2のCanvas設定
    //    if (openUI2 != null)
    //    {
    //        Canvas canvas2 = openUI2.GetComponent<Canvas>();
    //        if (canvas2 != null)
    //        {
    //            canvas2.renderMode = RenderMode.ScreenSpaceCamera;
    //            canvas2.worldCamera = secondCamera;  // Display 2 用カメラを設定
    //            canvas2.targetDisplay = 1;  // Display 2に表示
    //            Debug.Log("Canvas 2 targetDisplay: " + canvas2.targetDisplay);

    //        }
    //    }
       

    //}



    void TimerEnded()
    {
        PlayerMovement playerMovement1 = targetPlayer1.GetComponent<PlayerMovement>();
        PlayerMovement playerMovement2 = targetPlayer2.GetComponent<PlayerMovement>();

        if (playerMovement1 != null)
        {
            playerMovement1.can_move1 = 0;
        }
        if (playerMovement2 != null)
        {
            playerMovement2.can_move1 = 0;
        }

        Debug.Log("タイマー終了。移動が再開されました。");

        // タイマーをリセット
        currentTime = 0;  // タイマーをリセット
    }
}
