using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;  // Singleton�C���X�^���X

    [System.Serializable]
    public class QuestionAnswerPair
    {
        public int questionNumber;       // ���ԍ�
        public GameObject questionObject;  // ���I�u�W�F�N�g�i�Ⴆ��3D�I�u�W�F�N�g��UI�j
        public string correctAnswerTag;    // �����̃A�C�e���̃^�O�i������Őݒ�j
    }

    public QuestionAnswerPair[] questionAnswerPairs;  // ���Ɖ𓚂̃y�A�̔z��

    private QuestionAnswerPair currentQuestion;  // ���݂̖��Ɛ����̃y�A
    private RangeChecker rangeChecker;  // RangeChecker�̎Q��

    public int randomIndex;

    void Awake()
    {
        // Singleton�̏�����
        if (Instance == null)
        {
            Instance = this;
        }

        // RangeChecker�̎Q�Ƃ�Awake�Ŏ擾
        rangeChecker = FindObjectOfType<RangeChecker>();
    }

    void Start()
    {
        // �����_���Ȗ���ݒ�
        SetRandomQuestion();

        // �����_���Ȗ��ԍ������肵��RangeChecker�ɑ��M
        Debug.Log("���̐����́�" + randomIndex);

        // �����_���ɑI�΂ꂽquestionObject��RangeChecker�ɓn��
        rangeChecker.SetCurrentQuestionObject(1, questionAnswerPairs[randomIndex].questionObject);  // �v���C���[1�ɑI�΂ꂽ���I�u�W�F�N�g�𑗐M
        rangeChecker.SetCurrentQuestionObject(2, questionAnswerPairs[randomIndex].questionObject);
    }

    // �����_���Ȗ���I��Őݒ肷��
    public void SetRandomQuestion()
    {
        randomIndex = Random.Range(0, questionAnswerPairs.Length);
        currentQuestion = questionAnswerPairs[randomIndex];  // �I�񂾖���ݒ�

        // �������O�ɕ\���i�f�o�b�O�p�j
        Debug.Log($"QuizManager�̌��݂̖���: {currentQuestion.questionObject.name}");
        Debug.Log($"QuizManager�̐����^�O��: {currentQuestion.correctAnswerTag}");
        Debug.Log($"QuizManager�̖��ԍ���: {currentQuestion.questionNumber}");
    }

    // �𓚂��`�F�b�N���郁�\�b�h
    public bool CheckAnswer(string itemTag)
    {
        // �A�C�e���̃^�O�������̃^�O�ƈ�v���邩���m�F
        if (itemTag == currentQuestion.correctAnswerTag)
        {
            Debug.Log("����!");
            return true;  // ����
        }
        else
        {
            Debug.Log("�s����!");
            return false;  // �s����
        }
    }

    // ���݂̖���Ԃ�
    public QuestionAnswerPair GetCurrentQuestion()
    {
        return currentQuestion;
    }
}
