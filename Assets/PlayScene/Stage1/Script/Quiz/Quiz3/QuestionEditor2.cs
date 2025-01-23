#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Question2))]
public class QuestionEditor2 : Editor
{
    public override void OnInspectorGUI()
    {
        Question2 question = (Question2)target;

        // Unity�ɓo�^����Ă���^�O��I���ł���悤�ɂ���
        question.correctItemTag = EditorGUILayout.TagField("Correct Item Tag", question.correctItemTag);

        // ���̃C���X�y�N�^�[GUI���\��
        DrawDefaultInspector();
    }
}
#endif
