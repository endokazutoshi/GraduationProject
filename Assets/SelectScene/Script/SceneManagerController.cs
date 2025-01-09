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

    void Start()
    {
        // ������Ԃł͏������e�L�X�g��\���A����OK�e�L�X�g���\��
        UpdateReadyUI(0, false);
        UpdateReadyUI(1, false);
    }

    void Update()
    {
        // Player1�̏�����Ԃ�؂�ւ�
        if (Input.GetButtonDown("Jump_P1"))
        {
            isPlayerReady[0] = !isPlayerReady[0];
            UpdateReadyUI(0, isPlayerReady[0]);
        }

        // Player2�̏�����Ԃ�؂�ւ�
        if (Input.GetButtonDown("Jump_P2"))
        {
            isPlayerReady[1] = !isPlayerReady[1];
            UpdateReadyUI(1, isPlayerReady[1]);
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

    // �񓯊��ŃV�[�������[�h���A������ɏ������s��
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
