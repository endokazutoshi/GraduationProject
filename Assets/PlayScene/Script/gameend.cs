using UnityEngine;
using UnityEngine.SceneManagement;  // SceneManager���g�����߂ɃC���|�[�g

public class gameend : MonoBehaviour
{
    // ���̃I�u�W�F�N�g�ƐG�ꂽ�Ƃ��̏���
    void OnTriggerEnter2D(Collider2D collider)
    {
        // �v���C���[�^�O���t�����I�u�W�F�N�g�ɐG�ꂽ�ꍇ
        if (collider.CompareTag("Player1"))
        {
            Debug.Log("�v���C���[1���I�u�W�F�N�g�ɐG��܂����B���U���g�V�[���ɑJ�ڂ��܂��B");
            SceneChange("Player1");
                        
        }
        // �v���C���[�^�O���t�����I�u�W�F�N�g�ɐG�ꂽ�ꍇ
        if (collider.CompareTag("Player2"))
        {
            Debug.Log("�v���C���[2���I�u�W�F�N�g�ɐG��܂����B���U���g�V�[���ɑJ�ڂ��܂��B");
            SceneChange("Player2");

        }
    }
    void SceneChange(string PlayerTag)
    {
        SceneManager.LoadScene("ResultScene");
    }
}
