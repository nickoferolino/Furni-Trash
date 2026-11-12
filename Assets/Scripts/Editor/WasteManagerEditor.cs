
//using UnityEngine;
//using UnityEditor;

//[CustomEditor(typeof(WasteManager))]
//public class WasteManagerEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        serializedObject.Update();

//        SerializedProperty wasteList =
//            serializedObject.FindProperty("wasteDataList");

//        EditorGUILayout.PropertyField(wasteList, true);

//        for (int i = 0; i < wasteList.arraySize; i++)
//        {
//            SerializedProperty element =
//                wasteList.GetArrayElementAtIndex(i);

//            SerializedProperty wasteDataProperty =
//                element.FindPropertyRelative("wasteData");

//            WasteData data =
//                wasteDataProperty.objectReferenceValue as WasteData;

//            if (data == null)
//                continue;

//            EditorGUILayout.BeginVertical("box");

//            EditorGUILayout.LabelField(
//                data.name,
//                EditorStyles.boldLabel
//            );

//            Editor.CreateCachedEditor(
//                data,
//                null,
//                ref cachedEditor
//            );

//            if (cachedEditor != null)
//            {
//                cachedEditor.OnInspectorGUI();
//            }

//            EditorGUILayout.EndVertical();
//        }

//        serializedObject.ApplyModifiedProperties();
//    }

//    private Editor cachedEditor;

//    private void OnDisable()
//    {
//        if (cachedEditor != null)
//            DestroyImmediate(cachedEditor);
//    }
//}
