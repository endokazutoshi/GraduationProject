using UnityEngine;
using UnityEngine.SceneManagement;  // SceneManager���g�����߂ɃC���|�[�g

public class gameend : MonoBehaviour
{
    // ���̃I�u�W�F�N�g�ƐG�ꂽ�Ƃ��̏���
    void OnTriggerEnter2D(Collider2D collider)
    {
        // �v���C���[1���G�ꂽ�ꍇ
        if (collider.CompareTag("Player1"))
        {
            Debug.Log("�v���C���[1���I�u�W�F�N�g�ɐG��܂����B���U���g�V�[���ɑJ�ڂ��܂��B");

            // �v���C���[1�̃S�[������ۑ�
            PlayerPrefs.SetInt("Player1Goal", 1);  // �v���C���[1�̃S�[����1�ɐݒ�
            PlayerPrefs.SetInt("Player2Goal", 0);  // �v���C���[2�̃S�[����0�ɐݒ�

            SceneChange();
        }
        // �v���C���[2���G�ꂽ�ꍇ
        else if (collider.CompareTag("Player2"))
        {
            Debug.Log("�v���C���[2���I�u�W�F�N�g�ɐG��܂����B���U���g�V�[���ɑJ�ڂ��܂��B");

            // �v���C���[2�̃S�[������ۑ�
            PlayerPrefs.SetInt("Player1Goal", 0);  // �v���C���[1�̃S�[����0�ɐݒ�
            PlayerPrefs.SetInt("Player2Goal", 1);  // �v���C���[2�̃S�[����1�ɐݒ�

            SceneChange();
        }
    }

    void SceneChange()
    {
        SceneManager.LoadScene("ResultScene2");  // ���U���g�V�[���ɑJ��
    }
}
