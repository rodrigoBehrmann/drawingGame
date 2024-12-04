using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Episode))]
public class EpisodeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Episode episode = (Episode)target;

        DrawDefaultInspector();

        if (episode.HaveOptions)
        {
            episode.Option1 = EditorGUILayout.TextField("Option 1", episode.Option1);
            episode.Option2 = EditorGUILayout.TextField("Option 2", episode.Option2);   
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
