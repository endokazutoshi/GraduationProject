#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(QuizManager1))]
public class QuizManagerEditor1 : Editor
{
    public override void OnInspectorGUI()
    {
        QuizManager1 quizManager = (QuizManager1)target;

        // 問題のペアを設定
        for (int i = 0; i < quizManager.questionAnswerPairs.Length; i++)
        {
            var questionPair = quizManager.questionAnswerPairs[i];

            // 問題オブジェクトの設定
            questionPair.questionObject = (GameObject)EditorGUILayout.ObjectField("Question Object", questionPair.questionObject, typeof(GameObject), true);

            // 正解のタグをUnityで設定されているタグから選択
            string[] tagOptions = UnityEditorInternal.InternalEditorUtility.tags; // ここでUnityに設定されているタグを取得
            int selectedTagIndex = System.Array.IndexOf(tagOptions, questionPair.correctAnswer1Tag);
            if (selectedTagIndex == -1) selectedTagIndex = 0; // 初期値として最初のタグを選ぶ

            // Popupでタグを選択する
            selectedTagIndex = EditorGUILayout.Popup("Correct Answer Tag", selectedTagIndex, tagOptions);

            // 選ばれたタグを設定
            questionPair.correctAnswer1Tag = tagOptions[selectedTagIndex];

            // 問題ペアを設定
            quizManager.questionAnswerPairs[i] = questionPair;
        }

        // 他のインスペクターGUIも表示
        DrawDefaultInspector();
    }
}
#endif
