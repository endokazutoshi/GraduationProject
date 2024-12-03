using UnityEngine;

public class QuizManager : MonoBehaviour
{
    // 問題に対応する正解アイテム
    public GameObject correctItem;

    // 問題内容（例えばクイズのタイトルや説明）
    public string quizQuestion;

    // 現在の問題が正解かどうかを確認するためにアイテムを渡すメソッド
    public void SetCorrectItem(GameObject item)
    {
        correctItem = item;
    }

    // クイズの問題内容を取得
    public string GetCurrentQuiz()
    {
        return quizQuestion;
    }
}
