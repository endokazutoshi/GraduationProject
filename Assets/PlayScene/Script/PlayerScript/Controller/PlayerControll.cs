using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed_H = 5f; // 水平移動速度

    public int can_move = 0; // 操作をできなくするための変数 (0: 移動可能, 1: 移動不可)

    private Rigidbody2D rbody2D;

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // can_move が 1 の場合は移動を無効にする
        if (can_move == 0)
        {
            float moveInput_H = 0f;  // 横方向の入力値

            // プレイヤーが1Pか2Pかによって入力を受け取る
            if (CompareTag("Player1"))
            {
                moveInput_H = Input.GetAxis("L_Stick_H_1P");
            }
            else if (CompareTag("Player2"))
            {
                moveInput_H = Input.GetAxis("L_Stick_H_2P");
            }

            // 横移動
            transform.Translate(Vector3.right * moveInput_H * speed_H * Time.deltaTime);
        }
        // can_move が 1 の場合は移動処理をしない (移動不可)
    }
}
