using UnityEngine;

public class gameend : MonoBehaviour
{
    // ���̃I�u�W�F�N�g�ƐG�ꂽ�Ƃ��̏���
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("box�ɐG��܂���");
        // �v���C���[�^�O���t�����I�u�W�F�N�g�ɐG�ꂽ�ꍇ
        if (other.CompareTag("Player1"))
        {
            // ���s���I������
            Debug.Log("�v���C���[���I�u�W�F�N�g�ɐG��܂����B�I�����܂��B");
            Application.Quit();
        }
    }
}
