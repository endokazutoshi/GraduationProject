using UnityEngine;

public class QuizManager1 : MonoBehaviour
{
    public static QuizManager1 Instance;  // Singleton�C���X�^���X

    [System.Serializable]
    public class QuestionAnswerPair
    {
        public int questionNumber;       // ���ԍ�
        public GameObject questionObject;  // ���I�u�W�F�N�g�i�Ⴆ��3D�I�u�W�F�N�g��UI�j
        public string correctAnswer1Tag;    // �����̃A�C�e���̃^�O�i������Őݒ�j
    }

    public QuestionAnswerPair[] questionAnswerPairs;  // ���Ɖ𓚂̃y�A�̔z��

    private QuestionAnswerPair currentQuestion;  // ���݂̖��Ɛ����̃y�A
    private RangeChecker1 rangeChecker;  // RangeChecker�̎Q��

    public int randomIndex;

    void Awake()
    {
        // Singleton�̏�����
        if (Instance == null)
        {
            Instance = this;
        }

        // RangeChecker�̎Q�Ƃ�Awake�Ŏ擾
        rangeChecker= FindObjectOfType<RangeChecker1>();
    }

    void Start()
    {
        // �����_���Ȗ���ݒ�
        SetRandomQuestion1();

        // �����_���Ȗ��ԍ������肵��RangeChecker�ɑ��M
        Debug.Log("���̐���(2)�́�" + randomIndex);

        // �v���C���[1�ƃv���C���[2�ɈقȂ�摜��n��
        rangeChecker.SetCurrentQuestionObject1(1, rangeChecker.imageObjectsPlayer1[randomIndex]);  // �v���C���[1�ɑI�΂ꂽ�摜�𑗐M
        rangeChecker.SetCurrentQuestionObject1(2, rangeChecker.imageObjectsPlayer2[randomIndex]);  // �v���C���[2�ɑI�΂ꂽ�摜�𑗐M

    }

    // �����_���Ȗ���I��Őݒ肷��
    public void SetRandomQuestion1()
    {
        randomIndex = Random.Range(0, questionAnswerPairs.Length);
        currentQuestion = questionAnswerPairs[randomIndex];  // �I�񂾖���ݒ�

        // �������O�ɕ\���i�f�o�b�O�p�j
        Debug.Log($"QuizManager(2)�̌��݂̖���: {currentQuestion.questionObject.name}");
        Debug.Log($"QuizManager(2)�̐����^�O��: {currentQuestion.correctAnswer1Tag}");
        Debug.Log($"QuizManager(2)�̖��ԍ���: {currentQuestion.questionNumber}");
    }

    // �𓚂��`�F�b�N���郁�\�b�h
    public bool CheckAnswer1(string itemTag)
    {
        // �A�C�e���̃^�O�������̃^�O�ƈ�v���邩���m�F
        if (itemTag == currentQuestion.correctAnswer1Tag)
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
    public QuestionAnswerPair GetCurrentQuestion1()
    {
        return currentQuestion;
    }
}