using UnityEngine;

public class ResultSceneManager : MonoBehaviour
{
    public GameObject[] stageBackgroundObjects;  // ステージに対応する背景オブジェクトを格納

    void Start()
    {
        // PlayerPrefsからステージ情報を取得
        int stage = PlayerPrefs.GetInt("Stage", 1);  // デフォルトでStage1（1）に設定

        // ステージに応じて背景オブジェクトを表示、その他を非表示にする
        for (int i = 0; i < stageBackgroundObjects.Length; i++)
        {
            if (i == stage - 1)  // 選ばれたステージのインデックスと一致する場合
            {
                stageBackgroundObjects[i].SetActive(true);  // 背景を表示
            }
            else
            {
                stageBackgroundObjects[i].SetActive(false);  // 他の背景を非表示
            }
        }
    }
}
