using UnityEngine;

public class MultiDisplayCameraAdjuster : MonoBehaviour
{
    public Camera player1Camera;  // Player1のカメラ
    public Camera player2Camera;  // Player2のカメラ

    void Start()
    {
        // ディスプレイの有効化（Display2が存在する場合）
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();  // Display2を有効化

        // アスペクト比設定 (横20マス、縦9マス)
        AdjustCamera(player1Camera, 20f / 9f, 0); // Player1 カメラ設定
        AdjustCamera(player2Camera, 20f / 9f, 1); // Player2 カメラ設定
    }

    void AdjustCamera(Camera camera, float targetAspect, int displayIndex)
    {
        // 対応するディスプレイに設定
        camera.targetDisplay = displayIndex;

        // アスペクト比の調整
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            // 画面が縦長の場合、中央に調整
            camera.rect = new Rect(0, (1.0f - scaleHeight) / 2.0f, 1.0f, scaleHeight);
        }
        else
        {
            // 画面が横長の場合、中央に調整
            float scaleWidth = 1.0f / scaleHeight;
            camera.rect = new Rect((1.0f - scaleWidth) / 2.0f, 0, scaleWidth, 1.0f);
        }
    }
}
