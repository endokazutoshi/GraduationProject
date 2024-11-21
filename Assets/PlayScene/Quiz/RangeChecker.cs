using UnityEngine;
using System.Collections;

public class RangeChecker : MonoBehaviour
{
    public Transform player1;               // �v���C���[1��Transform
    public Transform player2;               // �v���C���[2��Transform
    public Vector2 rangeCenter;             // �͈͂̒��S���W
    public Vector2 rangeSize = new Vector2(5f, 5f); // �͈͂̃T�C�Y

    public GameObject imageObjectPlayer1;   // �v���C���[1�p�摜
    public GameObject imageObjectPlayer2;   // �v���C���[2�p�摜

    private Camera mainCamera; // �v���C���[1�p�J����
    private Camera secondCamera; // �v���C���[2�p�J����

    private bool isPlayer1ImageVisible = false; // �v���C���[1�摜�̕\�����
    private bool isPlayer2ImageVisible = false; // �v���C���[2�摜�̕\�����

    void Start()
    {
        // �^�O�ŃJ������T���Đݒ�
        GameObject cameraObject = GameObject.FindGameObjectWithTag("MCamera");

        if (cameraObject.CompareTag("MCamera"))
        {
            mainCamera = cameraObject.GetComponent<Camera>();
        }
        GameObject cameraObject2 = GameObject.FindGameObjectWithTag("SCamera");

        if (cameraObject2.CompareTag("SCamera"))
        {
            secondCamera = cameraObject2.GetComponent<Camera>();
        }

        // �摜���\���ɐݒ�
        if (imageObjectPlayer1 != null) imageObjectPlayer1.SetActive(false);
        if (imageObjectPlayer2 != null) imageObjectPlayer2.SetActive(false);

        // Display 2��L����
        if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate();
            Debug.Log("Display 2 Active: " + Display.displays[1].active); // �C��: isActive -> active
        }
    }

    void Update()
    {
        // �v���C���[1�ƃv���C���[2���͈͓��ɂ��邩���m�F
        bool isPlayer1InRange = IsPlayerInRange(player1);
        bool isPlayer2InRange = IsPlayerInRange(player2);

        // �v���C���[1���͈͓��ɂ��đΉ��{�^���������ꂽ�ꍇ
        if (isPlayer1InRange && Input.GetButtonDown("B_Button_1P"))
        {
            ToggleImage(imageObjectPlayer1, ref isPlayer1ImageVisible);
            if (mainCamera != null)
            {
                mainCamera.targetDisplay = 0; // Player 1�̉摜��Display 1�ɕ\��
            }
        }

        // �v���C���[2���͈͓��ɂ��đΉ��{�^���������ꂽ�ꍇ
        if (isPlayer2InRange && Input.GetButtonDown("B_Button_2P"))
        {
            ToggleImage(imageObjectPlayer2, ref isPlayer2ImageVisible);
            if (secondCamera != null)
            {
                // �����x�����ăf�B�X�v���C��؂�ւ�
                StartCoroutine(SwitchToSecondDisplay());
            }
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
    private void ToggleImage(GameObject imageObject, ref bool isVisible)
    {
        if (imageObject != null)
        {
            isVisible = !isVisible; // �\����Ԃ�؂�ւ���
            imageObject.SetActive(isVisible);
        }
    }

    // �͈͂��V�[���r���[�ŉ�������i�f�o�b�O�p�j
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(rangeCenter, rangeSize);
    }

    // 1�t���[���x������Display 2�ɐ؂�ւ���R���[�`��
    private IEnumerator SwitchToSecondDisplay()
    {
        yield return null; // 1�t���[���x��
        secondCamera.targetDisplay = 1; // Display 2�ɃJ������ݒ�
        Debug.Log("Display 2�ɐ؂�ւ�����");
    }
}
