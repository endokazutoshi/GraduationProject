using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // 移動速度の調整

    private void Update()
    {
        // 水平方向の入力を取得
        float moveInput = Input.GetAxis("Horizontal");

        // プレイヤーの移動処理
        transform.Translate(Vector3.right * moveInput * speed * Time.deltaTime);
    }
}

