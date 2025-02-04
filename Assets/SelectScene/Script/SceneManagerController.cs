using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManagerController : MonoBehaviour
{
    public StageSelectController stageSelectController;
    public GameObject selectSceneUI;
    public GameObject[] readyText;
    public GameObject[] notReadyText;
    private bool[] isPlayerReady = new bool[2];
    public SpriteRenderer fadeSpriteRenderer;
    public SpriteRenderer fadeSpriteRenderer2;
    private bool isInputDisabled = false; // “ü—Í–³Œø‰»ƒtƒ‰ƒO

    void Start()
    {
        UpdateReadyUI(0, false);
        UpdateReadyUI(1, false);
        if (fadeSpriteRenderer != null)
        {
            fadeSpriteRenderer.color = new Color(0, 0, 0, 0);
        }
        if (fadeSpriteRenderer2 != null)
        {
            fadeSpriteRenderer2.color = new Color(0, 0, 0, 0);
        }
    }

    void Update()
    {
        if (isInputDisabled) return; // “ü—Í–³ŒøŽž‚Í‰½‚à‚µ‚È‚¢

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

        if (isPlayerReady[0] && isPlayerReady[1])
        {

            if (selectSceneUI != null)
            {
                selectSceneUI.SetActive(false);
            }

            isInputDisabled = true;

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

    private void UpdateReadyUI(int playerIndex, bool isReady)
    {
        if (readyText[playerIndex] != null)
        {
            readyText[playerIndex].SetActive(isReady);
        }
        if (notReadyText[playerIndex] != null)
        {
            notReadyText[playerIndex].SetActive(!isReady);
        }
    }

    private IEnumerator FadeAndLoadScene(string sceneName)
    {
        if (fadeSpriteRenderer && fadeSpriteRenderer2 != null)
        {
            float fadeDuration = 2.0f;
            float elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                fadeSpriteRenderer.color = new Color(0, 0, 0, Mathf.Clamp01(elapsedTime / fadeDuration));
                fadeSpriteRenderer2.color = new Color(0, 0, 0, Mathf.Clamp01(elapsedTime / fadeDuration));
                yield return null;
            }
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public bool IsInputDisabled()
    {
        return isInputDisabled;
    }
}
