using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Episode))]
public class EpisodeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Episode episode = (Episode)target;

        // Desenha o inspetor padrão
        DrawDefaultInspector();

        // Condicionalmente desenha o campo Option1
        if (episode.HaveOptions)
        {
            episode.Option1 = EditorGUILayout.TextField("Option 1", episode.Option1);
            episode.Option2 = EditorGUILayout.TextField("Option 2", episode.Option2);   
        }

        // Garantir que o Unity reconheça que o objeto foi modificado
        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
