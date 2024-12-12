using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Question))]
public class QuestionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Question question = (Question)target;

        // Unity�ɓo�^����Ă���^�O��I���ł���悤�ɂ���
        question.correctItemTag = EditorGUILayout.TagField("Correct Item Tag", question.correctItemTag);

        // ���̃C���X�y�N�^�[GUI���\��
        DrawDefaultInspector();
    }
}
