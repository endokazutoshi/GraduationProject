using UnityEngine;

public class PlayerJumpControll : MonoBehaviour
{
    private Rigidbody2D rbody2D;
    private bool isGrounded; // �n�ʂɐڂ��Ă��邩�ǂ���
    public float groundCheckDistance = 0.5f; // �n�ʔ���͈̔�

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // �v���C���[���n�ʂɐڂ��Ă���ꍇ�̂݃W�����v������
        if (isGrounded)
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

        // �n�ʔ�����s��
        CheckGroundStatus();
    }

    void Jump()
    {
        if (rbody2D != null)
        {
            rbody2D.AddForce(Vector2.up * 400); // �W�����v�͂̒���
            isGrounded = false; // �W�����v�����̂Œn�ʂɂ��Ȃ���Ԃ�
        }
        else
        {
            Debug.LogError("Rigidbody2D���A�^�b�`����Ă��܂���I");
        }
    }

    // �v���C���[���n�ʂɐڐG���Ă��邩���m�F
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �n�ʂƐڐG�����ꍇ�A�W�����v���ł���悤�ɂ���
        if (collision.gameObject.CompareTag("Wall"))
        {
            isGrounded = true;
        }
    }

    // �n�ʂƐڐG���Ă���ԁA�W�����v���\
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isGrounded = false;
        }
    }

    // �v���C���[�̉�������Raycast���΂��Ēn�ʂƐڐG���Ă��邩���m�F
    void CheckGroundStatus()
    {
        // �v���C���[�̉�������Raycast�𔭎�
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance);

        // Raycast���n�ʂɃq�b�g�����ꍇ�A�n�ʂɐڂ��Ă���Ƃ݂Ȃ�
        if (hit.collider != null && hit.collider.CompareTag("Wall"))
        {
            isGrounded = true;
        }
    }
}
