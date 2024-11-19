using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int PlayerNumber;
    public float speed_H = 5f; // …•½ˆÚ“®‘¬“x
    private Rigidbody2D rbody2D;

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveInput_H = 0f;

        if (PlayerNumber == 1)
        {
            moveInput_H = Input.GetAxis("L_Stick_H_1P");
        }
        else if (PlayerNumber == 2)
        {
            moveInput_H = Input.GetAxis("L_Stick_H_2P");
        }

        // ‰¡ˆÚ“®
        transform.Translate(Vector3.right * moveInput_H * speed_H * Time.deltaTime);
    }
}
