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
        // rangeObject���ݒ肳��Ă��邩�m�F���ACollider2D���擾
        if (rangeObject != null)
        {
            rangeCollider = rangeObject.GetComponent<Collider2D>(); // Collider2D���擾
            if (rangeCollider == null)
            {
                Debug.LogError("�͈̓I�u�W�F�N�g��Collider2D���ݒ肳��Ă��܂���B"); // Collider2D���ݒ肳��Ă��Ȃ��ꍇ�ɃG���[�\��
            }
        }
        else
        {
            Debug.LogError("�͈̓I�u�W�F�N�g���ݒ肳��Ă��܂���B"); // rangeObject���ݒ肳��Ă��Ȃ��ꍇ�ɃG���[�\��
        }

        // �^�O�ŃJ������T���Đݒ�
        GameObject cameraObject = GameObject.FindGameObjectWithTag("MCamera"); // "MCamera"�Ƃ����^�O�̂����I�u�W�F�N�g������
        if (cameraObject != null)
        {
            mainCamera = cameraObject.GetComponent<Camera>(); // ���������J�����I�u�W�F�N�g��Camera�R���|�[�l���g���擾
        }

        GameObject cameraObject2 = GameObject.FindGameObjectWithTag("SCamera"); // "SCamera"�Ƃ����^�O�̂����I�u�W�F�N�g������
        if (cameraObject2 != null)
        {
            secondCamera = cameraObject2.GetComponent<Camera>(); // ���������J�����I�u�W�F�N�g��Camera�R���|�[�l���g���擾
        }

        // �摜���\���ɐݒ�
        HideAllImages(imageObjectsPlayer1); // �v���C���[1�̉摜�����ׂĔ�\��
        HideAllImages(imageObjectsPlayer2); // �v���C���[2�̉摜�����ׂĔ�\��

        // 2�ڂ̃f�B�X�v���C�����݂���ꍇ�A�f�B�X�v���C��L����
        if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate(); // 2�Ԗڂ̃f�B�X�v���C��L����
            Debug.Log("Display 2 Active: " + Display.displays[1].active); // �f�B�X�v���C���L�����ǂ�����\��
        }
    }

    void Update()
    {
        // �v���C���[1�͈͓̔��`�F�b�N�Ə���
        GameObject player1Object = GameObject.FindGameObjectWithTag(player1Tag); // �v���C���[1���^�O�Ō���
        bool isPlayer1InRange = IsPlayerInRange(player1Object); // �v���C���[1���͈͓��ɂ��邩����
        ProcessPlayerInput(
            player1Object, // �v���C���[1�̃I�u�W�F�N�g
            ref selectedImagePlayer1, // �v���C���[1�̑I�΂ꂽ�摜
            imageObjectsPlayer1, // �v���C���[1�̉摜�z��
            ref mainCamera, // �v���C���[1�p�J����
            0, // �v���C���[1�p�̃f�B�X�v���C�C���f�b�N�X
            "Y_Button_1P", // �v���C���[1�p�̃{�^����
            isPlayer1InRange // �v���C���[1���͈͓��ɂ��邩�̏��
        );

        // �v���C���[2�͈͓̔��`�F�b�N�Ə���
        GameObject player2Object = GameObject.FindGameObjectWithTag(player2Tag); // �v���C���[2���^�O�Ō���
        bool isPlayer2InRange = IsPlayerInRange(player2Object); // �v���C���[2���͈͓��ɂ��邩����
        ProcessPlayerInput(
            player2Object, // �v���C���[2�̃I�u�W�F�N�g
            ref selectedImagePlayer2, // �v���C���[2�̑I�΂ꂽ�摜
            imageObjectsPlayer2, // �v���C���[2�̉摜�z��
            ref secondCamera, // �v���C���[2�p�J����
            1, // �v���C���[2�p�̃f�B�X�v���C�C���f�b�N�X
            "Y_Button_2P", // �v���C���[2�p�̃{�^����
            isPlayer2InRange // �v���C���[2���͈͓��ɂ��邩�̏��
        );
    }

    // �v���C���[���͂��������郁�\�b�h
    private void ProcessPlayerInput(
        GameObject playerObject, // �v���C���[�̃I�u�W�F�N�g
        ref GameObject selectedImage, // �I�΂ꂽ�摜
        GameObject[] imageObjects, // �摜�z��
        ref Camera camera, // �J����
        int displayIndex, // �f�B�X�v���C�C���f�b�N�X
        string buttonName, // �{�^����
        bool isPlayerInRange // �v���C���[���͈͓��ɂ��邩
    )
    {
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
        {
            Debug.Log($"{playerObject.name} ���͈͓��� {buttonName} �������܂����B");

            // �摜�������_���őI�����ĕ\��
            // �摜�������_���őI�����ĕ\��
            if (selectedImage == null)
            {
                selectedImage = GetRandomImage(imageObjects); // �܂��摜���I�΂�Ă��Ȃ���΃����_���ɑI��
            }

            if (selectedImage != null)
            {
                // QuizManager�̖��z�񂩂烉���_���ɖ��ԍ���I��
                int randomQuestionIndex = Random.Range(0, QuizManager.Instance.questionAnswerPairs.Length);  // �����_���ȃC���f�b�N�X���擾
                int questionNumber = QuizManager.Instance.questionAnswerPairs[randomQuestionIndex].questionNumber;  // �����_���Ȗ��ԍ����擾

                // QuizManager�ɖ��ԍ���n��
                QuizManager.Instance.SetQuestion(questionNumber);  // QuizManager�̃C���X�^���X���g���Ė��ԍ���ݒ�

                bool isImageVisible = selectedImage.activeSelf; // ���݂̉摜�̕\����Ԃ��擾
                ToggleImage(selectedImage, ref isImageVisible); // �摜�̕\��/��\����؂�ւ�
            }



            // �J�����̃^�[�Q�b�g�f�B�X�v���C��ݒ�
            if (camera != null)
            {
                camera.targetDisplay = displayIndex; // �w�肳�ꂽ�f�B�X�v���C�C���f�b�N�X�ɃJ������ݒ�
            }
        }
    }

    // �v���C���[���͈͓��ɂ��邩�m�F���郁�\�b�h
    private bool IsPlayerInRange(GameObject playerObject)
    {
        if (playerObject == null || rangeCollider == null) return false; // �v���C���[�����݂��Ȃ��A�܂��͔͈̓I�u�W�F�N�g���ݒ肳��Ă��Ȃ��ꍇ�͔͈͊O

        return rangeCollider.bounds.Contains(playerObject.transform.position); // �v���C���[�̈ʒu���͈͓��ɂ��邩���m�F
    }

    // �摜�̕\��/��\����؂�ւ��郁�\�b�h
    private void ToggleImage(GameObject imageObject, ref bool isVisible)
    {
        if (imageObject != null)
        {
            isVisible = !isVisible; // �\����Ԃ𔽓]
            imageObject.SetActive(isVisible); // �摜�̕\��/��\����ݒ�
        }
    }

    // ���ׂẲ摜���\���ɂ��郁�\�b�h
    private void HideAllImages(GameObject[] imageObjects)
    {
        foreach (var imageObject in imageObjects) // �z����̂��ׂẲ摜�ɑ΂���
        {
            if (imageObject != null)
            {
                imageObject.SetActive(false); // �摜���\���ɂ���
            }
        }
    }

    // �����_���ɔ�\���̉摜��I�ԃ��\�b�h
    private GameObject GetRandomImage(GameObject[] imageObjects)
    {
        foreach (var imageObject in imageObjects)
        {
            if (imageObject != null && !imageObject.activeSelf) // �摜����\���̏ꍇ
            {
                return imageObject; // ��\���̉摜��Ԃ�
            }
        }
        return null; // ��\���̉摜���Ȃ����null��Ԃ�
    }
}
