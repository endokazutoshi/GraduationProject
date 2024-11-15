using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int P1 = 1, P2 = 2;
    public int PlayerNumber;
    public float speed_H = 5f; // �ړ����x�̒���
    public float speed_V = 3f;
    Rigidbody rbody2D;

    private void Update()
    {
        if (PlayerNumber == P1)
        {
            // ���������̓��͂��擾
            float moveInput_H1 = Input.GetAxis("L_Stick_H_1P");
            float moveInput_V1 = Input.GetAxis("L_Stick_V_1P");

            // �v���C���[�̈ړ�����
            transform.Translate(Vector3.right * moveInput_H1 * speed_H * Time.deltaTime);
            //transform.Translate(Vector3.down * moveInput_V1 * speed_V * Time.deltaTime);
        }
        else if (PlayerNumber == P2)
        {
            float moveInput_H2 = Input.GetAxis("L_Stick_H_2P");
            
            if(Input.GetButton("L_Stick_V_2P"))
            {
                Jump();
            }

            transform.Translate(Vector3.right * moveInput_H2 * speed_H * Time.deltaTime);
           // transform.Translate(Vector3.down * moveInput_V2 * speed_V * Time.deltaTime);
        }
        

    }

    void Jump()
    {
        // ������ɗ͂������鎖�ŃW�����v����
        rbody2D.AddForce(Vector2.up * 300);
    }

}

