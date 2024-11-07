using UnityEngine;

public class MultiDisplaySetup : MonoBehaviour
{
    void Start()
    {
        // マルチディスプレイが有効か確認
        if (Display.displays.Length > 1)
        {
            // 2番目のディスプレイを有効にする
            Display.displays[1].Activate();
        }
    }
}
