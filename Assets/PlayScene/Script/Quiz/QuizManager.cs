using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;  // Singletonインスタンス

    [System.Serializable]
    public class QuestionAnswerPair
    {
        public int questionNumber;       // 問題番号
        public GameObject questionObject;  // 問題オブジェクト（例えば3DオブジェクトやUI）
        public string correctAnswerTag;    // 正解のアイテムのタグ（文字列で設定）
    }

    public QuestionAnswerPair[] questionAnswerPairs;  // 問題と解答のペアの配列

    private QuestionAnswerPair currentQuestion;  // 現在の問題と正解のペア
    private RangeChecker rangeChecker;  // RangeCheckerの参照

    public int randomIndex;

    void Awake()
    {
        // Singletonの初期化
        if (Instance == null)
        {
            Instance = this;
        }

        // RangeCheckerの参照をAwakeで取得
        rangeChecker = FindObjectOfType<RangeChecker>();
    }

    void Start()
    {
        // ランダムな問題を設定
        SetRandomQuestion();

        // ランダムな問題番号を決定してRangeCheckerに送信
        Debug.Log("今の数字は→" + randomIndex);

        // ランダムに選ばれたquestionObjectをRangeCheckerに渡す
        rangeChecker.SetCurrentQuestionObject(1, questionAnswerPairs[randomIndex].questionObject);  // プレイヤー1に選ばれた問題オブジェクトを送信
        rangeChecker.SetCurrentQuestionObject(2, questionAnswerPairs[randomIndex].questionObject);
    }

    // ランダムな問題を選んで設定する
    public void SetRandomQuestion()
    {
        randomIndex = Random.Range(0, questionAnswerPairs.Length);
        currentQuestion = questionAnswerPairs[randomIndex];  // 選んだ問題を設定

        // 問題をログに表示（デバッグ用）
        Debug.Log($"QuizManagerの現在の問題は: {currentQuestion.questionObject.name}");
        Debug.Log($"QuizManagerの正解タグは: {currentQuestion.correctAnswerTag}");
        Debug.Log($"QuizManagerの問題番号は: {currentQuestion.questionNumber}");
    }

    // 解答をチェックするメソッド
    public bool CheckAnswer(string itemTag)
    {
        // アイテムのタグが正解のタグと一致するかを確認
        if (itemTag == currentQuestion.correctAnswerTag)
        {
            Debug.Log("正解!");
            return true;  // 正解
        }
        else
        {
            Debug.Log("不正解!");
            return false;  // 不正解
        }
    }

    // 現在の問題を返す
    public QuestionAnswerPair GetCurrentQuestion()
    {
        return currentQuestion;
    }
}
