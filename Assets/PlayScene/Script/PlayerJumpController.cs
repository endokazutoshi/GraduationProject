using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    public int PlayerNumber;
    private Rigidbody2D rbody2D;

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (PlayerNumber == 1)
        {
            if (Input.GetButtonDown("A_Button_1P"))
            {
                Jump(); // プレイヤー1のジャンプ処理
            }
        }
        else if (PlayerNumber == 2)
        {
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
