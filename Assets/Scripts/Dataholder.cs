using UnityEngine;

public class Dataholder : Singleton<Dataholder>
{
    // Var Window
    [field: SerializeField] public static float hightWindow { get; set; } = 0.1f;
    [field: SerializeField] public static float widthWindow { get; set; } = 0.1f;
    [field: SerializeField] public static float depthWindow { get; set; } = 0.01f;

    // Var Door
    [field: SerializeField] public static float depthDoor { get; set; } = 0.02f;

    // Var Frame
    [field: SerializeField] public static float hightDoorFrame { get; set; } = 2f;
    [field: SerializeField] public static float widthDoorFrame { get; set; } = 1f;
    [field: SerializeField] public static float depthFrame { get; set; } = 0.001f;

    // Var LowerPart Door
    [field: SerializeField] public static float hightTotalLowerPart { get; set; } = 1.150f;
    
    // ___________________________________________________

    // Const Frame
    public const float CONST_FIX_FRAME_B_HIGHT = 0.02f;
    public const float CONST_FIX_FRAME_T_HIGHT = 0.05f;
    public const float CONST_FIX_FRAME_LR_WIDTH = 0.05f;

    // Const Handle
    public const float CONST_FIX_HANDLE_OFFSET = 0.05f;
    public const float CONST_FIX_HANDLE_HIGHT = 1.010f;

    void Start()
    {

    }

    void Update()
    {

    }
}
