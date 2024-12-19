using UnityEngine;

public class JoystickButtonChecker : MonoBehaviour
{
    void Update()
    {
        // 0‚©‚ç19‚Ü‚Å‚Ìƒ{ƒ^ƒ“‚ð’²‚×‚é
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown("joystick button " + i))
            {
                Debug.Log("Pressed Button: " + i);
            }
        }
    }
}
