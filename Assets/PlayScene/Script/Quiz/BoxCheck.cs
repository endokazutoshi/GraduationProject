using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    private QuizManager quizManager;

    public GameObject targetObject;
    public GameObject targetObject2;

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
    bool canPlayer1 = false;//�v���C���[���G��Ă��邩�̊m�F
    bool canPlayer2 = false;//�v���C���[���G��Ă��邩�̊m�F

    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
        targetObject.SetActive(false);
        targetObject2.SetActive(false);
        currentTime = 0f;  // ���������Ƀ^�C�}�[��0�ɐݒ肵�Ă���
    }

    void Update()
    {
        // ������΂�����
        if (isBlown1)
        {
            // �v���C���[1�𐁂���΂�
            targetPlayer1.transform.position = Vector2.Lerp(targetPlayer1.transform.position, targetPosition1, blowTime * Time.deltaTime);
            // �ړI�n�ɓ��B������ړ����~
            if (Vector2.Distance(targetPlayer1.transform.position, targetPosition1) < 0.1f)
            {
                isBlown1 = false;  // �v���C���[1�̐�����΂����I��
            }
        }
        if (isBlown2)
        {
            // �v���C���[2�𐁂���΂�
            targetPlayer2.transform.position = Vector2.Lerp(targetPlayer2.transform.position, targetPosition2, blowTime * Time.deltaTime);
            // �ړI�n�ɓ��B������ړ����~
            if (Vector2.Distance(targetPlayer2.transform.position, targetPosition2) < 0.1f)
            {
                isBlown2 = false;  // �v���C���[2�̐�����΂����I��
            }
        }



        // ������΂����Ԃ�i�߂�
        blowTime += Time.deltaTime * speedFactor;  // speedFactor���|���đ����i�s������

        // �^�C�}�[����������
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;  // �^�C�}�[������
                                            // Debug.Log("�^�C�}�[�c�莞��: " + currentTime);  // �f�o�b�O���O�Ń^�C�}�[�c�莞�Ԃ�\��
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
            // objectPlayer = other.gameObject;  // �G�ꂽ�v���C���[�I�u�W�F�N�g��ݒ�
        }
        if (other.CompareTag("Player2"))
        {
            canPlayer2 = true;  // �v���C���[���G�ꂽ��B�{�^���������悤�ɂ���
            Debug.Log("�v���C���[2���I�u�W�F�N�g�ɐG��܂����I");
            // objectPlayer = other.gameObject;  // �G�ꂽ�v���C���[�I�u�W�F�N�g��ݒ�
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        // �v���C���[1�̃^�O���m�F
        if (other.CompareTag("Player1"))
        {
            canPlayer1 = false;  // �v���C���[���G�ꂽ��B�{�^���������悤�ɂ���
            Debug.Log("�v���C���[1���I�u�W�F�N�g�ɐG��܂����I");
            // objectPlayer = other.gameObject;  // �G�ꂽ�v���C���[�I�u�W�F�N�g��ݒ�
        }
        if (other.CompareTag("Player2"))
        {
            canPlayer2 = false;  // �v���C���[���G�ꂽ��B�{�^���������悤�ɂ���
            Debug.Log("�v���C���[2���I�u�W�F�N�g�ɐG��܂����I");
            // objectPlayer = other.gameObject;  // �G�ꂽ�v���C���[�I�u�W�F�N�g��ݒ�
        }
    }
    void CorrectAnswer()
    {
        targetObject.SetActive(true);
        targetObject2.SetActive(true);
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
            playerMovement1.can_move = 1;
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
            playerMovement2.can_move = 1;
            isBlown2 = true;

            // ������΂������Ƌ���������
            Vector2 forceDirection2 = -targetPlayer2.transform.right;  // �v���C���[2�̐�����΂�����
            float blowDistance = 5f;  // ������΂������i���j�b�g�j
            targetPosition2 = (Vector2)targetPlayer2.transform.position + forceDirection2 * blowDistance;
        }



        blowTime = 0f;  // ������΂��̎��Ԃ����Z�b�g

        // �^�C�}�[�J�n
        currentTime = timerDuration;  // �^�C�}�[���J�n
        Debug.Log("�^�C�}�[�J�n: " + currentTime);
    }


    void TimerEnded()
    {
        PlayerMovement playerMovement1 = targetPlayer1.GetComponent<PlayerMovement>();
        PlayerMovement playerMovement2 = targetPlayer2.GetComponent<PlayerMovement>();

        if (playerMovement1 != null)
        {
            // can_move �� 0 �ɐݒ肵�Ĉړ����ċ���
            playerMovement1.can_move = 0;
        }
        if (playerMovement2 != null)
        {
            // can_move �� 0 �ɐݒ肵�Ĉړ����ċ���
            playerMovement2.can_move = 0;
        }

        Debug.Log("�^�C�}�[�I���B�ړ����ĊJ����܂����B");

        // �^�C�}�[�����Z�b�g
        currentTime = 0;  // �^�C�}�[�����Z�b�g
    }
   
}
