using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class QuestionAnswerPair
    {
        public GameObject questionObject;  // ���I�u�W�F�N�g�i3D�I�u�W�F�N�g��UI�G�������g�Ȃǁj
        public string correctAnswerTag;    // �����̃A�C�e���̃^�O�i������Őݒ�j
    }

    public QuestionAnswerPair[] questionAnswerPairs;  // ���Ɖ𓚂̃y�A�̔z��

    private QuestionAnswerPair currentQuestion;  // ���݂̖��Ɛ����̃y�A

    void Start()
    {
        GenerateRandomQuestion();  // �����_���Ȗ��𐶐�
    }

    // �����_���ɖ���I������
    void GenerateRandomQuestion()
    {
        int randomIndex = Random.Range(0, questionAnswerPairs.Length);
        currentQuestion = questionAnswerPairs[randomIndex];  // �����_���Ȗ��Ɖ𓚂��擾

        // ���̖��I�u�W�F�N�g���\���ɂ���i�O�̖����B���j
        foreach (var pair in questionAnswerPairs)
        {
            if (pair.questionObject != null)
            {
                pair.questionObject.SetActive(false);  // ���ׂĂ̖��I�u�W�F�N�g���\��
            }
        }

        // ���ݑI�΂ꂽ���I�u�W�F�N�g��\��
        if (currentQuestion.questionObject != null)
        {
            Debug.Log("���: " + currentQuestion.questionObject.name);
            currentQuestion.questionObject.SetActive(true);  // �I�u�W�F�N�g���V�[���ɕ\��
        }
    }

    // ���݂̖���Ԃ����\�b�h
    public QuestionAnswerPair GetCurrentQuestion()
    {
        return currentQuestion;
    }

    // Unity�G�f�B�^�p�Ƀ^�O�I���@�\��ǉ��iCustom Editor�ȂǂŎg���j
    public string[] GetAllTags()
    {
        return UnityEditorInternal.InternalEditorUtility.tags;  // Unity�̃^�O���擾
    }
}
