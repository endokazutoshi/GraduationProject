using UnityEngine;

public class PlayerJumpControll : MonoBehaviour
{
    private Rigidbody2D rbody2D;
    private bool isGrounded;
    public float groundCheckDistance = 0.5f;
    public float initialJumpForce = 5f;
    public float holdJumpForce = 2f;
    public float maxJumpTime = 0.5f;
    private float jumpTimeCounter;
    private bool isJumping;

    public LayerMask StageLayer; // mapCanvas��Wall���C���[�ɐݒ�

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Wall�ɐG��Ă���Ƃ����W�����v���\
        if (isGrounded || IsTouchingWall())
        {
            if (CompareTag("Player1") && Input.GetButtonDown("Jump_P1"))
            {
                StartJump();
            }
            else if (CompareTag("Player2") && Input.GetButtonDown("Jump_P2"))
            {
                StartJump();
            }
        }

        if (isJumping)
        {
            if ((CompareTag("Player1") && Input.GetButton("Jump_P1")) ||
                (CompareTag("Player2") && Input.GetButton("Jump_P2")))
            {
                ContinueJump();
            }
            else
            {
                EndJump();
            }
        }

        CheckGroundStatus();
    }

    void StartJump()
    {
        if (rbody2D != null)
        {
            // �W�����v�̏����͂�������
            rbody2D.velocity = new Vector2(rbody2D.velocity.x, initialJumpForce);

            isJumping = true;
            isGrounded = false;
            jumpTimeCounter = 0;
        }
        else
        {
            Debug.LogError("Rigidbody2D���A�^�b�`����Ă��܂���I");
        }
    }

    void ContinueJump()
    {
        if (jumpTimeCounter < maxJumpTime)
        {
            // �{�^�������������Ă���ԁA�ǉ��W�����v�͂�������
            rbody2D.velocity = new Vector2(rbody2D.velocity.x, rbody2D.velocity.y + holdJumpForce * Time.deltaTime);
            jumpTimeCounter += Time.deltaTime;
        }
        else
        {
            EndJump();
        }
    }

    void EndJump()
    {
        isJumping = false;
    }

    // Wall�ɐG��Ă��邩���m�F����֐�
    bool IsTouchingWall()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0.5f);
        return hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Wall");
    }

    // GroundChk�֐��F�v���C���[��StageLayer�ɐG��Ă��邩�m�F
    bool GroundChk()
    {
        Vector3 startposition = transform.position;                       // Player�̒��S���n�_�Ƃ���
        Vector3 endposition = transform.position - transform.up * 0.7f;  // Player�̑������I�_�Ƃ���

        // Debug�p�Ɏn�_�ƏI�_��\������
        Debug.DrawLine(startposition, endposition, Color.red);

        // Physics2D.Linecast���g���AStageLayer�imapCanvas��Wall���C���[�j�ɐڐG���Ă�����True��Ԃ�
        return Physics2D.Linecast(startposition, endposition, StageLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            isGrounded = false;
        }
    }

    void CheckGroundStatus()
    {
        // GroundChk���g���āA�v���C���[�̑�����StageLayer�imapCanvas��Wall���C���[�j�ƐڐG���Ă��邩�m�F
        if (GroundChk())
        {
            isGrounded = true;
        }
    }
}
