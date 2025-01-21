using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int can_move1 = 0;  // 'can_move' を public にして直接アクセス可能にする
    public int can_move2 = 0;
    public float speed_H = 5f; // 水平移動速度
    public float dragFactor = 0.98f;  // 滑り具合を制御するための減衰係数
    private Animator anime;

    private Rigidbody2D rbody2D;
    private bool isOnFrozenSurface = false;  // Frozenタグにいるかどうかのフラグ

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Debug.Log("can_move1は" + can_move1);
        Debug.Log("can_move2は" + can_move2);

        // can_move が 0 の場合は移動を許可
        if (can_move1 == 0 && can_move2 == 0)
        {
            float moveInput_H = 0f;  // 横方向の入力値
            Debug.Log("移動できます");

            // プレイヤーが1Pか2Pかによって入力を受け取る
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

                // スティックが右に動いているか
                if (moveInput_H > 0.1f)
                {
                    Debug.Log("右に動いています");
                    // 右に動いたら右を向く
                    transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                }
                // スティックが左に動いているか
                else if (moveInput_H < -0.1f)
                {
                    Debug.Log("左に動いています");
                    // 左に動いたら左を向く
                    transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                }
                // スティックが動いていないか
                else
                {
                    Debug.Log("スティックは動いていません");
                }

                if (Mathf.Abs(moveInput_H) > 0.1f)  // スティックが動いた場合
                {
                    anime.SetBool("Run", true);
                }
                else  // スティックが動かない場合
                {
                    anime.SetBool("Run", false);
                }
            }

            if (CompareTag("Player2"))
            {
                moveInput_H = Input.GetAxis("L_Stick_H_2P");

                if (Input.GetButton("Jump_P2"))
                {
                    anime.SetBool("Jump", true);
                }
                else
                {
                    anime.SetBool("Jump", false);
                }

                // スティックが右に動いているか
                if (moveInput_H > 0.1f)
                {
                    Debug.Log("Player2 右に動いています");
                    // 右に動いたら右を向く
                    transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                }
                // スティックが左に動いているか
                else if (moveInput_H < -0.1f)
                {
                    Debug.Log("Player2 左に動いています");
                    // 左に動いたら左を向く
                    transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                }
                // スティックが動いていないか
                else
                {
                    Debug.Log("Player2 スティックは動いていません");
                }

                if (Mathf.Abs(moveInput_H) > 0.1f)  // スティックが動いた場合
                {
                    anime.SetBool("Run", true);
                }
                else  // スティックが動かない場合
                {
                    anime.SetBool("Run", false);
                }
            }

            // 横移動（Rigidbody2Dの速度を変更）
            if (Mathf.Abs(moveInput_H) > 0.1f) // スティックが動いているとき
            {
                rbody2D.velocity = new Vector2(moveInput_H * speed_H, rbody2D.velocity.y);
            }
            else // スティックが動いていないとき
            {
                if (isOnFrozenSurface)  // Frozenタグにいる場合だけ滑らせる
                {
                    // 横方向の速度を少しずつ減速させて滑る動きを実現
                    rbody2D.velocity = new Vector2(rbody2D.velocity.x * dragFactor, rbody2D.velocity.y);
                }
                else
                {
                    rbody2D.velocity = new Vector2(0, rbody2D.velocity.y); // 動かない場合は速度を0にする
                }
            }
        }
        else
        {
            // can_move が 1 の場合は移動しない (移動不可)
            Debug.Log("移動できません");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // "Frozen" タグに触れている場合、滑るフラグをオンにする
        if (collision.gameObject.CompareTag("Frozen"))
        {
            Debug.Log("氷に触れています");
            isOnFrozenSurface = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // "Frozen" タグから離れた場合、滑るフラグをオフにする
        if (collision.gameObject.CompareTag("Frozen"))
        {
            isOnFrozenSurface = false;
        }
    }
}
