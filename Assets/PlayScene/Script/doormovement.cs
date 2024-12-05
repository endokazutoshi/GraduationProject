using UnityEngine;

public class Doormovement : MonoBehaviour
{
    public Transform targetPosition;  // �ړ���̈ʒu
    private bool canOpenDoor = false;  // �h�A���J����Ԃ��ǂ���
    private GameObject objectPlayer;  // �ړ����������I�u�W�F�N�g

    void Start()
    {
        // �����ݒ�
    }

    void Update()
    {
        // B�{�^����������Ă��āA���G��Ă���ꍇ�Ƀh�A���J����
        if (canOpenDoor && Input.GetButtonDown("B_Button_1P"))
        {
            Debug.Log("Player 1's B�{�^����������܂����I");
            OpenDoor("Player1");
        }
        // B�{�^����������Ă��āA���G��Ă���ꍇ�Ƀh�A���J����
        if (canOpenDoor && Input.GetButtonDown("B_Button_2P"))
        {
            Debug.Log("Player 2's B�{�^����������܂����I");
            OpenDoor("Player2");
        }
    }

    // �v���C���[���I�u�W�F�N�g�ɐG�ꂽ�Ƃ�
    void OnTriggerEnter2D(Collider2D other)
    {
        // �v���C���[1�̃^�O���m�F
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            canOpenDoor = true;  // �v���C���[���G�ꂽ��B�{�^���������悤�ɂ���
            Debug.Log("�v���C���[���I�u�W�F�N�g�ɐG��܂����I");
            objectPlayer = other.gameObject;  // �G�ꂽ�v���C���[�I�u�W�F�N�g��ݒ�
        }
    }

    // �v���C���[���I�u�W�F�N�g���痣�ꂽ�Ƃ�
    void OnTriggerExit2D(Collider2D other)
    {
        // �v���C���[�̃^�O���m�F
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            canOpenDoor = false;  // �v���C���[�����ꂽ��B�{�^���������Ȃ��Ȃ�
            Debug.Log("�v���C���[���I�u�W�F�N�g���痣��܂����I");
            objectPlayer = null;  // �v���C���[�����ꂽ��I�u�W�F�N�g�����Z�b�g
        }
    }

    // �h�A���J���郁�\�b�h
    void OpenDoor(string playerTag)
    {
        if (objectPlayer != null && targetPosition != null)
        {
            // �^�O�ɂ���ĈقȂ鏈�����s���ꍇ������܂����A����͋��ʏ����ɂ��Ă��܂�
            Debug.Log($"{playerTag} �̃h�A���J���܂��I");
            // �I�u�W�F�N�g���^�[�Q�b�g�ʒu�Ɉړ�������
            objectPlayer.transform.position = targetPosition.position;
        }
    }
}
