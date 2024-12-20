using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;  // IEnumeratorを使用するために必要

public class SceneManagerController : MonoBehaviour
{
    public StageSelectController stageSelectController;  // StageSelectControllerへの参照
    public GameObject selectSceneUI;  // SelectSceneのUIオブジェクト（親オブジェクト）

    void Update()
    {
        // Aボタンが押されたら、現在のインデックスに基づいてシーンを移動
        if (Input.GetButtonDown("Jump_P1"))
        {
            // シーン遷移前にSelectSceneのUIを非アクティブにする
            if (selectSceneUI != null)
            {
                selectSceneUI.SetActive(false);  // SelectSceneのUIを非表示にする
            }

            // 現在のインデックスに基づいてシーンを遷移
            switch (stageSelectController.currentMapIndex)
            {
                case 0:
                    // インデックスが0の場合、ステージ1に移動
                    StartCoroutine(LoadSceneAsync("PlayScene"));
                    break;

                case 1:
                    // インデックスが1の場合、ステージ2に移動
                    StartCoroutine(LoadSceneAsync("Stage2"));
                    break;

                case 2:
                    // インデックスが2の場合、ステージ3に移動
                    StartCoroutine(LoadSceneAsync("Stage3"));
                    break;

                default:
                    // それ以外の場合、ステージ1に移動
                    StartCoroutine(LoadSceneAsync("Stage1"));
                    break;
            }
        }
    }

    // 非同期でシーンをロードし、完了後に処理を行う
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // シーンを非同期で読み込む
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // シーンが完全に読み込まれるまで待機
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // シーンがロードされた後にUIを非表示にする
        if (selectSceneUI != null)
        {
            selectSceneUI.SetActive(false);
        }
    }
}
