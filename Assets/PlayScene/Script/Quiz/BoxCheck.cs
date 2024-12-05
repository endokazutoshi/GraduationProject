using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    private QuizManager quizManager;

    public GameObject targetObject;
    public GameObject targetObject2;

    public GameObject targetPlayer;

    public float timerDuration = 2f;  // 操作不能にさせる秒数
    private float currentTime;

    public float forceMultiplier = 10f;  // 吹き飛ばす力の倍率

    private Vector2 targetPosition;
    private bool isBlown = false;  // 吹き飛ばしが開始されたかどうか
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
        if (isBlown)
        {
            // 緩やかに移動するために、Lerpで目的地に向かって移動
            targetPlayer.transform.position = Vector2.Lerp(targetPlayer.transform.position, targetPosition, blowTime * Time.deltaTime);

            // 目的地に到達したら移動を停止
            if (Vector2.Distance(targetPlayer.transform.position, targetPosition) < 0.1f)
            {
                isBlown = false;  // 移動終了
            }

            // 吹き飛ばし時間を進める
            blowTime += Time.deltaTime * speedFactor;  // speedFactorを掛けて速く進行させる
        }

        // タイマーが減少する
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;  // タイマーを減少
            Debug.Log("タイマー残り時間: " + currentTime);  // デバッグログでタイマー残り時間を表示
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
                IncorrectAnswer();
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

    void IncorrectAnswer()
    {
        Debug.Log("IncorrectAnswerを実行します");

        // targetPlayerのPlayerMovementコンポーネントを取得
        PlayerMovement playerMovement = targetPlayer.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            // can_move を 1 に設定して移動を無効化
            playerMovement.can_move = 1;
        }

        // targetPlayerにRigidbody2Dコンポーネントがあるか確認
        Rigidbody2D rb = targetPlayer.GetComponent<Rigidbody2D>();

        // 吹き飛ばし方向と距離を決定
        Vector2 forceDirection = -targetPlayer.transform.right;  // 吹き飛ばし方向
        float blowDistance = 5f;  // 吹き飛ばし距離（ユニット）

        // 最終的な目的地の位置を計算
        targetPosition = rb.position + forceDirection * blowDistance;

        // 吹き飛ばしを開始する
        isBlown = true;
        blowTime = 0f;  // 吹き飛ばしの時間をリセット

        // タイマー開始
        currentTime = timerDuration;  // タイマーを開始
        Debug.Log("タイマー開始: " + currentTime);
    }

    void TimerEnded()
    {
        PlayerMovement playerMovement = targetPlayer.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            // can_move を 0 に設定して移動を再許可
            playerMovement.can_move = 0;
        }

        Debug.Log("タイマー終了。移動が再開されました。");

        // タイマーをリセット
        currentTime = 0;  // タイマーをリセット
    }
}
