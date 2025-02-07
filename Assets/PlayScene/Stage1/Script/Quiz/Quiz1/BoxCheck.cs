using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class BoxCheck : MonoBehaviour
{
    private QuizManager quizManager;

    public GameObject targetObject;
    public GameObject targetObject2;

    public GameObject openUI1;
    public GameObject openUI2;

    public GameObject targetPlayer1;  // �v���C���[1
    public GameObject targetPlayer2;  // �v���C���[2

    public float timerDuration = 2f;  // ����s�\�ɂ�����b��
    private float currentTime;

    public float forceMultiplier = 10f;  // ������΂��͂̔{��

    private Vector2 targetPosition1;  // �v���C���[1�̍ŏI�ړI�n
    private bool isBlown1 = false;  // �v���C���[1��������΂��ꂽ���ǂ���

    private Vector2 targetPosition2;  // �v���C���[2�̍ŏI�ړI�n
    private bool isBlown2 = false;  // �v���C���[2��������΂��ꂽ���ǂ���

    private float blowTime = 0f;    // ������΂��ɂ����鎞��
    float speedFactor = 20f;  // ������{�ɂ���i�����\�j
    bool canPlayer1 = false; // �v���C���[���G��Ă��邩�̊m�F
    bool canPlayer2 = false; // �v���C���[���G��Ă��邩�̊m�F

    public GameObject player1Text;  // �v���C���[1�p
    public GameObject player2Text;  // �v���C���[2�p
    public float textDisplayDuration = 2f;  // �e�L�X�g��\�����鎞��

    private Camera mainCamera;                      // �v���C���[1�p�J����
    private Camera secondCamera;                    // �v���C���[2�p�J����

    public AudioSource correctAudioSource;
    public AudioSource incorrectAudioSource;

    public AudioClip correctSound;
    public AudioClip incorrectSound;

    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
        targetObject.SetActive(false);
        targetObject2.SetActive(false);
        openUI1.SetActive(false);
        openUI2.SetActive(false);
        currentTime = 0f;  // ���������Ƀ^�C�}�[��0�ɐݒ肵�Ă���
        // ������Ԃł̓e�L�X�g���\���ɂ��Ă���
        if (player1Text != null) player1Text.SetActive(false);
        if (player2Text != null) player2Text.SetActive(false);

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

        // Display 1,2��L����

        // Display 2��L��

        if (Display.displays.Length > 0)
        {
            Display.displays[0].Activate(); // Display1
            Debug.Log("Display 1 Active: " + Display.displays[0].active);
        }
        if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate(); // Display2
            Debug.Log("Display 2 Active: " + Display.displays[1].active);
        }
        // UI�̃J�����ݒ�
        //SetUIForDisplay();
        Debug.Log("Display 0 active: " + Display.displays[0].active);
        Debug.Log("Display 1 active: " + Display.displays[1].active);

        if(correctAudioSource == null || incorrectAudioSource == null)
        {
            Debug.Log("�������A�s�������̂ǂ��炩���͗��������蓖�Ă��Ă��܂���");
        }


    }

    void Update()
    {
        // ������΂�����
        if (isBlown1)
        {
            targetPlayer1.transform.position = Vector2.Lerp(targetPlayer1.transform.position, targetPosition1, blowTime * Time.deltaTime);
            if (Vector2.Distance(targetPlayer1.transform.position, targetPosition1) < 0.1f)
            {
                isBlown1 = false;  // �v���C���[1�̐�����΂����I��
            }
        }

        if (isBlown2)
        {
            targetPlayer2.transform.position = Vector2.Lerp(targetPlayer2.transform.position, targetPosition2, blowTime * Time.deltaTime);
            if (Vector2.Distance(targetPlayer2.transform.position, targetPosition2) < 0.1f)
            {
                isBlown2 = false;  // �v���C���[2�̐�����΂����I��
            }
        }

        // ������΂����Ԃ�i�߂�
        blowTime += Time.deltaTime * speedFactor;

        // �^�C�}�[����������
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else if (currentTime <= 0)
        {
            TimerEnded();  // �^�C�}�[��0�ɂȂ�����ATimerEnded���Ăяo��
        }
    }

    public void CheckItem(GameObject item)
    {
        // ���݂̖����擾
        QuizManager.QuestionAnswerPair currentQuestion = quizManager.GetCurrentQuestion();

        if (currentQuestion != null)
        {
            // ���݂̖��̐����^�O���擾
            string correctAnswerTag = currentQuestion.correctAnswerTag;

            // �������ǂ������`�F�b�N
            if (item.CompareTag(correctAnswerTag))
            {
                Debug.Log("�����ł��I");
                CorrectAnswer();
            }
            else
            {
                Debug.Log("�s�����ł��I");

                // B�{�^����������Ă��āA���G��Ă���ꍇ�ɔ���
                if (canPlayer1 && Input.GetButtonDown("Y_Button_1P"))
                {
                    Debug.Log("Player 1's B�{�^����������܂����I");
                    IncorrectAnswer("Player1");
                }
                if (canPlayer2 && Input.GetButtonDown("Y_Button_2P"))
                {
                    Debug.Log("Player 2's B�{�^����������܂����I");
                    IncorrectAnswer("Player2");
                }
            }
        }
        else
        {
            Debug.LogError("���݂̖�肪����܂���");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �v���C���[1�̃^�O���m�F
        if (other.CompareTag("Player1"))
        {
            canPlayer1 = true;  // �v���C���[���G�ꂽ��B�{�^���������悤�ɂ���
            Debug.Log("�v���C���[1���I�u�W�F�N�g�ɐG��܂����I");
            player1Text.SetActive(true);
        }
        if (other.CompareTag("Player2"))
        {
            canPlayer2 = true;  // �v���C���[���G�ꂽ��B�{�^���������悤�ɂ���
            Debug.Log("�v���C���[2���I�u�W�F�N�g�ɐG��܂����I");
            player2Text.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // �v���C���[1�̃^�O���m�F
        if (other.CompareTag("Player1"))
        {
            canPlayer1 = false;  // �v���C���[���G�ꂽ��B�{�^���������悤�ɂ���
            Debug.Log("�v���C���[1���I�u�W�F�N�g���痣��܂����I");
            player1Text.SetActive(false);
        }
        if (other.CompareTag("Player2"))
        {
            canPlayer2 = false;  // �v���C���[���G�ꂽ��B�{�^���������悤�ɂ���
            Debug.Log("�v���C���[2���I�u�W�F�N�g���痣��܂����I");
            player2Text.SetActive(false);
        }
    }

    // UI�\�����3�b�ŏ������߂̃R���[�`��
    IEnumerator HideUIAfterDelay()
    {
        // 3�b�҂�
        yield return new WaitForSeconds(3f);

        // UI���\���ɂ���
        openUI1.SetActive(false);
        openUI2.SetActive(false);

    }

    void CorrectAnswer()
    {

        if (correctAudioSource != null && correctSound != null)
        {
            correctAudioSource.PlayOneShot(correctSound);
        }
        targetObject.SetActive(true);
        targetObject2.SetActive(true);
        openUI1.SetActive(true);
        openUI2.SetActive(true);
        Debug.Log("openUI1 active: " + openUI1.activeSelf);
        Debug.Log("openUI2 active: " + openUI2.activeSelf);


        // �R���[�`�����J�n����3�b���UI������
        StartCoroutine(HideUIAfterDelay());
    }

    void IncorrectAnswer(string playerTag)
    {
        Debug.Log("IncorrectAnswer�����s���܂�");

        // �e�v���C���[��PlayerMovement�R���|�[�l���g���擾
        PlayerMovement playerMovement1 = targetPlayer1.GetComponent<PlayerMovement>();
        PlayerMovement playerMovement2 = targetPlayer2.GetComponent<PlayerMovement>();

        if (playerTag == "Player1" && playerMovement1 != null)
        {
            Debug.Log("�v���C���[�P��������т܂�");
            // �v���C���[1���s�����Ȃ�ړ��𖳌���
            playerMovement1.can_move1 = 1;
            isBlown1 = true;

            // ������΂������Ƌ���������
            Vector2 forceDirection1 = -targetPlayer1.transform.right;  // �v���C���[1�̐�����΂�����
            float blowDistance = 5f;  // ������΂������i���j�b�g�j
            targetPosition1 = (Vector2)targetPlayer1.transform.position + forceDirection1 * blowDistance;
        }
        if (playerTag == "Player2" && playerMovement2 != null)
        {
            Debug.Log("�v���C���[2��������т܂�");
            // �v���C���[2���s�����Ȃ�ړ��𖳌���
            playerMovement2.can_move1 = 1;
            isBlown2 = true;

            // ������΂������Ƌ���������
            Vector2 forceDirection2 = -targetPlayer2.transform.right;  // �v���C���[2�̐�����΂�����
            float blowDistance = 5f;  // ������΂������i���j�b�g�j
            targetPosition2 = (Vector2)targetPlayer2.transform.position + forceDirection2 * blowDistance;
        }

        if (incorrectAudioSource != null && incorrectSound != null)
        {
            incorrectAudioSource.PlayOneShot(incorrectSound);
        }

        blowTime = 0f;  // ������΂��̎��Ԃ����Z�b�g
        currentTime = timerDuration;  // �^�C�}�[���J�n
        Debug.Log("�^�C�}�[�J�n: " + currentTime);
    }
    //void SetUIForDisplay()
    //{
    //    // openUI1��Canvas�ݒ�
    //    if (openUI1 != null)
    //    {
    //        Canvas canvas1 = openUI1.GetComponent<Canvas>();
    //        if (canvas1 != null)
    //        {
    //            canvas1.renderMode = RenderMode.ScreenSpaceCamera;
    //            canvas1.worldCamera = mainCamera;  // Display 1 �p�J������ݒ�
    //            canvas1.targetDisplay = 0;  // Display 1�ɕ\��
    //            Debug.Log("Canvas 1 targetDisplay: " + canvas1.targetDisplay);

    //        }
    //    }

    //    // openUI2��Canvas�ݒ�
    //    if (openUI2 != null)
    //    {
    //        Canvas canvas2 = openUI2.GetComponent<Canvas>();
    //        if (canvas2 != null)
    //        {
    //            canvas2.renderMode = RenderMode.ScreenSpaceCamera;
    //            canvas2.worldCamera = secondCamera;  // Display 2 �p�J������ݒ�
    //            canvas2.targetDisplay = 1;  // Display 2�ɕ\��
    //            Debug.Log("Canvas 2 targetDisplay: " + canvas2.targetDisplay);

    //        }
    //    }
       

    //}



    void TimerEnded()
    {
        PlayerMovement playerMovement1 = targetPlayer1.GetComponent<PlayerMovement>();
        PlayerMovement playerMovement2 = targetPlayer2.GetComponent<PlayerMovement>();

        if (playerMovement1 != null)
        {
            playerMovement1.can_move1 = 0;
        }
        if (playerMovement2 != null)
        {
            playerMovement2.can_move1 = 0;
        }

        Debug.Log("�^�C�}�[�I���B�ړ����ĊJ����܂����B");

        // �^�C�}�[�����Z�b�g
        currentTime = 0;  // �^�C�}�[�����Z�b�g
    }
}
