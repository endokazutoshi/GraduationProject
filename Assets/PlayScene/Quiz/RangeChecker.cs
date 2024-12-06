using UnityEngine;

public class RangeChecker : MonoBehaviour
{
    public string player1Tag = "Player1";           // �v���C���[1��Tag
    public string player2Tag = "Player2";           // �v���C���[2��Tag

    public GameObject rangeObject;                  // �͈͂��w�肷��I�u�W�F�N�g(Square)
    public GameObject[] imageObjectsPlayer1;        // �v���C���[1�p�摜�̔z��
    public GameObject[] imageObjectsPlayer2;        // �v���C���[2�p�摜�̔z��

    private Camera mainCamera;                      // �v���C���[1�p�J����
    private Camera secondCamera;                    // �v���C���[2�p�J����

    private Collider2D rangeCollider;               // �͈̓I�u�W�F�N�g��Collider2D

    private GameObject selectedImagePlayer1;        // �v���C���[1�p�ɑI�΂ꂽ�摜
    private GameObject selectedImagePlayer2;        // �v���C���[2�p�ɑI�΂ꂽ�摜


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
        HideAllImages(imageObjectsPlayer1);
        HideAllImages(imageObjectsPlayer2);

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

        // �v���C���[1�ƃv���C���[2�̉摜�\���𓝈ꂵ�����\�b�h�ŏ���
        HandlePlayerImageDisplay(player1Object, isPlayer1InRange, selectedImagePlayer1, ref mainCamera, 0, "Y_Button_1P");
        HandlePlayerImageDisplay(player2Object, isPlayer2InRange, selectedImagePlayer2, ref secondCamera, 1, "Y_Button_2P");
    }

    // ���ݑI�΂�Ă�����ԍ��Ɋ�Â��ĉ摜���X�V����
    public void SetCurrentQuestionObject(int player, GameObject questionObject)
    {
<<<<<<< HEAD
<<<<<<< HEAD
        // �v���C���[�����݂��Ȃ��ꍇ�͏����𒆎~
        if (playerObject == null) return;

        // �͈͓��Ń{�^���������ꂽ�ꍇ
        if (isPlayerInRange && Input.GetButtonDown(buttonName)) // �w�肳�ꂽ�{�^���������ꂽ�ꍇ
=======
        if (player == 1)
        {
            // �v���C���[1�p�̑I�΂ꂽ�摜���Z�b�g
            selectedImagePlayer1 = questionObject;
            Debug.Log($"�v���C���[1�̑I�΂ꂽ�摜: {selectedImagePlayer1.name}");
        }
        else if (player == 2)
        {
            // �v���C���[2�p�̑I�΂ꂽ�摜���Z�b�g
            selectedImagePlayer2 = questionObject;
            Debug.Log($"�v���C���[2�̑I�΂ꂽ�摜: {selectedImagePlayer2.name}");
        }
        else
        {
            Debug.LogError("�����ȃv���C���[�ԍ��ł��B");
        }
    }

    // �v���C���[���Ƃ̉摜�\������
    private void HandlePlayerImageDisplay(GameObject playerObject, bool isPlayerInRange, GameObject selectedImage, ref Camera camera, int displayIndex, string buttonName)
    {
        if (playerObject == null || selectedImage == null) return;

        bool isImageVisible = selectedImage.activeSelf;

        // �v���C���[���͈͓��ɂ��đΉ��{�^���������ꂽ�ꍇ
        if (isPlayerInRange && Input.GetButtonDown(buttonName))
>>>>>>> origin/kudo
=======
        if (player == 1)
>>>>>>> parent of a6c76c3 (修正中)
        {
            // �v���C���[1�p�̑I�΂ꂽ�摜���Z�b�g
            selectedImagePlayer1 = questionObject;
            Debug.Log($"�v���C���[1�̑I�΂ꂽ�摜: {selectedImagePlayer1.name}");
        }
        else if (player == 2)
        {
            // �v���C���[2�p�̑I�΂ꂽ�摜���Z�b�g
            selectedImagePlayer2 = questionObject;
            Debug.Log($"�v���C���[2�̑I�΂ꂽ�摜: {selectedImagePlayer2.name}");
        }
        else
        {
            Debug.LogError("�����ȃv���C���[�ԍ��ł��B");
        }�@

        // �摜���\���ɐݒ�
        HideAllImages(imageObjectsPlayer1);
        HideAllImages(imageObjectsPlayer2);
    }

    // �v���C���[���Ƃ̉摜�\������
    private void HandlePlayerImageDisplay(GameObject playerObject, bool isPlayerInRange, GameObject selectedImage, ref Camera camera, int displayIndex, string buttonName)
    {
        if (playerObject == null || selectedImage == null) return;

        bool isImageVisible = selectedImage.activeSelf;

        // �v���C���[���͈͓��ɂ��đΉ��{�^���������ꂽ�ꍇ
        if (isPlayerInRange && Input.GetButtonDown(buttonName))
        {
            ToggleImage(selectedImage, ref isImageVisible);
            if (camera != null)
            {
                camera.targetDisplay = displayIndex; // �Ή�����f�B�X�v���C�ɐ؂�ւ�
            }
        }
        // �v���C���[���͈͊O�ɏo���ꍇ�A�摜���\���ɂ���
        else if (!isPlayerInRange && isImageVisible)
        {
            HideAllImages(new GameObject[] { selectedImage });
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

    // ���ׂẲ摜���\���ɂ���
    private void HideAllImages(GameObject[] imageObjects)
    {
        foreach (var imageObject in imageObjects)
        {
            if (imageObject != null)
            {
                imageObject.SetActive(false);
            }
        }
    }
}
