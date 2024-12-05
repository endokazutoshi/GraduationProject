using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheck2 : MonoBehaviour
{
    private QuizManager quizManager;

    public GameObject targetObject;
    public GameObject targetObject2;

    public GameObject targetPlayer2;  // プレイヤー2

    public float timerDuration = 2f;  // 操作不能にさせる秒数
    private float currentTime;

    public float forceMultiplier = 10f;  // 吹き飛ばす力の倍率

    private Vector2 targetPosition2;  // プレイヤー2の最終目的地
    private bool isBlown2 = false;  // プレイヤー2が吹き飛ばされたかどうか

    private float blowTime = 0f;    // 吹き飛ばしにかかる時間
    float speedFactor = 20f;  // 速さを倍にする（調整可能）
    // Start is called before the first frame update
    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
        targetObject.SetActive(false);
        targetObject2.SetActive(false);
        currentTime = 0f;  // 初期化時にタイマーは0に設定しておく
    }

    // Update is called once per frame
    void Update()
    {
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

                
                // targetPlayer2が"Player2"タグを持っているかチェック
                if (targetPlayer2.CompareTag("Player2"))
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
        
        PlayerMovement playerMovement2 = targetPlayer2.GetComponent<PlayerMovement>();

        

        if (playerTag == "Player2" && playerMovement2 != null)
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
       
        PlayerMovement playerMovement2 = targetPlayer2.GetComponent<PlayerMovement>();

       

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


