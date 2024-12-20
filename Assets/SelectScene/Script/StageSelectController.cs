using UnityEngine;

public class StageSelectController : MonoBehaviour
{
    public GameObject[] targetObject;  // マップオブジェクトの配列
    public Vector3[] objectScales;     // 各マップのスケール設定配列
    private int currentMapIndex = 0;   // 現在選択されているマップのインデックス

    void Start()
    {
        // 最初に最初のマップを表示
        UpdateMapSelection();
    }

    void Update()
    {
        // D-Pad 左の入力（前のマップに移動）
        if (Input.GetAxis("DpadHorizontal") < 0)  // 左方向の入力を検知
        {
            currentMapIndex--;  // インデックスを減らす
            if (currentMapIndex < 0)
            {
                currentMapIndex = targetObject.Length - 1;  // 循環させる
            }
            UpdateMapSelection();
        }

        // D-Pad 右の入力（次のマップに移動）
        if (Input.GetAxis("DpadHorizontal") > 0)  // 右方向の入力を検知
        {
            currentMapIndex++;  // インデックスを増やす
            if (currentMapIndex >= targetObject.Length)
            {
                currentMapIndex = 0;  // 循環させる
            }
            UpdateMapSelection();
        }
    }

    // 現在選択されているマップを表示し、位置とスケールを変更
    private void UpdateMapSelection()
    {
        // すべてのマップを現在の位置に移動し、スケールを設定
        for (int i = 0; i < targetObject.Length; i++)
        {
            // 各マップオブジェクトの位置を設定
            Vector3 position = new Vector3(-960.05f, 543.5f, 0);  // 初期位置

            // D-Pad左なら位置をずらす
            if (i == currentMapIndex && Input.GetAxis("DpadHorizontal") < 0)
            {
                position = new Vector3(-966.95f, 541.95f, 0);
            }
            // D-Pad右なら位置をずらす
            else if (i == currentMapIndex && Input.GetAxis("DpadHorizontal") > 0)
            {
                position = new Vector3(966.95f, 541.95f, 0);
            }

            targetObject[i].transform.position = position;

            // スケールの設定
            if (i == currentMapIndex)
            {
                // 選択されているマップのスケールを設定
                targetObject[i].transform.localScale = objectScales[i];
            }
        }
    }
}
