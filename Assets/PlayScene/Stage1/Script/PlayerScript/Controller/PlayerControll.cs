using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int can_move1 = 0;  // 'can_move' を public にして直接アクセス可能にする
    public int can_move2 = 0;
    public float speed_H = 5f; // 水平移動速度

    private Rigidbody2D rbody2D;

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
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
            }
            else if (CompareTag("Player2"))
            {
                moveInput_H = Input.GetAxis("L_Stick_H_2P");
            }

            // 横移動
            transform.Translate(Vector3.right * moveInput_H * speed_H * Time.deltaTime);
        }
        else
        {
            // can_move が 1 の場合は移動しない (移動不可)
            Debug.Log("移動できません");
        }
    }
}
