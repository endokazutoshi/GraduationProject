#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Question1))]
public class QuestionEditor1 : Editor
{
    public override void OnInspectorGUI()
    {
        Question1 question = (Question1)target;

        // Unityに登録されているタグを選択できるようにする
        question.correctItemTag = EditorGUILayout.TagField("Correct Item Tag", question.correctItemTag);

        // 他のインスペクターGUIも表示
        DrawDefaultInspector();
    }
}
#endif
