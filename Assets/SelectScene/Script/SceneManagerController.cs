using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManagerController : MonoBehaviour
{
    public StageSelectController stageSelectController;  // StageSelectController�ւ̎Q��
    public GameObject selectSceneUI;  // SelectScene��UI�I�u�W�F�N�g

    // �������Ə���OK�̃e�L�X�g�i�v���C���[���Ƃɐݒ�j
    public GameObject[] readyText;  // ����OK�e�L�X�g [0]: Player1, [1]: Player2
    public GameObject[] notReadyText;  // �������e�L�X�g [0]: Player1, [1]: Player2

    private bool[] isPlayerReady = new bool[2];  // �v���C���[�̏������ [0]: Player1, [1]: Player2

    // �t�F�[�h�A�E�g�Ɏg�p����SpriteRenderer
    public SpriteRenderer fadeSpriteRenderer;

    void Start()
    {
        // ������Ԃł͏������e�L�X�g��\���A����OK�e�L�X�g���\��
        UpdateReadyUI(0, false);
        UpdateReadyUI(1, false);

        // �t�F�[�h�A�E�g�p��SpriteRenderer�𓧖��ɐݒ�
        if (fadeSpriteRenderer != null)
        {
            fadeSpriteRenderer.color = new Color(0, 0, 0, 0);  // ������Ԃ͓���
        }
    }

    void Update()
    {
        // Player1�̏�����Ԃ�ύX
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

        // Player2�̏�����Ԃ�ύX
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

        // �����̃v���C���[������OK�Ȃ�V�[���J��
        if (isPlayerReady[0] && isPlayerReady[1])
        {
            if (selectSceneUI != null)
            {
                selectSceneUI.SetActive(false);  // SelectScene��UI���\���ɂ���
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

    // �w�肳�ꂽ�v���C���[�̏�����Ԃɉ�����UI���X�V
    private void UpdateReadyUI(int playerIndex, bool isReady)
    {
        if (readyText[playerIndex] != null)
        {
            readyText[playerIndex].SetActive(isReady);  // ����OK�e�L�X�g�̕\���؂�ւ�
        }

        if (notReadyText[playerIndex] != null)
        {
            notReadyText[playerIndex].SetActive(!isReady);  // �������e�L�X�g�̕\���؂�ւ�
        }
    }

    // �t�F�[�h�A�E�g�ƃV�[���J�ڂ��s��
    private IEnumerator FadeAndLoadScene(string sceneName)
    {
        // �t�F�[�h�A�E�g
        if (fadeSpriteRenderer != null)
        {
            float fadeDuration = 2.0f;  // �t�F�[�h�A�E�g�̎��ԁi2�b�j
            float elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                // �A���t�@�l�𑝉������ăt�F�[�h�A�E�g�����s
                fadeSpriteRenderer.color = new Color(0, 0, 0, Mathf.Clamp01(elapsedTime / fadeDuration));
                yield return null;
            }
        }

        // �V�[���J��
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
