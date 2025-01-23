#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Question2))]
public class QuestionEditor2 : Editor
{
    public override void OnInspectorGUI()
    {
        Question2 question = (Question2)target;

        // Unityに登録されているタグを選択できるようにする
        question.correctItemTag = EditorGUILayout.TagField("Correct Item Tag", question.correctItemTag);

        // 他のインスペクターGUIも表示
        DrawDefaultInspector();
    }
}
#endif
