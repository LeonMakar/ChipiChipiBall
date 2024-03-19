using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEditor.EditorTools;
[EditorTool("Place Objects Tool")]
public class CustomeBlockCreationTool : EditorTool
{
    static Texture2D _toolIcon;

    readonly GUIContent _iconContent = new GUIContent
    {
        image = _toolIcon,
        text = "Place Objects Tool",
        tooltip = "Place Objects Tool"
    };

    VisualElement _toolRootElement;
    ObjectField _prefabObjectField;
    private Vector3 _startPoint;
    private Vector3 _endPoint;


    bool _receivedClickDownEvent;
    bool _receivedClickUpEvent;

    bool HasPlaceableObject => _prefabObjectField?.value != null;

    public override GUIContent toolbarIcon => _iconContent;

    public override void OnActivated()
    {
        //Create the UI
        _toolRootElement = new VisualElement();
        _toolRootElement.style.width = 200;
        var backgroundColor = EditorGUIUtility.isProSkin
            ? new Color(0.21f, 0.21f, 0.21f, 0.8f)
            : new Color(0.8f, 0.8f, 0.8f, 0.8f);
        _toolRootElement.style.backgroundColor = backgroundColor;
        _toolRootElement.style.marginLeft = 10f;
        _toolRootElement.style.marginBottom = 10f;
        _toolRootElement.style.paddingTop = 5f;
        _toolRootElement.style.paddingRight = 5f;
        _toolRootElement.style.paddingLeft = 5f;
        _toolRootElement.style.paddingBottom = 5f;
        var titleLabel = new Label("Place Objects Tool");
        titleLabel.style.unityTextAlign = TextAnchor.UpperCenter;

        _prefabObjectField = new ObjectField { allowSceneObjects = true, objectType = typeof(GameObject) };

        _toolRootElement.Add(titleLabel);
        _toolRootElement.Add(_prefabObjectField);

        var sv = SceneView.lastActiveSceneView;
        sv.rootVisualElement.Add(_toolRootElement);
        sv.rootVisualElement.style.flexDirection = FlexDirection.ColumnReverse;

        SceneView.beforeSceneGui += BeforeSceneGUI;
    }

    public override void OnWillBeDeactivated()
    {
        _toolRootElement?.RemoveFromHierarchy();
        SceneView.beforeSceneGui -= BeforeSceneGUI;
    }

    void BeforeSceneGUI(SceneView sceneView)
    {
        if (!ToolManager.IsActiveTool(this))
            return;

        if (Event.current.type == EventType.MouseDown && Event.current.button == 1)
        {
            ShowMenu();
            Event.current.Use();
        }

        if (!HasPlaceableObject)
        {
            _receivedClickDownEvent = false;
            _receivedClickUpEvent = false;
        }
        else
        {
            if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
            {
                _receivedClickDownEvent = true;
                _startPoint = new Vector3(Mathf.RoundToInt(GetCurrentMousePositionInScene().x), Mathf.RoundToInt(GetCurrentMousePositionInScene().y),
                             Mathf.RoundToInt(GetCurrentMousePositionInScene().z));
                Event.current.Use();
            }

            if (_receivedClickDownEvent && Event.current.type == EventType.MouseUp && Event.current.button == 0)
            {
                _receivedClickDownEvent = false;
                _receivedClickUpEvent = true;
                _endPoint = new Vector3(Mathf.RoundToInt(GetCurrentMousePositionInScene().x), Mathf.RoundToInt(GetCurrentMousePositionInScene().y),
                             Mathf.RoundToInt(GetCurrentMousePositionInScene().z)); ;
                Event.current.Use();
            }
        }
    }

