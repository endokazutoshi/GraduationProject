using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // �ړ����x�̒���

    private void Update()
    {
        // ���������̓��͂��擾
        float moveInput = Input.GetAxis("Horizontal");

        // �v���C���[�̈ړ�����
        transform.Translate(Vector3.right * moveInput * speed * Time.deltaTime);
    }
}

