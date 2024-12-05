using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    private QuizManager quizManager;

    public GameObject targetObject;
    public GameObject targetObject2;

    public GameObject targetPlayer1;  // プレイヤー1
    public GameObject targetPlayer2;  // プレイヤー2

    public float timerDuration = 2f;  // 操作不能にさせる秒数
    private float currentTime;

    public float forceMultiplier = 10f;  // 吹き飛ばす力の倍率

    private Vector2 targetPosition1;  // プレイヤー1の最終目的地
    private Vector2 targetPosition2;  // プレイヤー2の最終目的地
    private bool isBlown1 = false;  // プレイヤー1が吹き飛ばされたかどうか
    private bool isBlown2 = false;  // プレイヤー2が吹き飛ばされたかどうか
    private float blowTime = 0f;    // 吹き飛ばしにかかる時間
    float speedFactor = 20f;  // 速さを倍にする（調整可能）

    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
        targetObject.SetActive(false);
        targetObject2.SetActive(false);
        currentTime = 0f;  // 初期化時にタイマーは0に設定しておく
    }

    void Update()
    {
        // 吹き飛ばし処理
        if (isBlown1)
        {
            // プレイヤー1を吹き飛ばす
            targetPlayer1.transform.position = Vector2.Lerp(targetPlayer1.transform.position, targetPosition1, blowTime * Time.deltaTime);
            // 目的地に到達したら移動を停止
            if (Vector2.Distance(targetPlayer1.transform.position, targetPosition1) < 0.1f)
            {
                isBlown1 = false;  // プレイヤー1の吹き飛ばしが終了
            }
        }

        if (isBlown2)
        {
            // プレイヤー2を吹き飛ばす
            targetPlayer2.transform.position = Vector2.Lerp(targetPlayer2.transform.position, targetPosition2, blowTime * Time.deltaTime);
            // 目的地に到達したら移動を停止
            if (Vector2.Distance(targetPlayer2.transform.position, targetPosition2) < 0.1f)
            {
                isBlown2 = false;  // プレイヤー2の吹き飛ばしが終了
            }
        }

        // 吹き飛ばし時間を進める
        blowTime += Time.deltaTime * speedFactor;  // speedFactorを掛けて速く進行させる

        // タイマーが減少する
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;  // タイマーを減少
                                            // Debug.Log("タイマー残り時間: " + currentTime);  // デバッグログでタイマー残り時間を表示
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
               
                // targetPlayer1が"Player1"タグを持っているかチェック
                if (targetPlayer1.CompareTag("Player1"))
                {
                    Debug.Log("Player 1 processed");
                    IncorrectAnswer("Player1");
                }

                // targetPlayer2が"Player2"タグを持っているかチェック
                else if (targetPlayer2.CompareTag("Player2"))
                {
                    Debug.Log("Player 2 processed");
                    IncorrectAnswer("Player2");
                }
            }
        }
        else
        {
            Debug.LogError("現在の問題がありません");
        }
    }

    void CorrectAnswer()
    {
        targetObject.SetActive(true);
        targetObject2.SetActive(true);
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
            playerMovement1.can_move = 1;
            isBlown1 = true;

            // 吹き飛ばし方向と距離を決定
            Vector2 forceDirection1 = -targetPlayer1.transform.right;  // プレイヤー1の吹き飛ばし方向
            float blowDistance = 5f;  // 吹き飛ばし距離（ユニット）
            targetPosition1 = (Vector2)targetPlayer1.transform.position + forceDirection1 * blowDistance;
        }

        else if (playerTag == "Player2" && playerMovement2 != null)
        {
            Debug.Log("プレイヤー2が吹き飛びます");
            // プレイヤー2が不正解なら移動を無効化
            playerMovement2.can_move = 1;
            isBlown2 = true;

            // 吹き飛ばし方向と距離を決定
            Vector2 forceDirection2 = -targetPlayer2.transform.right;  // プレイヤー2の吹き飛ばし方向
            float blowDistance = 5f;  // 吹き飛ばし距離（ユニット）
            targetPosition2 = (Vector2)targetPlayer2.transform.position + forceDirection2 * blowDistance;
        }

        blowTime = 0f;  // 吹き飛ばしの時間をリセット

        // タイマー開始
        currentTime = timerDuration;  // タイマーを開始
        Debug.Log("タイマー開始: " + currentTime);
    }


    void TimerEnded()
    {
        PlayerMovement playerMovement1 = targetPlayer1.GetComponent<PlayerMovement>();
        PlayerMovement playerMovement2 = targetPlayer2.GetComponent<PlayerMovement>();

        if (playerMovement1 != null)
        {
            // can_move を 0 に設定して移動を再許可
            playerMovement1.can_move = 0;
        }

        if (playerMovement2 != null)
        {
            // can_move を 0 に設定して移動を再許可
            playerMovement2.can_move = 0;
        }

        Debug.Log("タイマー終了。移動が再開されました。");

        // タイマーをリセット
        currentTime = 0;  // タイマーをリセット
    }
}
