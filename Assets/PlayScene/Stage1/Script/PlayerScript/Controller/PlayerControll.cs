using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int can_move1 = 0;  // 'can_move' �� public �ɂ��Ē��ڃA�N�Z�X�\�ɂ���
    public int can_move2 = 0;
    public float speed_H = 5f; // �����ړ����x

    private Rigidbody2D rbody2D;

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Debug.Log("can_move1��" + can_move1);


        Debug.Log("can_move2��" + can_move2);

        // can_move �� 0 �̏ꍇ�͈ړ�������
        if (can_move1 == 0 && can_move2 == 0)
        {
            float moveInput_H = 0f;  // �������̓��͒l
            Debug.Log("�ړ��ł��܂�");
            // �v���C���[��1P��2P���ɂ���ē��͂��󂯎��
            if (CompareTag("Player1"))
            {
                moveInput_H = Input.GetAxis("L_Stick_H_1P");
            }
            else if (CompareTag("Player2"))
            {
                moveInput_H = Input.GetAxis("L_Stick_H_2P");
            }

            // ���ړ�
            transform.Translate(Vector3.right * moveInput_H * speed_H * Time.deltaTime);
        }
        else
        {
            // can_move �� 1 �̏ꍇ�͈ړ����Ȃ� (�ړ��s��)
            Debug.Log("�ړ��ł��܂���");
        }
    }
}