using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;  // Singletonインスタンス

    [System.Serializable]
    public class QuestionAnswerPair
    {
        public GameObject questionObject;  // 問題オブジェクト
        public string correctAnswerTag;    // 正解のアイテムのタグ（文字列で設定）
    }

    public QuestionAnswerPair[] questionAnswerPairs;  // 問題と解答のペアの配列

    private QuestionAnswerPair currentQuestion;  // 現在の問題と正解のペア

    public RangeChecker rangeChecker;  // RangeChecker スクリプトを参照

    void Awake()
    {
        // Singletonの初期化
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        // 初期化でランダムな問題を設定
        if (rangeChecker != null)
        {
            rangeChecker.SetRandomQuestion();  // RangeCheckerにランダムな問題設定
        }
    }

    // 現在の問題を返す
    public QuestionAnswerPair GetCurrentQuestion()
    {
        return currentQuestion;
    }

    // 現在の問題をRangeCheckerから設定
    public void SetCurrentQuestionFromRangeChecker(GameObject question, string correctAnswerTag)
    {
        currentQuestion = new QuestionAnswerPair
        {
            questionObject = question,
            correctAnswerTag = correctAnswerTag
        };

        Debug.Log("現在の問題: " + currentQuestion.questionObject.name);
        Debug.Log("正解タグ: " + currentQuestion.correctAnswerTag);
    }
}
