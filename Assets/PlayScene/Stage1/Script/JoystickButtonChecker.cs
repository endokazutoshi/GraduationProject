using UnityEngine;

public class JoystickButtonChecker : MonoBehaviour
{
    void Update()
    {
        // 0����19�܂ł̃{�^���𒲂ׂ�
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown("joystick button " + i))
            {
                Debug.Log("Pressed Button: " + i);
            }
        }
    }
}
