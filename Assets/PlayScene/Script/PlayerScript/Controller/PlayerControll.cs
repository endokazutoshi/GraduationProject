using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed_H = 5f; // �����ړ����x

    public int can_move = 0; // ������ł��Ȃ����邽�߂̕ϐ� (0: �ړ��\, 1: �ړ��s��)

    private Rigidbody2D rbody2D;

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // can_move �� 1 �̏ꍇ�͈ړ��𖳌��ɂ���
        if (can_move == 0)
        {
            float moveInput_H = 0f;  // �������̓��͒l

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
        // can_move �� 1 �̏ꍇ�͈ړ����������Ȃ� (�ړ��s��)
    }
}
