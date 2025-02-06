using UnityEngine;

public class ResultSceneManager : MonoBehaviour
{
    public GameObject[] stageBackgroundObjects;  // �X�e�[�W�ɑΉ�����w�i�I�u�W�F�N�g���i�[

    void Start()
    {
        // PlayerPrefs����X�e�[�W�����擾
        int stage = PlayerPrefs.GetInt("Stage", 1);  // �f�t�H���g��Stage1�i1�j�ɐݒ�

        // �X�e�[�W�ɉ����Ĕw�i�I�u�W�F�N�g��\���A���̑����\���ɂ���
        for (int i = 0; i < stageBackgroundObjects.Length; i++)
        {
            if (i == stage - 1)  // �I�΂ꂽ�X�e�[�W�̃C���f�b�N�X�ƈ�v����ꍇ
            {
                stageBackgroundObjects[i].SetActive(true);  // �w�i��\��
            }
            else
            {
                stageBackgroundObjects[i].SetActive(false);  // ���̔w�i���\��
            }
        }
    }
}
