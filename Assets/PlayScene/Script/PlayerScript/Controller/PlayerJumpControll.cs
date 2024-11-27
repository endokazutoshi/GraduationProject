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

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
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

    [SerializeField]
    private float groundCheckDistanceX = 0.5f; // 左右の範囲をInspectorで調整可能
    [SerializeField]
    private float groundCheckDistanceY = 0.5f; // 下方向の範囲をInspectorで調整可能

    bool GroundChk()
    {
        // 現在位置を中心に各チェックポイントを計算
        Vector3 leftPosition = transform.position - new Vector3(groundCheckDistanceX, 0, 0);
        Vector3 rightPosition = transform.position + new Vector3(groundCheckDistanceX, 0, 0);
        Vector3 bottomPosition = transform.position - new Vector3(0, groundCheckDistanceY, 0);

        // デバッグ用にラインを表示
        Debug.DrawLine(leftPosition, rightPosition, Color.green); // 左右のライン
        Debug.DrawLine(transform.position, bottomPosition, Color.blue); // 下方向のライン

        // X方向のラインチェック
        RaycastHit2D xHit = Physics2D.Linecast(leftPosition, rightPosition, StageLayer);

        // Y方向のラインチェック（下方向のみ）
        RaycastHit2D yHit = Physics2D.Linecast(transform.position, bottomPosition, StageLayer);

        // XまたはY方向に接触がある場合
        if (xHit.collider != null || yHit.collider != null)
        {
            if (xHit.collider != null)
            {
                Debug.Log($"Wall 検出（X方向）: {xHit.collider.gameObject.name}");
            }

            if (yHit.collider != null)
            {
                Debug.Log($"Wall 検出（Y方向）: {yHit.collider.gameObject.name}");
            }

            return true;
        }

        return false; // 接触がない場合
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
