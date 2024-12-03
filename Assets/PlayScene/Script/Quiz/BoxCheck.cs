using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    private QuizManager quizManager; // QuizManagerを参照

    void Start()
    {
        // QuizManagerを取得
        quizManager = FindObjectOfType<QuizManager>();
    }

    // アイテムをボックスに入れたときに呼ばれるメソッド
    public void CheckItem(GameObject item)
    {
        if (quizManager != null)
        {
            // クイズの正解アイテムと照合
            if (item == quizManager.correctItem)
            {
                Debug.Log("正解のアイテムです！");
            }
            else
            {
                Debug.Log("不正解のアイテムです！");
            }
        }
    }
}
