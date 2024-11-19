using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    private Rigidbody2D rbody2D;

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // プレイヤー1の場合
        if (CompareTag("Player1"))
        {
            // プレイヤー1がジャンプボタンを押したら
            if (Input.GetButtonDown("A_Button_1P"))
            {
                Jump(); // プレイヤー1のジャンプ処理
            }
        }
        // プレイヤー2の場合
        else if (CompareTag("Player2"))
        {
            // プレイヤー2がジャンプボタンを押したら
            if (Input.GetButtonDown("A_Button_2P"))
            {
                Jump(); // プレイヤー2のジャンプ処理
            }
        }
    }

    void Jump()
    {
        if (rbody2D != null)
        {
            rbody2D.AddForce(Vector2.up * 300); // ジャンプ力の調整
        }
        else
        {
            Debug.LogError("Rigidbody2Dがアタッチされていません！");
        }
    }
}
