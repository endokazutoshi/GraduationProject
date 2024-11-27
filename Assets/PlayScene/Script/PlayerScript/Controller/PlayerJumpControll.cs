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

    public LayerMask StageLayer; // mapCanvasのWallレイヤーに設定

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Wallに触れているときもジャンプが可能
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
            // ジャンプの初期力を加える
            rbody2D.velocity = new Vector2(rbody2D.velocity.x, initialJumpForce);

            isJumping = true;
            isGrounded = false;
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
            // ボタンを押し続けている間、追加ジャンプ力を加える
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

    // Wallに触れているかを確認する関数
    bool IsTouchingWall()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0.5f);
        return hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Wall");
    }

    // GroundChk関数：プレイヤーがStageLayerに触れているか確認
    bool GroundChk()
    {
        Vector3 startposition = transform.position;                       // Playerの中心を始点とする
        Vector3 endposition = transform.position - transform.up * 0.7f;  // Playerの足元を終点とする

        // Debug用に始点と終点を表示する
        Debug.DrawLine(startposition, endposition, Color.red);

        // Physics2D.Linecastを使い、StageLayer（mapCanvasのWallレイヤー）に接触していたらTrueを返す
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
        // GroundChkを使って、プレイヤーの足元がStageLayer（mapCanvasのWallレイヤー）と接触しているか確認
        if (GroundChk())
        {
            isGrounded = true;
        }
    }
}
