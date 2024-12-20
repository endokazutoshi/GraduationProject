using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;  // IEnumerator���g�p���邽�߂ɕK�v

public class SceneManagerController : MonoBehaviour
{
    public StageSelectController stageSelectController;  // StageSelectController�ւ̎Q��
    public GameObject selectSceneUI;  // SelectScene��UI�I�u�W�F�N�g�i�e�I�u�W�F�N�g�j

    void Update()
    {
        // A�{�^���������ꂽ��A���݂̃C���f�b�N�X�Ɋ�Â��ăV�[�����ړ�
        if (Input.GetButtonDown("Jump_P1"))
        {
            // �V�[���J�ڑO��SelectScene��UI���A�N�e�B�u�ɂ���
            if (selectSceneUI != null)
            {
                selectSceneUI.SetActive(false);  // SelectScene��UI���\���ɂ���
            }

            // ���݂̃C���f�b�N�X�Ɋ�Â��ăV�[����J��
            switch (stageSelectController.currentMapIndex)
            {
                case 0:
                    // �C���f�b�N�X��0�̏ꍇ�A�X�e�[�W1�Ɉړ�
                    StartCoroutine(LoadSceneAsync("PlayScene"));
                    break;

                case 1:
                    // �C���f�b�N�X��1�̏ꍇ�A�X�e�[�W2�Ɉړ�
                    StartCoroutine(LoadSceneAsync("Stage2"));
                    break;

                case 2:
                    // �C���f�b�N�X��2�̏ꍇ�A�X�e�[�W3�Ɉړ�
                    StartCoroutine(LoadSceneAsync("Stage3"));
                    break;

                default:
                    // ����ȊO�̏ꍇ�A�X�e�[�W1�Ɉړ�
                    StartCoroutine(LoadSceneAsync("Stage1"));
                    break;
            }
        }
    }

    // �񓯊��ŃV�[�������[�h���A������ɏ������s��
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // �V�[����񓯊��œǂݍ���
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // �V�[�������S�ɓǂݍ��܂��܂őҋ@
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // �V�[�������[�h���ꂽ���UI���\���ɂ���
        if (selectSceneUI != null)
        {
            selectSceneUI.SetActive(false);
        }
    }
}
