using UnityEngine;

public class PlayerJumpControll : MonoBehaviour
{
    private Rigidbody2D rbody2D;
    private bool isGrounded; // 地面に接しているかどうか
    public float groundCheckDistance = 0.5f; // 地面判定の範囲

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // プレイヤーが地面に接している場合のみジャンプを許可
        if (isGrounded)
        {
            // プレイヤー1の場合
            if (CompareTag("Player1"))
            {
                // プレイヤー1のジャンプボタンを押した時
                if (Input.GetButtonDown("Jump_P1"))
                {
                    Jump(); // プレイヤー1のジャンプ処理
                }
            }
            // プレイヤー2の場合
            else if (CompareTag("Player2"))
            {
                // プレイヤー2のジャンプボタンを押した時
                if (Input.GetButtonDown("Jump_P2"))
                {
                    Jump(); // プレイヤー2のジャンプ処理
                }
            }
        }

        // 地面判定を行う
        CheckGroundStatus();
    }

    void Jump()
    {
        if (rbody2D != null)
        {
            rbody2D.AddForce(Vector2.up * 400); // ジャンプ力の調整
            isGrounded = false; // ジャンプしたので地面にいない状態に
        }
        else
        {
            Debug.LogError("Rigidbody2Dがアタッチされていません！");
        }
    }

    // プレイヤーが地面に接触しているかを確認
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 地面と接触した場合、ジャンプができるようにする
        if (collision.gameObject.CompareTag("Wall"))
        {
            isGrounded = true;
        }
    }

    // 地面と接触している間、ジャンプが可能
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isGrounded = false;
        }
    }

    // プレイヤーの下方向にRaycastを飛ばして地面と接触しているかを確認
    void CheckGroundStatus()
    {
        // プレイヤーの下方向にRaycastを発射
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance);

        // Raycastが地面にヒットした場合、地面に接しているとみなす
        if (hit.collider != null && hit.collider.CompareTag("Wall"))
        {
            isGrounded = true;
        }
    }
}
