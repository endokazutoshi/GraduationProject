using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(QuizManager))]
public class QuizManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        QuizManager quizManager = (QuizManager)target;

        // ���̃y�A��ݒ�
        for (int i = 0; i < quizManager.questionAnswerPairs.Length; i++)
        {
            var questionPair = quizManager.questionAnswerPairs[i];

            // ���I�u�W�F�N�g�̐ݒ�
            questionPair.questionObject = (GameObject)EditorGUILayout.ObjectField("Question Object", questionPair.questionObject, typeof(GameObject), true);

            // �����̃^�O��Unity�Őݒ肳��Ă���^�O����I��
            string[] tagOptions = UnityEditorInternal.InternalEditorUtility.tags; // ������Unity�ɐݒ肳��Ă���^�O���擾
            int selectedTagIndex = System.Array.IndexOf(tagOptions, questionPair.correctAnswerTag);
            if (selectedTagIndex == -1) selectedTagIndex = 0; // �����l�Ƃ��čŏ��̃^�O��I��

            // Popup�Ń^�O��I������
            selectedTagIndex = EditorGUILayout.Popup("Correct Answer Tag", selectedTagIndex, tagOptions);

            // �I�΂ꂽ�^�O��ݒ�
            questionPair.correctAnswerTag = tagOptions[selectedTagIndex];

            // ���y�A��ݒ�
            quizManager.questionAnswerPairs[i] = questionPair;
        }

        // ���̃C���X�y�N�^�[GUI���\��
        DrawDefaultInspector();
    }
}