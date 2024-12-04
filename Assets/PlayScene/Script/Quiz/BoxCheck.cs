using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    public PlayerMovement PlayerMovement; // PlayerMovement�̎Q��
    private QuizManager quizManager;

    public GameObject targetObject;
    public GameObject targetObject2;

    public GameObject targetPlayer;

    public float timerDuration = 3f;  // 3�b
    private float currentTime;

    public float forceMultiplier = 10f;  // ������΂��͂̔{��

    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
        targetObject.SetActive(false);
        targetObject2.SetActive(false);
        currentTime = timerDuration;  // �^�C�}�[�̏�����
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

        // targetPlayer��Rigidbody2D�R���|�[�l���g�����邩�m�F
        Rigidbody2D rb = targetPlayer.GetComponent<Rigidbody2D>();

        // �^�C�}�[��0�ȏ�̏ꍇ�ɃJ�E���g�_�E�������s
        if (currentTime > 0)
        {
            Debug.Log("�^�C�}�[�N��");
            currentTime -= Time.deltaTime;  // ���t���[���o�ߎ��Ԃ����Z

            // �ړ��𖳌������鏈��
            PlayerMovement.can_move = 1; // �����ňړ��𖳌���

            if (rb != null)
            {
                // ������΂��������w��i�����ł͑Ώۂ̉E�����ɗ͂�������j
                Vector2 forceDirection = -targetPlayer.transform.right;  // 2D�̏ꍇ��right���g�p

                // ������΂��͂�������
                rb.AddForce(forceDirection * forceMultiplier, ForceMode2D.Impulse); // 2D�ł̗͂̉�����
            }
            else
            {
                Debug.LogWarning("�w�肳�ꂽ�I�u�W�F�N�g��Rigidbody2D�R���|�[�l���g������܂���I");
            }
        }
        else
        {
            // �^�C�}�[��0�ɂȂ������̏���
            TimerEnded();
        }
    }

    void TimerEnded()
    {
        PlayerMovement.can_move = 0;  // �^�C�}�[�I����A�ړ�������
        Debug.Log("�^�C�}�[�I���B�ړ����ĊJ����܂����B");
    }
}
