using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isCorrectItem = false; // このアイテムが正解かどうか

    // アイテムの正解を設定
    public void SetCorrect(bool isCorrect)
    {
        isCorrectItem = isCorrect;
    }
}
