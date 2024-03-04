using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

[EditorTool("Block Creator")]
public class CustomeBlockMoovingTool : EditorTool
{
    public Texture2D ToolIcone;

    public override GUIContent toolbarIcon
    {
        get
        {
            return new GUIContent
            {
                image = ToolIcone,
                text = " Custome Block Creator",
                tooltip = " Tool to creat blocks"
            };
        }
    }

    public override void OnToolGUI(EditorWindow window)
    {
        Transform targetTransform = target.GameObject().transform;
        EditorGUI.BeginChangeCheck();
        var newPosition = Handles.PositionHandle(targetTransform.position, Quaternion.identity);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(targetTransform, "Moove");
            targetTransform.position = newPosition;
        }
    }


}
