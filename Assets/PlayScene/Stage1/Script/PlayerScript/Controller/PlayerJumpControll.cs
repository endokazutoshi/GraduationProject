using UnityEngine;

public class PlayerJumpControl : MonoBehaviour
{
    private Rigidbody2D rbody2D;
    private bool isGrounded;
    public float groundCheckDistance = 0.5f;
    public float initialJumpForce = 5f;
    public float holdJumpForce = 2f;
    public float maxJumpTime = 0.5f;
    private float jumpTimeCounter;
    private bool isJumping;

    public LayerMask StageLayer; // mapCanvasのWallレイヤーに設定

    [SerializeField] private AudioSource audioSource; // SE用のAudioSource
    [SerializeField] private AudioClip jumpSE; // ジャンプ時のSE

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();

        // AudioSourceがアタッチされていない場合、取得
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (isGrounded)
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
            // ジャンプの初期力を加える
            rbody2D.velocity = new Vector2(rbody2D.velocity.x, initialJumpForce);

            // SEを再生
            if (audioSource != null && jumpSE != null)
            {
                audioSource.PlayOneShot(jumpSE);
            }
            else
            {
                Debug.LogWarning("AudioSource または JumpSE が設定されていません！");
            }

            isJumping = true;
            isGrounded = false; // 地面から離れたとみなす
            jumpTimeCounter = 0;
        }
        else
        {
            Debug.LogError("Rigidbody2Dがアタッチされていません！");
        }
    }

    void ContinueJump()
    {
        if (jumpTimeCounter < maxJumpTime)
        {
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

    [SerializeField]
    private float groundCheckDistanceX = 0.5f;
    [SerializeField]
    private float groundCheckDistanceY = 0.5f;

    bool GroundChk()
    {
        Vector3 leftPosition = transform.position - new Vector3(groundCheckDistanceX, 0, 0);
        Vector3 rightPosition = transform.position + new Vector3(groundCheckDistanceX, 0, 0);
        Vector3 bottomPosition = transform.position - new Vector3(0, groundCheckDistanceY, 0);

        Debug.DrawLine(leftPosition, rightPosition, Color.green);
        Debug.DrawLine(transform.position, bottomPosition, Color.blue);

        RaycastHit2D xHit = Physics2D.Linecast(leftPosition, rightPosition, StageLayer);
        RaycastHit2D yHit = Physics2D.Linecast(transform.position, bottomPosition, StageLayer);

        if (xHit.collider != null || yHit.collider != null)
        {
            return true;
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            isGrounded = true;
            Debug.Log("ジャンプできます");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            isGrounded = false;
            Debug.Log("ジャンプできません");
        }
    }

    void CheckGroundStatus()
    {
        if (GroundChk())
        {
            isGrounded = true;
        }
    }
}
