using UnityEngine;

public class PlayerJumpControll : MonoBehaviour
{
    private Rigidbody2D rbody2D;

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // �v���C���[1�̏ꍇ
        if (CompareTag("Player1"))
        {
            // �v���C���[1�̃W�����v�{�^������������
            if (Input.GetButtonDown("Jump_P1"))
            {
                Jump(); // �v���C���[1�̃W�����v����
            }
        }
        // �v���C���[2�̏ꍇ
        else if (CompareTag("Player2"))
        {
            // �v���C���[2�̃W�����v�{�^������������
            if (Input.GetButtonDown("Jump_P2"))
            {
                Jump(); // �v���C���[2�̃W�����v����
            }
        }
    }

    void Jump()
    {
        if (rbody2D != null)
        {
            rbody2D.AddForce(Vector2.up * 500); // �W�����v�͂̒���
        }
        else
        {
            Debug.LogError("Rigidbody2D���A�^�b�`����Ă��܂���I");
        }
    }
}
