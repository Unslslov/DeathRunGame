using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TimeDataList))]
public class TimeDataListEditor : Editor
{
    public TimeDataList myTarget {get; private set;}

    public override void OnInspectorGUI()
    {
        myTarget = (TimeDataList)target;

        EditorGUILayout.LabelField("Количество объектов TimeData:", myTarget.timeDataList.Count.ToString());
        if (GUILayout.Button("Add Time Data"))
        {
            myTarget.timeDataList.Add(new TimeData());
            // myTarget.NumberLevel.Add(new int());
        }

        for (int i = 0; i < myTarget.timeDataList.Count; i++)
        {
            EditorGUILayout.BeginVertical("box");
            myTarget.timeDataList[i].FirstTime = EditorGUILayout.DoubleField("First Time", myTarget.timeDataList[i].FirstTime);
            myTarget.timeDataList[i].SecondTime = EditorGUILayout.DoubleField("Second Time", myTarget.timeDataList[i].SecondTime);
            // myTarget.NumberLevel[i] = EditorGUILayout.IntField("NumberLevel", myTarget.NumberLevel[i]);

            if (GUILayout.Button("Remove"))
            {
                myTarget.timeDataList.RemoveAt(i);
                break; // Прерываем цикл, чтобы избежать ошибки изменения коллекции во время итерации
            }
            EditorGUILayout.EndVertical();
        }

        // Сохраняем изменения в объекте
        if (GUI.changed)
        {
            EditorUtility.SetDirty(myTarget);
        }
    }
}