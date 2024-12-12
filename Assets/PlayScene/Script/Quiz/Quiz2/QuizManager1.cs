using UnityEngine;

public class QuizManager1 : MonoBehaviour
{
    public static QuizManager1 Instance;  // Singletonインスタンス

    [System.Serializable]
    public class QuestionAnswerPair
    {
        public int questionNumber;       // 問題番号
        public GameObject questionObject;  // 問題オブジェクト（例えば3DオブジェクトやUI）
        public string correctAnswer1Tag;    // 正解のアイテムのタグ（文字列で設定）
    }

    public QuestionAnswerPair[] questionAnswerPairs;  // 問題と解答のペアの配列

    private QuestionAnswerPair currentQuestion;  // 現在の問題と正解のペア
    private RangeChecker1 rangeChecker;  // RangeCheckerの参照

    public int randomIndex;

    void Awake()
    {
        // Singletonの初期化
        if (Instance == null)
        {
            Instance = this;
        }

        // RangeCheckerの参照をAwakeで取得
        rangeChecker= FindObjectOfType<RangeChecker1>();
    }

    void Start()
    {
        // ランダムな問題を設定
        SetRandomQuestion1();

        // ランダムな問題番号を決定してRangeCheckerに送信
        Debug.Log("今の数字(2)は→" + randomIndex);

        // プレイヤー1とプレイヤー2に異なる画像を渡す
        rangeChecker.SetCurrentQuestionObject1(1, rangeChecker.imageObjectsPlayer1[randomIndex]);  // プレイヤー1に選ばれた画像を送信
        rangeChecker.SetCurrentQuestionObject1(2, rangeChecker.imageObjectsPlayer2[randomIndex]);  // プレイヤー2に選ばれた画像を送信

    }

    // ランダムな問題を選んで設定する
    public void SetRandomQuestion1()
    {
        randomIndex = Random.Range(0, questionAnswerPairs.Length);
        currentQuestion = questionAnswerPairs[randomIndex];  // 選んだ問題を設定

        // 問題をログに表示（デバッグ用）
        Debug.Log($"QuizManager(2)の現在の問題は: {currentQuestion.questionObject.name}");
        Debug.Log($"QuizManager(2)の正解タグは: {currentQuestion.correctAnswer1Tag}");
        Debug.Log($"QuizManager(2)の問題番号は: {currentQuestion.questionNumber}");
    }

    // 解答をチェックするメソッド
    public bool CheckAnswer1(string itemTag)
    {
        // アイテムのタグが正解のタグと一致するかを確認
        if (itemTag == currentQuestion.correctAnswer1Tag)
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
    public QuestionAnswerPair GetCurrentQuestion1()
    {
        return currentQuestion;
    }
}
