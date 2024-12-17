#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Question1))]
public class QuestionEditor1 : Editor
{
    public override void OnInspectorGUI()
    {
        Question1 question = (Question1)target;

        // Unity�ɓo�^����Ă���^�O��I���ł���悤�ɂ���
        question.correctItemTag = EditorGUILayout.TagField("Correct Item Tag", question.correctItemTag);

        // ���̃C���X�y�N�^�[GUI���\��
        DrawDefaultInspector();
    }
}
#endif
