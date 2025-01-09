using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManagerController : MonoBehaviour
{
    public StageSelectController stageSelectController;  // StageSelectControllerへの参照
    public GameObject selectSceneUI;  // SelectSceneのUIオブジェクト

    // 準備中と準備OKのテキスト（プレイヤーごとに設定）
    public GameObject[] readyText;  // 準備OKテキスト [0]: Player1, [1]: Player2
    public GameObject[] notReadyText;  // 準備中テキスト [0]: Player1, [1]: Player2

    private bool[] isPlayerReady = new bool[2];  // プレイヤーの準備状態 [0]: Player1, [1]: Player2

    void Start()
    {
        // 初期状態では準備中テキストを表示、準備OKテキストを非表示
        UpdateReadyUI(0, false);
        UpdateReadyUI(1, false);
    }

    void Update()
    {
        // Player1の準備状態を切り替え
        if (Input.GetButtonDown("Jump_P1"))
        {
            isPlayerReady[0] = !isPlayerReady[0];
            UpdateReadyUI(0, isPlayerReady[0]);
        }

        // Player2の準備状態を切り替え
        if (Input.GetButtonDown("Jump_P2"))
        {
            isPlayerReady[1] = !isPlayerReady[1];
            UpdateReadyUI(1, isPlayerReady[1]);
        }

        // 両方のプレイヤーが準備OKならシーン遷移
        if (isPlayerReady[0] && isPlayerReady[1])
        {
            if (selectSceneUI != null)
            {
                selectSceneUI.SetActive(false);  // SelectSceneのUIを非表示にする
            }

            switch (stageSelectController.currentMapIndex)
            {
                case 0:
                    StartCoroutine(LoadSceneAsync("PlayScene"));
                    break;
                case 1:
                    StartCoroutine(LoadSceneAsync("Stage2"));
                    break;
                case 2:
                    StartCoroutine(LoadSceneAsync("Stage3"));
                    break;
            }
        }
    }

    // 指定されたプレイヤーの準備状態に応じてUIを更新
    private void UpdateReadyUI(int playerIndex, bool isReady)
    {
        if (readyText[playerIndex] != null)
        {
            readyText[playerIndex].SetActive(isReady);  // 準備OKテキストの表示切り替え
        }

        if (notReadyText[playerIndex] != null)
        {
            notReadyText[playerIndex].SetActive(!isReady);  // 準備中テキストの表示切り替え
        }
    }

    // 非同期でシーンをロードし、完了後に処理を行う
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        if (selectSceneUI != null)
        {
            selectSceneUI.SetActive(false);
        }
    }
}
