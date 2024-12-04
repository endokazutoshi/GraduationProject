using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    public PlayerMovement PlayerMovement; // PlayerMovementの参照
    private QuizManager quizManager;

    public GameObject targetObject;
    public GameObject targetObject2;

    public GameObject targetPlayer;

    public float timerDuration = 3f;  // 3秒
    private float currentTime;

    public float forceMultiplier = 10f;  // 吹き飛ばす力の倍率

    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
        targetObject.SetActive(false);
        targetObject2.SetActive(false);
        currentTime = timerDuration;  // タイマーの初期化
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

        // targetPlayerにRigidbody2Dコンポーネントがあるか確認
        Rigidbody2D rb = targetPlayer.GetComponent<Rigidbody2D>();

        // タイマーが0以上の場合にカウントダウンを実行
        if (currentTime > 0)
        {
            Debug.Log("タイマー起動");
            currentTime -= Time.deltaTime;  // 毎フレーム経過時間を減算

            // 移動を無効化する処理
            PlayerMovement.can_move = 1; // ここで移動を無効化

            if (rb != null)
            {
                // 吹き飛ばす方向を指定（ここでは対象の右方向に力を加える）
                Vector2 forceDirection = -targetPlayer.transform.right;  // 2Dの場合はrightを使用

                // 吹き飛ばす力を加える
                rb.AddForce(forceDirection * forceMultiplier, ForceMode2D.Impulse); // 2Dでの力の加え方
            }
            else
            {
                Debug.LogWarning("指定されたオブジェクトにRigidbody2Dコンポーネントがありません！");
            }
        }
        else
        {
            // タイマーが0になった時の処理
            TimerEnded();
        }
    }

    void TimerEnded()
    {
        PlayerMovement.can_move = 0;  // タイマー終了後、移動を許可
        Debug.Log("タイマー終了。移動が再開されました。");
    }
}
