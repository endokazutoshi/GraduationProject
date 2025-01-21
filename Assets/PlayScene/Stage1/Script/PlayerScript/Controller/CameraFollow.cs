using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // プレイヤーのTransform
    public float offsetX = 0f;
    public float offsetY = 0f;

    void LateUpdate()
    {
        // プレイヤーの位置にカメラを追従させるが、回転は適用しない
        transform.position = new Vector3(player.position.x+offsetX, player.position.y+offsetY, transform.position.z);
        // カメラの回転はそのまま
        transform.rotation = Quaternion.Euler(0, 0, 0);  // カメラの回転をロック
    }
}
