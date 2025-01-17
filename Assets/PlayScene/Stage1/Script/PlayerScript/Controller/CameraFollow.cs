using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // �v���C���[��Transform
    public float offsetX = 0f;
    public float offsetY = 0f;

    void LateUpdate()
    {
        // �v���C���[�̈ʒu�ɃJ������Ǐ]�����邪�A��]�͓K�p���Ȃ�
        transform.position = new Vector3(player.position.x+offsetX, player.position.y+offsetY, transform.position.z);
        // �J�����̉�]�͂��̂܂�
        transform.rotation = Quaternion.Euler(0, 0, 0);  // �J�����̉�]�����b�N
    }
}
