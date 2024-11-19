using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    public Transform player;         // プレイヤーのTransform
    public Vector3 cameraOffset;     // カメラの位置オフセット（プレイヤーとの相対位置）
    public Vector2 minBound;         // カメラの移動範囲の最小値 (X, Y)
    public Vector2 maxBound;         // カメラの移動範囲の最大値 (X, Y)

    void Start()
    {
        float targetAspect = 20f / 9f; // 横20マス、縦9マスのアスペクト比
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            Camera.main.rect = new Rect(0, (1.0f - scaleHeight) / 2.0f, 1.0f, scaleHeight);
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Camera.main.rect = new Rect((1.0f - scaleWidth) / 2.0f, 0, scaleWidth, 1.0f);
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // プレイヤーの位置にカメラを追従させる
            Vector3 targetPosition = player.position + cameraOffset;

            // 範囲を制限する
            targetPosition.x = Mathf.Clamp(targetPosition.x, minBound.x, maxBound.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minBound.y, maxBound.y);

            // カメラの位置を更新
            transform.position = targetPosition;
        }
    }
}
