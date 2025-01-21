using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int can_move1 = 0;  // 'can_move' �� public �ɂ��Ē��ڃA�N�Z�X�\�ɂ���
    public int can_move2 = 0;
    public float speed_H = 5f; // �����ړ����x
    private Animator anime;

    private Rigidbody2D rbody2D;

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
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

                if (Input.GetButton("Jump_P1"))
                {
                    anime.SetBool("Jump", true);
                }
                else
                {
                    anime.SetBool("Jump", false);
                }
                // �X�e�B�b�N���E�ɓ����Ă��邩
                if (moveInput_H > 0.1f)
                {
                    Debug.Log("�E�ɓ����Ă��܂�");
                    // �E�ɓ�������E������
                    transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                }
                // �X�e�B�b�N�����ɓ����Ă��邩
                else if (moveInput_H < -0.1f)
                {
                    Debug.Log("���ɓ����Ă��܂�");
                    // ���ɓ������獶������
                    transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                }
                // �X�e�B�b�N�������Ă��Ȃ���
                else
                {
                    Debug.Log("�X�e�B�b�N�͓����Ă��܂���");
                }

                if (Mathf.Abs(moveInput_H) > 0.1f)  // �X�e�B�b�N���������ꍇ
                {
                    anime.SetBool("Run", true);
                }
                else  // �X�e�B�b�N�������Ȃ��ꍇ
                {
                    anime.SetBool("Run", false);
                }
            }

            if (CompareTag("Player2"))
            {
                moveInput_H = Input.GetAxis("L_Stick_H_2P");

                // �X�e�B�b�N���E�ɓ����Ă��邩
                if (moveInput_H > 0.1f)
                {
                    Debug.Log("Player2 �E�ɓ����Ă��܂�");
                    // �E�ɓ�������E������
                    transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                }
                // �X�e�B�b�N�����ɓ����Ă��邩
                else if (moveInput_H < -0.1f)
                {
                    Debug.Log("Player2 ���ɓ����Ă��܂�");
                    // ���ɓ������獶������
                    transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                }
                // �X�e�B�b�N�������Ă��Ȃ���
                else
                {
                    Debug.Log("Player2 �X�e�B�b�N�͓����Ă��܂���");
                }

                if (Mathf.Abs(moveInput_H) > 0.1f)  // �X�e�B�b�N���������ꍇ
                {
                    anime.SetBool("Run", true);
                }
                else  // �X�e�B�b�N�������Ȃ��ꍇ
                {
                    anime.SetBool("Run", false);
                }
            }

            // ���ړ��iRigidbody2D�̑��x��ύX�j
            rbody2D.velocity = new Vector2(moveInput_H * speed_H, rbody2D.velocity.y);
        }
        else
        {
            // can_move �� 1 �̏ꍇ�͈ړ����Ȃ� (�ړ��s��)
            Debug.Log("�ړ��ł��܂���");
        }
    }
}


//if (CompareTag("Player2") && Input.GetButtonDown("Jump_P2"))
//{
//    anime.SetBool("Jump", true);
//    StartJump();
//}
//else if (CompareTag("Player2") && Input.GetButtonUp("Jump_P2"))
//{
//    anime.SetBool("Jump", false);
//}