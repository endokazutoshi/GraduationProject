using UnityEngine;

public class MultiDisplaySetup : MonoBehaviour
{
    void Start()
    {
        // �}���`�f�B�X�v���C���L�����m�F
        if (Display.displays.Length > 1)
        {
            // 2�Ԗڂ̃f�B�X�v���C��L���ɂ���
            Display.displays[1].Activate();
        }
    }
}
