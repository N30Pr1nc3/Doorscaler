using UnityEngine;
using UnityEngine.UIElements;

public class MenuFunctions : MonoBehaviour
{
    [SerializeField] private UIDocument document;
    [SerializeField] private TextField doorFrameHightTextField;
    [SerializeField] private TextField doorWith;
    [SerializeField] private TextField doorDepth;
    [SerializeField] private TextField windowHight;
    [SerializeField] private TextField windowWidth;

    private const string CONST_DOOR_HIGHT = "Doorhight";
    private const string CONST_DOOR_WIDTH = "Doorwidth";
    private const string CONST_DOOR_DEPTH = "Doordepth";
    private const string CONST_WINDOW_HIGHT = "Windowhight";
    private const string CONST_WINDOW_WIDTH = "Windowwidth";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        document = GetComponent<UIDocument>();
        doorFrameHightTextField = document.rootVisualElement.Q(CONST_DOOR_HIGHT) as TextField;
        doorDepth = document.rootVisualElement.Q(CONST_DOOR_WIDTH) as TextField;
        doorWith = document.rootVisualElement.Q(CONST_DOOR_DEPTH) as TextField;
        windowHight = document.rootVisualElement.Q(CONST_WINDOW_HIGHT) as TextField;
        windowWidth = document.rootVisualElement.Q(CONST_WINDOW_WIDTH) as TextField;

        BindElements();
    }

    private void OnDisable()
    {
        if (doorFrameHightTextField != null) doorFrameHightTextField.UnregisterCallback<KeyDownEvent>(OnEnterInput);
    }
    private void BindElements()
    {
        if (doorFrameHightTextField != null)
        {
            doorFrameHightTextField.RegisterCallback<KeyDownEvent>(OnEnterInput);
            doorFrameHightTextField.RegisterCallback<FocusInEvent>(_ => Debug.Log("Fokus erhalten"));

        }
        Debug.Log(doorFrameHightTextField.multiline);
    }

    private void OnEnterInput(KeyDownEvent evt)
    {
        if (float.TryParse(doorFrameHightTextField.value, out float value)) Dataholder.hightDoorFrame = value;
        else Debug.Log("false value...");
    }
}
