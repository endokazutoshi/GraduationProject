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

    void Awake()
    {
        // Singletonの初期化
        if (Instance == null)
        {
            Instance = this;
        }

        // RangeCheckerの参照をAwakeで取得
        rangeChecker = FindObjectOfType<RangeChecker>();
        if (rangeChecker == null)
        {
            Debug.LogError("RangeCheckerが見つかりません。Hierarchyに追加してください。");
        }
    }

    void Start()
    {
        // 初期化時に最初の問題を設定する
        SetQuestion(0);  // ここでは問題番号0を最初の問題として設定しています

        // 現在の問題オブジェクトをアクティブ化
        ActivateCurrentQuestionObject();
    }

    // 指定した問題番号で問題を設定する
    public void SetQuestion(int questionNumber)
    {
        // 指定した問題番号に該当する問題を検索
        foreach (var pair in questionAnswerPairs)
        {
            if (pair.questionNumber == questionNumber)
            {
                currentQuestion = pair;
                Debug.Log($"QuizManagerの現在の問題は: {currentQuestion.questionObject.name}");
                Debug.Log($"QuizManagerの正解タグは: {currentQuestion.correctAnswerTag}");
                Debug.Log($"QuizManagerの問題番号は: {currentQuestion.questionNumber}");
                return;
            }
        }

        // 該当する問題が見つからない場合
        Debug.LogError($"問題番号 {questionNumber} が見つかりませんでした。");
    }

    // 現在の問題オブジェクトをアクティブ化
    private void ActivateCurrentQuestionObject()
    {
        // すべての問題オブジェクトを非アクティブ化
        foreach (var pair in questionAnswerPairs)
        {
            if (pair.questionObject != null)
            {
                pair.questionObject.SetActive(false);
            }
        }

        // 現在の問題オブジェクトをアクティブ化
        if (currentQuestion != null && currentQuestion.questionObject != null)
        {
            currentQuestion.questionObject.SetActive(false);
        }
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

    // 現在の問題を返すメソッド
    public QuestionAnswerPair GetCurrentQuestion()
    {
        return currentQuestion;
    }

    // 現在の問題番号を返すメソッド
    public int GetCurrentQuestionNumber()
    {
        if (currentQuestion != null)
        {
            return currentQuestion.questionNumber;
        }
        else
        {
            Debug.LogError("現在の問題が設定されていません。");
            return -1;  // 問題が設定されていない場合は-1を返す
        }
    }
}
