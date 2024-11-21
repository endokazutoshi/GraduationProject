using UnityEngine;

public class RangeChecker : MonoBehaviour
{
    public Transform player1;           // �v���C���[1��Transform
    public Transform player2;           // �v���C���[2��Transform
    public Vector2 rangeCenter;         // �͈͂̒��S���W
    public Vector2 rangeSize = new Vector2(5f, 5f); // �͈͂̃T�C�Y
    public GameObject imageObject;      // �\������摜�I�u�W�F�N�g

    private bool isImageVisible = false; // �摜�����ݕ\������Ă��邩

    void Start()
    {
        // �摜���\���ɐݒ�
        if (imageObject != null)
        {
            imageObject.SetActive(false);
        }
    }

    void Update()
    {
        // �v���C���[1�ƃv���C���[2���͈͓��ɂ��邩���m�F
        bool isPlayer1InRange = IsPlayerInRange(player1);
        bool isPlayer2InRange = IsPlayerInRange(player2);

        // �v���C���[1���͈͓��ɂ��ăX�y�[�X�L�[���������ꍇ
        if (isPlayer1InRange && Input.GetButtonDown("B_Button_1P"))
        {
            ToggleImage();
        }

        // �v���C���[2���͈͓��ɂ��āuB�v�{�^���i�J�X�^�}�C�Y�\�j���������ꍇ
        if (isPlayer2InRange && Input.GetButtonDown("B_Button_2P"))
        {
            ToggleImage();
        }
    }

    // �w�肳�ꂽ�v���C���[���͈͓��ɂ��邩���肷��
    private bool IsPlayerInRange(Transform player)
    {
        if (player == null) return false;

        Vector2 playerPos = new Vector2(player.position.x, player.position.y);

        // �͈͂̍����ƉE����v�Z
        Vector2 bottomLeft = rangeCenter - rangeSize / 2;
        Vector2 topRight = rangeCenter + rangeSize / 2;

        // �v���C���[�̈ʒu���͈͓�������
        return playerPos.x >= bottomLeft.x && playerPos.x <= topRight.x &&
               playerPos.y >= bottomLeft.y && playerPos.y <= topRight.y;
    }

    // �摜�̕\���Ɣ�\����؂�ւ���
    private void ToggleImage()
    {
        if (imageObject != null)
        {
            isImageVisible = !isImageVisible; // �\����Ԃ�؂�ւ���
            imageObject.SetActive(isImageVisible);
        }
    }

    // �͈͂��V�[���r���[�ŉ�������i�f�o�b�O�p�j
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(rangeCenter, rangeSize);
    }
}
