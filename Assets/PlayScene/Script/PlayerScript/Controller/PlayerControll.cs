using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed_H = 5f; // …•½ˆÚ“®‘¬“x
    private Rigidbody2D rbody2D;

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moveInput_H = 0f;

        if (CompareTag("Player1"))
        {
            moveInput_H = Input.GetAxis("L_Stick_H_1P");
        }
        else if (CompareTag("Player2"))
        {
            moveInput_H = Input.GetAxis("L_Stick_H_2P");
        }

        // ‰¡ˆÚ“®
        transform.Translate(Vector3.right * moveInput_H * speed_H * Time.deltaTime);
    }
}
