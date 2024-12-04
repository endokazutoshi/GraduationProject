using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Question))]
public class QuestionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Question question = (Question)target;

        // Unityに登録されているタグを選択できるようにする
        question.correctItemTag = EditorGUILayout.TagField("Correct Item Tag", question.correctItemTag);

        // 他のインスペクターGUIも表示
        DrawDefaultInspector();
    }
}
