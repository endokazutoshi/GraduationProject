using UnityEngine;

public class Question : MonoBehaviour
{
    private QuizManager quizManager;
    private QuizManager.QuestionAnswerPair currentQuestion;

    // ここに正解のタグを格納するためのフィールドを追加
    public string correctItemTag;  // 追加

    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
        currentQuestion = quizManager.GetCurrentQuestion();  // 現在の問題と解答のペアを取得
    }

    /// <summary>
    /// 渡されたアイテムが正解かどうかを判定するメソッド。
    /// </summary>
    /// <param name="item">ボックスに入れられたアイテム</param>
    /// <returns>正解ならtrue、不正解ならfalse</returns>
    public bool CheckAnswer(GameObject item)
    {
        if (item != null)
        {
            // アイテムのレイヤーとタグのデバッグ出力
            Debug.Log("アイテムのレイヤー: " + LayerMask.LayerToName(item.layer));
            Debug.Log("正解のタグ: " + correctItemTag);  // 正解のタグを表示
            Debug.Log("アイテムのタグ: " + item.tag);

            // アイテムが"Item"レイヤーかつ、正解のタグと一致しているか確認
            if (item.layer == LayerMask.NameToLayer("Item") && item.CompareTag(correctItemTag))
            {
                Debug.Log("正解！");
                return true;
            }
            else
            {
                Debug.Log("不正解！");
                return false;
            }
        }
        return false;
    }
}
