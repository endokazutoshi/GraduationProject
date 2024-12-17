using UnityEngine;

public class Doormovement : MonoBehaviour
{
    public Transform targetPosition1;  // �v���C���[1�̈ړ���ʒu
    public Transform targetPosition2;  // �v���C���[2�̈ړ���ʒu
    private bool canOpenDoor1 = false; // �v���C���[1���h�A���J������
    private bool canOpenDoor2 = false; // �v���C���[2���h�A���J������
    private GameObject player1;        // �v���C���[1�̃I�u�W�F�N�g
    private GameObject player2;        // �v���C���[2�̃I�u�W�F�N�g

    void Start()
    {
        // �����ݒ�
    }

    void Update()
    {
        // �v���C���[1��B�{�^�����������ꍇ
        if (canOpenDoor1 && Input.GetButtonDown("B_Button_1P"))
        {
            Debug.Log("Player 1's B�{�^����������܂����I");
            OpenDoor("Player1");
        }

        // �v���C���[2��B�{�^�����������ꍇ
        if (canOpenDoor2 && Input.GetButtonDown("B_Button_2P"))
        {
            Debug.Log("Player 2's B�{�^����������܂����I");
            OpenDoor("Player2");
        }
    }

    // �v���C���[���I�u�W�F�N�g�ɐG�ꂽ�Ƃ�
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            canOpenDoor1 = true;  // �v���C���[1���G�ꂽ��B�{�^��������
            Debug.Log("Player 1 ���I�u�W�F�N�g�ɐG��܂����I");
            player1 = other.gameObject;  // �v���C���[1�̃I�u�W�F�N�g��ݒ�
        }
        else if (other.CompareTag("Player2"))
        {
            canOpenDoor2 = true;  // �v���C���[2���G�ꂽ��B�{�^��������
            Debug.Log("Player 2 ���I�u�W�F�N�g�ɐG��܂����I");
            player2 = other.gameObject;  // �v���C���[2�̃I�u�W�F�N�g��ݒ�
        }
    }

    // �v���C���[���I�u�W�F�N�g���痣�ꂽ�Ƃ�
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            canOpenDoor1 = false;  // �v���C���[1�����ꂽ��B�{�^���������Ȃ��Ȃ�
            Debug.Log("Player 1 ���I�u�W�F�N�g���痣��܂����I");
            player1 = null;  // �v���C���[1�̃I�u�W�F�N�g�����Z�b�g
        }
        else if (other.CompareTag("Player2"))
        {
            canOpenDoor2 = false;  // �v���C���[2�����ꂽ��B�{�^���������Ȃ��Ȃ�
            Debug.Log("Player 2 ���I�u�W�F�N�g���痣��܂����I");
            player2 = null;  // �v���C���[2�̃I�u�W�F�N�g�����Z�b�g
        }
    }

    // �h�A���J���郁�\�b�h
    void OpenDoor(string playerTag)
    {
        if (playerTag == "Player1" && player1 != null && targetPosition1 != null)
        {
            // �v���C���[1���G�ꂽ�ꍇ
            Debug.Log("Player 1 �̃h�A���J���܂��I");
            player1.transform.position = targetPosition1.position;  // �v���C���[1���ړ�
        }
        else if (playerTag == "Player2" && player2 != null && targetPosition2 != null)
        {
            // �v���C���[2���G�ꂽ�ꍇ
            Debug.Log("Player 2 �̃h�A���J���܂��I");
            player2.transform.position = targetPosition2.position;  // �v���C���[2���ړ�
        }
    }
}
