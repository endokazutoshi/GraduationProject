using UnityEngine;

public class StageSelectController2 : MonoBehaviour
{
    public GameObject[] readySprite; // 準備OKの画像
    public GameObject[] notReadySprite; // 準備中の画像
    public GameObject[] targetText; // テキスト（GameObjectの表示切り替え）

    private bool[] isPlayerReady = new bool[2]; // プレイヤーの準備状態
    private SceneManagerController sceneManagerController;

    void Start()
    {
        sceneManagerController = FindObjectOfType<SceneManagerController>();
        UpdateReadyUI(0, false);
        UpdateReadyUI(1, false);
    }

    void Update()
    {
        if (sceneManagerController != null && sceneManagerController.IsInputDisabled()) return;
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
    }

    private void UpdateReadyUI(int playerIndex, bool isReady)
    {
        if (readySprite[playerIndex] != null && notReadySprite[playerIndex] != null)
        {
            readySprite[playerIndex].SetActive(isReady);
            notReadySprite[playerIndex].SetActive(!isReady);
        }

        if (targetText[playerIndex] != null)
        {
            targetText[playerIndex].SetActive(isReady);
        }
    }
}