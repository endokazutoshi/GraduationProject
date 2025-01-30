using UnityEngine;

public class StageSelectController : MonoBehaviour
{
    public GameObject[] targetObject;  // 表示する画像オブジェクト（例えば、1, 2, 3の画像）
    public GameObject[] targetText;   // 表示するテキストオブジェクト（画像に対応する説明文など）
    public int currentMapIndex = 2;   // 現在選択されている画像のインデックス

    private bool isDpadPressed = false; // D-Padが押されたかどうかのフラグ
    private SceneManagerController sceneManagerController;

    void Start()
    {
        sceneManagerController = FindObjectOfType<SceneManagerController>();
        // 初期状態で最初のマップとテキストのみ表示
        UpdateMapSelection();
        UpdateTextSelection();
    }

    void Update()
    {
        if (sceneManagerController != null && sceneManagerController.IsInputDisabled()) return;
        // D-Pad 左の入力（前の画像に移動）
        if (Input.GetAxisRaw("DpadHorizontal") < 0 && !isDpadPressed)
        {
            currentMapIndex--;  // インデックスを減らす
            if (currentMapIndex < 0)
            {
                currentMapIndex = targetObject.Length - 1;  // 循環させる（最初に戻る）
            }
            UpdateMapSelection();
            UpdateTextSelection();
            isDpadPressed = true; // ボタンが押されたことを記録
        }

        // D-Pad 右の入力（次の画像に移動）
        if (Input.GetAxisRaw("DpadHorizontal") > 0 && !isDpadPressed)
        {
            currentMapIndex++;  // インデックスを増やす
            if (currentMapIndex >= targetObject.Length)
            {
                currentMapIndex = 0;  // 循環させる（最後から最初に戻る）
            }
            UpdateMapSelection();
            UpdateTextSelection();
            isDpadPressed = true; // ボタンが押されたことを記録
        }

        // 入力が離された場合、次のフレームに再度処理をするためにフラグをリセット
        if (Input.GetAxisRaw("DpadHorizontal") == 0)
        {
            isDpadPressed = false;
        }
    }

    // 現在選択されている画像を表示し、他の画像を非表示にする
    private void UpdateMapSelection()
    {
        // Debug.Log("現在のインデックス: " + currentMapIndex); // 現在のインデックスをデバッグで表示

        // すべてのマップオブジェクトを非表示にする
        for (int i = 0; i < targetObject.Length; i++)
        {
            targetObject[i].SetActive(false);
        }

        // 現在選択されているインデックスのマップオブジェクトを表示
        if (currentMapIndex >= 0 && currentMapIndex < targetObject.Length)
        {
            targetObject[currentMapIndex].SetActive(true);
            // Debug.Log("選択されたオブジェクト: " + targetObject[currentMapIndex].name); // 表示されるオブジェクトを確認
        }
        else
        {
            // Debug.LogWarning("インデックスが範囲外: " + currentMapIndex); // 範囲外のインデックスに注意
        }
    }

    // 現在選択されているテキストを表示し、他のテキストを非表示にする
    private void UpdateTextSelection()
    {
        // すべてのテキストオブジェクトを非表示にする
        for (int i = 0; i < targetText.Length; i++)
        {
            targetText[i].SetActive(false);
        }

        // 現在選択されているインデックスのテキストオブジェクトを表示
        if (currentMapIndex >= 0 && currentMapIndex < targetText.Length)
        {
            targetText[currentMapIndex].SetActive(true);
            // Debug.Log("選択されたテキスト: " + targetText[currentMapIndex].name); // 表示されるテキストを確認
        }
        else
        {
            // Debug.LogWarning("テキストのインデックスが範囲外: " + currentMapIndex); // 範囲外のインデックスに注意
        }
    }
}