    public override void OnToolGUI(EditorWindow window)
    {
        //If we're not in the scene view, we're not the active tool, we don't have a placeable object, exit.
        if (!(window is SceneView))
            return;

        if (!ToolManager.IsActiveTool(this))
            return;

        if (!HasPlaceableObject)
            return;

        //Draw a positional Handle.
        Handles.DrawWireDisc(GetCurrentMousePositionInScene(), Vector3.up, 0.5f);

        //If the user clicked, clone the selected object, place it at the current mouse position.
        if (_receivedClickUpEvent)
        {
            var newObject = _prefabObjectField.value;

            _startPoint = new Vector3(Mathf.FloorToInt(_startPoint.x), Mathf.FloorToInt(_startPoint.y), Mathf.FloorToInt(_startPoint.z));
            _endPoint = new Vector3(Mathf.FloorToInt(_endPoint.x), Mathf.FloorToInt(_endPoint.y), Mathf.FloorToInt(_endPoint.z));

            int startX = (int)_startPoint.x;
            int startY = (int)_startPoint.y;
            int endX = (int)_endPoint.x;
            int endY = (int)_endPoint.y;

            int countX = endX - startX;
            int countY = endY - startY;

            Debug.Log(countX + ", " + countY);
            for (int x = 0; x < Mathf.Abs(countX) + 1; x++)
            {
                for (int y = 0; y < Mathf.Abs(countY) + 1; y++)
                {

                    GameObject newObjectInstance;
                    if (PrefabUtility.IsPartOfAnyPrefab(newObject))
                    {
                        var prefabPath = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(newObject);
                        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                        newObjectInstance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                    }
                    else
                    {
                        newObjectInstance = Instantiate((GameObject)newObject);
                    }

                    //newObjectInstance.transform.position = newObjectInstance.transform.position = new Vector3(Mathf.RoundToInt(GetCurrentMousePositionInScene().x), Mathf.RoundToInt(GetCurrentMousePositionInScene().y),
                    //    Mathf.RoundToInt(GetCurrentMousePositionInScene().z))
                    if (countX < 0 && countY < 0)
                        newObjectInstance.transform.position = new Vector3(startX - x, startY - y, 0);
                    else if (countX > 0 && countY > 0)
                        newObjectInstance.transform.position = new Vector3(startX + x, startY + y, 0);
                    else if (countX < 0 && countY > 0)
                        newObjectInstance.transform.position = new Vector3(startX - x, startY + y, 0);
                    else if (countX > 0 && countY < 0)
                        newObjectInstance.transform.position = new Vector3(startX + x, startY - y, 0);
                    else if (countX == 0 && countY < 0)
                        newObjectInstance.transform.position = new Vector3(startX, startY - y, 0);
                    else if (countX == 0 && countY == 0)
                        newObjectInstance.transform.position = new Vector3(startX, startY, 0);
                    else if (countX == 0 && countY > 0)
                        newObjectInstance.transform.position = new Vector3(startX, startY + y, 0);
                    else if (countX > 0 && countY == 0)
                        newObjectInstance.transform.position = new Vector3(startX + x, startY + y, 0);
                    else if (countX < 0 && countY == 0)
                        newObjectInstance.transform.position = new Vector3(startX - x, startY + y, 0);
                    Undo.RegisterCreatedObjectUndo(newObjectInstance, "Place new object");
                }
            }


            _receivedClickUpEvent = false;
        }

        //Force the window to repaint.
        window.Repaint();
    }

    Vector3 GetCurrentMousePositionInScene()
    {
        Vector3 mousePosition = Event.current.mousePosition;
        var placeObject = HandleUtility.PlaceObject(mousePosition, out var newPosition, out var normal);
        return placeObject ? newPosition : HandleUtility.GUIPointToWorldRay(mousePosition).GetPoint(10);
    }

    void ShowMenu()
    {
        var picked = HandleUtility.PickGameObject(Event.current.mousePosition, true);
        if (!picked) return;

        var menu = new GenericMenu();
        menu.AddItem(new GUIContent($"Pick {picked.name}"), false, () => { _prefabObjectField.value = picked; });
        menu.ShowAsContext();
    }

}
#endif
