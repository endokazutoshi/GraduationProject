using UnityEngine;

public class Display1Only : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // MCamera（Display1用のカメラ）を取得
        mainCamera = GetComponent<Camera>();

        if (mainCamera != null)
        {
            // Display1（MCamera）には "Display2Only" のレイヤーを表示しない
            mainCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("Display2Only"));
        }
    }
}
