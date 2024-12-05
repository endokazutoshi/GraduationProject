using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    private QuizManager quizManager;

    public GameObject targetObject;
    public GameObject targetObject2;

    public GameObject targetPlayer;

    public float timerDuration = 2f;  // ����s�\�ɂ�����b��
    private float currentTime;

    public float forceMultiplier = 10f;  // ������΂��͂̔{��

    private Vector2 targetPosition;
    private bool isBlown = false;  // ������΂����J�n���ꂽ���ǂ���
    private float blowTime = 0f;    // ������΂��ɂ����鎞��
    float speedFactor = 20f;  // ������{�ɂ���i�����\�j

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
        if (isBlown)
        {
            // �ɂ₩�Ɉړ����邽�߂ɁALerp�ŖړI�n�Ɍ������Ĉړ�
            targetPlayer.transform.position = Vector2.Lerp(targetPlayer.transform.position, targetPosition, blowTime * Time.deltaTime);

            // �ړI�n�ɓ��B������ړ����~
            if (Vector2.Distance(targetPlayer.transform.position, targetPosition) < 0.1f)
            {
                isBlown = false;  // �ړ��I��
            }

            // ������΂����Ԃ�i�߂�
            blowTime += Time.deltaTime * speedFactor;  // speedFactor���|���đ����i�s������
        }

        // �^�C�}�[����������
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;  // �^�C�}�[������
            Debug.Log("�^�C�}�[�c�莞��: " + currentTime);  // �f�o�b�O���O�Ń^�C�}�[�c�莞�Ԃ�\��
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
                IncorrectAnswer();
            }
        }
        else
        {
            Debug.LogError("���݂̖�肪����܂���");
        }
    }

    void CorrectAnswer()
    {
        targetObject.SetActive(true);
        targetObject2.SetActive(true);
    }

    void IncorrectAnswer()
    {
        Debug.Log("IncorrectAnswer�����s���܂�");

        // targetPlayer��PlayerMovement�R���|�[�l���g���擾
        PlayerMovement playerMovement = targetPlayer.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            // can_move �� 1 �ɐݒ肵�Ĉړ��𖳌���
            playerMovement.can_move = 1;
        }

        // targetPlayer��Rigidbody2D�R���|�[�l���g�����邩�m�F
        Rigidbody2D rb = targetPlayer.GetComponent<Rigidbody2D>();

        // ������΂������Ƌ���������
        Vector2 forceDirection = -targetPlayer.transform.right;  // ������΂�����
        float blowDistance = 5f;  // ������΂������i���j�b�g�j

        // �ŏI�I�ȖړI�n�̈ʒu���v�Z
        targetPosition = rb.position + forceDirection * blowDistance;

        // ������΂����J�n����
        isBlown = true;
        blowTime = 0f;  // ������΂��̎��Ԃ����Z�b�g

        // �^�C�}�[�J�n
        currentTime = timerDuration;  // �^�C�}�[���J�n
        Debug.Log("�^�C�}�[�J�n: " + currentTime);
    }

    void TimerEnded()
    {
        PlayerMovement playerMovement = targetPlayer.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            // can_move �� 0 �ɐݒ肵�Ĉړ����ċ���
            playerMovement.can_move = 0;
        }

        Debug.Log("�^�C�}�[�I���B�ړ����ĊJ����܂����B");

        // �^�C�}�[�����Z�b�g
        currentTime = 0;  // �^�C�}�[�����Z�b�g
    }
}
