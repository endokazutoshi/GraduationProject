using UnityEngine;

public class gameend : MonoBehaviour
{
    // ���̃I�u�W�F�N�g�ƐG�ꂽ�Ƃ��̏���
    void OnTriggerEnter2D(Collider2D collider)
    {
        // �v���C���[�^�O���t�����I�u�W�F�N�g�ɐG�ꂽ�ꍇ
        if (collider.CompareTag("Player1"))
        {
            Debug.Log("�v���C���[���I�u�W�F�N�g�ɐG��܂����B�I�����܂��B");

            // ���s���I������
            // �G�f�B�^�ł�����m�F���邽�߂ɃG�f�B�^�`�F�b�N
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
