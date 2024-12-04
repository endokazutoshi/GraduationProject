using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class QuestionAnswerPair
    {
        public GameObject questionObject;  // 問題オブジェクト（3DオブジェクトやUIエレメントなど）
        public string correctAnswerTag;    // 正解のアイテムのタグ（文字列で設定）
    }

    public QuestionAnswerPair[] questionAnswerPairs;  // 問題と解答のペアの配列

    private QuestionAnswerPair currentQuestion;  // 現在の問題と正解のペア

    void Start()
    {
        GenerateRandomQuestion();  // ランダムな問題を生成
    }

    // ランダムに問題を選択する
    void GenerateRandomQuestion()
    {
        int randomIndex = Random.Range(0, questionAnswerPairs.Length);
        currentQuestion = questionAnswerPairs[randomIndex];  // ランダムな問題と解答を取得

        // 他の問題オブジェクトを非表示にする（前の問題を隠す）
        foreach (var pair in questionAnswerPairs)
        {
            if (pair.questionObject != null)
            {
                pair.questionObject.SetActive(false);  // すべての問題オブジェクトを非表示
            }
        }

        // 現在選ばれた問題オブジェクトを表示
        if (currentQuestion.questionObject != null)
        {
            Debug.Log("問題: " + currentQuestion.questionObject.name);
            currentQuestion.questionObject.SetActive(true);  // オブジェクトをシーンに表示
        }
    }

    // 現在の問題を返すメソッド
    public QuestionAnswerPair GetCurrentQuestion()
    {
        return currentQuestion;
    }

    // Unityエディタ用にタグ選択機能を追加（Custom Editorなどで使う）
    public string[] GetAllTags()
    {
        return UnityEditorInternal.InternalEditorUtility.tags;  // Unityのタグを取得
    }
}
