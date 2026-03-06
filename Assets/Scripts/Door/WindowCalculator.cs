using UnityEngine;

public class WindowFrame : MonoBehaviour
{
    [SerializeField] private GameObject pivotEntireFrame;

    [SerializeField] private GameObject window;

    [SerializeField] private GameObject frameWindow_T;
    [SerializeField] private GameObject frameWindow_L;
    [SerializeField] private GameObject frameWindow_R;
    [SerializeField] private GameObject frameWindow_B;

    [SerializeField] private GameObject frameWindow_L_Pivot;
    [SerializeField] private GameObject frameWindow_R_Pivot;

    private float frameWindowWidth = 5f;
    private float frameWindowHeight = 5f;
    private float widthFrameSidesSingle = 5f;
    private float hightFrameHorizontals = 5f;

    const int CONST_ZERO = 0;
    const int CONST_TWO = 2;
    const int CONST_MINUS_ONE = -1;

    private void Update()
    {
        UpdateWindowFrame();
    }

    private void UpdateWindowFrame()
    {
        CalculateFrameSize();
        UpdateEntireFramePos();
        UpdateTransformSides(true);
        UpdateTransformSides(false);
        UpdateTransformBot();
        UpdateTransformTop();
        UpdateTransformWindowGlass();
    }
    private void CalculateFrameSize()
    {
        // Doorwidth - Framewith of side bars
        frameWindowWidth = Dataholder.widthDoorFrame - Dataholder.CONST_FIX_FRAME_LR_WIDTH * CONST_TWO;
        // Get frame hight by subtracting all bar hights from absolut size of the door
        frameWindowHeight = Dataholder.hightDoorFrame - Dataholder.CONST_FIX_FRAME_T_HIGHT - Dataholder.hightTotalLowerPart;

        // Calculate single sidebar width
        widthFrameSidesSingle = (frameWindowWidth - Dataholder.widthWindow) / CONST_TWO;
        // Calculate horizontal bar hight
        hightFrameHorizontals = (frameWindowHeight - Dataholder.hightWindow) / CONST_TWO;
    }

    void UpdateTransformTop()
    {
        if (frameWindow_B)
        {
            // new Transform top bar
            frameWindow_T.transform.localScale = frameWindow_B.transform.localScale;

            // Calculate new Position dependent from bot bar
            Vector3 newPos = new Vector3();
            // New y value by adding all lower part hights together 
            newPos.y = frameWindow_L.transform.localScale.y +
                frameWindow_T.transform.localScale.x / CONST_TWO +
                frameWindow_B.transform.localScale.x / CONST_TWO;
            frameWindow_T.transform.localPosition = newPos;
        }
    }

    public void UpdateTransformSides(bool isLeftSide)
    {

        Vector3 newTrans = new Vector3(
            widthFrameSidesSingle,
            Dataholder.hightWindow,
            Dataholder.depthDoor);

        Vector3 newPos = new Vector3();
        if (isLeftSide && frameWindow_L)
        {
            frameWindow_L.transform.localScale = newTrans;
            newPos.x = frameWindow_L.transform.localScale.x / CONST_TWO;
            newPos.y = frameWindow_L.transform.localScale.y / CONST_TWO;
            frameWindow_L.transform.localPosition = newPos;
        }
        else if (frameWindow_R)
        {
            frameWindow_R.transform.localScale = newTrans;
            newPos.x = (frameWindow_R.transform.localScale.x / CONST_TWO) / CONST_MINUS_ONE;
            newPos.y = frameWindow_R.transform.localScale.y / CONST_TWO;
            frameWindow_R.transform.localPosition = newPos;
        }
    }

    public void UpdateTransformBot()
    {
        if (frameWindow_B && frameWindow_T)
        {
            frameWindow_B.transform.localScale = new Vector3(hightFrameHorizontals, frameWindowWidth, Dataholder.depthDoor);
        }
    }
    private void UpdateEntireFramePos()
    {
        if (pivotEntireFrame)
        {
            pivotEntireFrame.transform.localPosition = new Vector3(
                CONST_ZERO,
                Dataholder.hightTotalLowerPart + hightFrameHorizontals / CONST_TWO - Dataholder.CONST_FIX_FRAME_B_HIGHT / CONST_TWO
                , CONST_ZERO);
        }
    }

    private void UpdateTransformWindowGlass()
    {
        if (window)
        {
            // Set Scale
            window.transform.localScale = new Vector3(Dataholder.widthWindow, Dataholder.hightWindow, Dataholder.depthWindow);

            // Set new Pos
            window.transform.localPosition = new Vector3
                (
                CONST_ZERO,
                (Dataholder.hightWindow + hightFrameHorizontals) / CONST_TWO,
                CONST_ZERO
                );
        }
    }
}
