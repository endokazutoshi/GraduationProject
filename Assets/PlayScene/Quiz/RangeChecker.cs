using UnityEngine;
using System.Collections;

public class RangeChecker : MonoBehaviour
{
    public string player1Tag = "Player1";           // �v���C���[1��Tag
    public string player2Tag = "Player2";           // �v���C���[2��Tag

    public GameObject rangeObject;                  // �͈͂��w�肷��I�u�W�F�N�g(Square)
    public GameObject imageObjectPlayer1;           // �v���C���[1�p�摜
    public GameObject imageObjectPlayer2;           // �v���C���[2�p�摜

    private Camera mainCamera;                      // �v���C���[1�p�J����
    private Camera secondCamera;                    // �v���C���[2�p�J����

    private bool isPlayer1ImageVisible = false;     // �v���C���[1�摜�̕\�����
    private bool isPlayer2ImageVisible = false;     // �v���C���[2�摜�̕\�����

    private Collider2D rangeCollider;               // �͈̓I�u�W�F�N�g��Collider2D

    void Start()
    {
        // `rangeObject`����Collider2D���擾
        if (rangeObject != null)
        {
            rangeCollider = rangeObject.GetComponent<Collider2D>();
            if (rangeCollider == null)
            {
                Debug.LogError("�͈̓I�u�W�F�N�g��Collider2D���ݒ肳��Ă��܂���B");
            }
        }
        else
        {
            Debug.LogError("�͈̓I�u�W�F�N�g���ݒ肳��Ă��܂���B");
        }

        // �^�O�ŃJ������T���Đݒ�
        GameObject cameraObject = GameObject.FindGameObjectWithTag("MCamera");
        if (cameraObject != null)
        {
            mainCamera = cameraObject.GetComponent<Camera>();
        }

        GameObject cameraObject2 = GameObject.FindGameObjectWithTag("SCamera");
        if (cameraObject2 != null)
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
            Debug.Log("Display 2 Active: " + Display.displays[1].active);
        }
    }

    void Update()
    {
        // �v���C���[1�ƃv���C���[2��Tag���g���Ĕ͈͓��ɂ��邩���m�F
        GameObject player1Object = GameObject.FindGameObjectWithTag(player1Tag);
        GameObject player2Object = GameObject.FindGameObjectWithTag(player2Tag);

        bool isPlayer1InRange = IsPlayerInRange(player1Object);
        bool isPlayer2InRange = IsPlayerInRange(player2Object);

        // �v���C���[1���͈͓��ɂ��đΉ��{�^���������ꂽ�ꍇ
        if (isPlayer1InRange && Input.GetButtonDown("Y_Button_1P"))
        {
            ToggleImage(imageObjectPlayer1, ref isPlayer1ImageVisible);
            if (mainCamera != null)
            {
                mainCamera.targetDisplay = 0; // Player 1�̉摜��Display 1�ɕ\��
            }
        }
        // �v���C���[1���͈͊O�ɏo���ꍇ�A�摜���\���ɂ���
        else if (!isPlayer1InRange && isPlayer1ImageVisible)
        {
            ToggleImage(imageObjectPlayer1, ref isPlayer1ImageVisible); // ��\���ɂ���
        }

        // �v���C���[2���͈͓��ɂ��đΉ��{�^���������ꂽ�ꍇ
        if (isPlayer2InRange && Input.GetButtonDown("Y_Button_2P"))
        {
            ToggleImage(imageObjectPlayer2, ref isPlayer2ImageVisible);
            if (secondCamera != null)
            {
                StartCoroutine(SwitchToSecondDisplay());
            }
        }
        // �v���C���[2���͈͊O�ɏo���ꍇ�A�摜���\���ɂ���
        else if (!isPlayer2InRange && isPlayer2ImageVisible)
        {
            ToggleImage(imageObjectPlayer2, ref isPlayer2ImageVisible); // ��\���ɂ���
        }
    }

    // �w�肳�ꂽ�v���C���[���͈͓��ɂ��邩���肷��
    private bool IsPlayerInRange(GameObject playerObject)
    {
        if (playerObject == null || rangeCollider == null) return false;

        // �v���C���[�̈ʒu���擾���Ĕ͈͓������`�F�b�N
        bool isInRange = rangeCollider.bounds.Contains(playerObject.transform.position);
        Debug.Log($"Player {playerObject.name} is in range: {isInRange}");
        return isInRange;
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
        if (rangeObject != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(rangeObject.transform.position, rangeObject.transform.localScale);
        }
    }

    // 1�t���[���x������Display 2�ɐ؂�ւ���R���[�`��
    private IEnumerator SwitchToSecondDisplay()
    {
        yield return null; // 1�t���[���x��
        secondCamera.targetDisplay = 1; // Display 2�ɃJ������ݒ�
        Debug.Log("Display 2�ɐ؂�ւ�����");
    }
}
