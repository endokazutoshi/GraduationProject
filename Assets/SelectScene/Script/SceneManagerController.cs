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

    // フェードアウトに使用するSpriteRenderer
    public SpriteRenderer fadeSpriteRenderer;

    void Start()
    {
        // 初期状態では準備中テキストを表示、準備OKテキストを非表示
        UpdateReadyUI(0, false);
        UpdateReadyUI(1, false);

        // フェードアウト用のSpriteRendererを透明に設定
        if (fadeSpriteRenderer != null)
        {
            fadeSpriteRenderer.color = new Color(0, 0, 0, 0);  // 初期状態は透明
        }
    }

    void Update()
    {
        // Player1の準備状態を変更
        if (Input.GetButtonDown("Jump_P1"))
        {
            isPlayerReady[0] = true;
            UpdateReadyUI(0, true);
        }
        else if (Input.GetButtonDown("B_Button_1P"))
        {
            isPlayerReady[0] = false;
            UpdateReadyUI(0, false);
        }

        // Player2の準備状態を変更
        if (Input.GetButtonDown("Jump_P2"))
        {
            isPlayerReady[1] = true;
            UpdateReadyUI(1, true);
        }
        else if (Input.GetButtonDown("B_Button_2P"))
        {
            isPlayerReady[1] = false;
            UpdateReadyUI(1, false);
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
                    StartCoroutine(FadeAndLoadScene("PlayScene"));
                    break;
                case 1:
                    StartCoroutine(FadeAndLoadScene("PlayScene2"));
                    break;
                case 2:
                    StartCoroutine(FadeAndLoadScene("PlayScene3"));
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

    // フェードアウトとシーン遷移を行う
    private IEnumerator FadeAndLoadScene(string sceneName)
    {
        // フェードアウト
        if (fadeSpriteRenderer != null)
        {
            float fadeDuration = 2.0f;  // フェードアウトの時間（2秒）
            float elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                // アルファ値を増加させてフェードアウトを実行
                fadeSpriteRenderer.color = new Color(0, 0, 0, Mathf.Clamp01(elapsedTime / fadeDuration));
                yield return null;
            }
        }

        // シーン遷移
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
