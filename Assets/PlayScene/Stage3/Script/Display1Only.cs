using UnityEngine;

public class Display1Only : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // MCamera�iDisplay1�p�̃J�����j���擾
        mainCamera = GetComponent<Camera>();

        if (mainCamera != null)
        {
            // Display1�iMCamera�j�ɂ� "Display2Only" �̃��C���[��\�����Ȃ�
            mainCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("Display2Only"));
        }
    }
}
