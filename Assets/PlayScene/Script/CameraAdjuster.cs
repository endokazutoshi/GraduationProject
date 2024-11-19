using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    public Transform player;         // �v���C���[��Transform
    public Vector3 cameraOffset;     // �J�����̈ʒu�I�t�Z�b�g�i�v���C���[�Ƃ̑��Έʒu�j
    public Vector2 minBound;         // �J�����̈ړ��͈͂̍ŏ��l (X, Y)
    public Vector2 maxBound;         // �J�����̈ړ��͈͂̍ő�l (X, Y)

    void Start()
    {
        float targetAspect = 20f / 9f; // ��20�}�X�A�c9�}�X�̃A�X�y�N�g��
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            Camera.main.rect = new Rect(0, (1.0f - scaleHeight) / 2.0f, 1.0f, scaleHeight);
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Camera.main.rect = new Rect((1.0f - scaleWidth) / 2.0f, 0, scaleWidth, 1.0f);
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // �v���C���[�̈ʒu�ɃJ������Ǐ]������
            Vector3 targetPosition = player.position + cameraOffset;

            // �͈͂𐧌�����
            targetPosition.x = Mathf.Clamp(targetPosition.x, minBound.x, maxBound.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minBound.y, maxBound.y);

            // �J�����̈ʒu���X�V
            transform.position = targetPosition;
        }
    }
}
