using UnityEngine;

public class DoorFrame : MonoBehaviour
{
    [SerializeField] private GameObject frameDoor_T;
    [SerializeField] private GameObject frameDoor_L;
    [SerializeField] private GameObject frameDoor_R;
    [SerializeField] private GameObject frameDoor_B;

    [SerializeField] private GameObject frameDoor_L_Pivot;
    [SerializeField] private GameObject frameDoor_R_Pivot;

    [SerializeField] private GameObject doorUpperPart;
    [SerializeField] private GameObject doorLowerPart;

    [SerializeField] private GameObject handleDoor;

    const int CONST_ZERO = 0;
    const int CONST_TWO = 2;
    const int CONST_MINUS_ONE = -1;

    private void Update()
    {
        UpdateDoorFrame();
    }

    void UpdateDoorFrame()
    {
        UpdateSides(true);
        UpdateSides(false);
        UpdateBot();
        UpdateTop();
        UpdateHandle();
        UpdateLowerDoorPart();
        UpdateLowerDoorPart();
    }

    void UpdateTop()
    {
        if (frameDoor_B)
        {
            Vector3 newTrans = new Vector3(Dataholder.CONST_FIX_FRAME_T_HIGHT, frameDoor_B.transform.localScale.y, frameDoor_B.transform.localScale.z);
            frameDoor_T.transform.localScale = newTrans;

            Vector3 newPos = frameDoor_B.transform.localPosition;
            newPos.y = frameDoor_L.transform.localScale.y + 
                frameDoor_T.transform.localScale.x / CONST_TWO +
                frameDoor_B.transform.localScale.x / CONST_TWO;
            frameDoor_T.transform.localPosition = newPos;
        }
    }

    public void UpdateSides(bool isLeftSide)
    {
        
        Vector3 newTrans = new Vector3(
            Dataholder.CONST_FIX_FRAME_LR_WIDTH, 
            Dataholder.hightDoorFrame - Dataholder.CONST_FIX_FRAME_B_HIGHT - Dataholder.CONST_FIX_FRAME_T_HIGHT, 
            Dataholder.depthFrame);

        Vector3 newPos = new Vector3();
        if (isLeftSide && frameDoor_L)
        {
            frameDoor_L.transform.localScale = newTrans;
            newPos.x = frameDoor_L.transform.localScale.x / CONST_TWO;
            newPos.y = frameDoor_L.transform.localScale.y / CONST_TWO;
            frameDoor_L.transform.localPosition = newPos;
        }
        else if(frameDoor_R)
        {
            frameDoor_R.transform.localScale = newTrans;
            newPos.x = (frameDoor_R.transform.localScale.x / CONST_TWO) / CONST_MINUS_ONE;
            newPos.y = frameDoor_R.transform.localScale.y / CONST_TWO;
            frameDoor_R.transform.localPosition = newPos;
        }
    }

    public void UpdateBot()
    {
        if(frameDoor_B && frameDoor_T)
        {
            frameDoor_B.transform.localScale = new Vector3(Dataholder.CONST_FIX_FRAME_B_HIGHT,Dataholder.widthDoorFrame, Dataholder.depthFrame);
        }
    }

    public void UpdateLowerDoorPart()
    {
        if (doorLowerPart) 
        {
            doorLowerPart.transform.localPosition = new Vector3(
                CONST_ZERO,
                Dataholder.hightTotalLowerPart / CONST_TWO,
                CONST_ZERO); ;

            doorLowerPart.transform.localScale = new Vector3(
                Dataholder.widthDoorFrame - Dataholder.CONST_FIX_FRAME_LR_WIDTH * CONST_TWO,
                Dataholder.hightTotalLowerPart - Dataholder.CONST_FIX_FRAME_B_HIGHT,
                Dataholder.depthDoor);
        }
    }

    public void UpdateHandle() 
    {
        if (handleDoor) 
        {
            Vector3 newPos = new Vector3(
                // Total width/2 of the door minus fixed offset to frame, plus half of the handle width because of centred pivot 
                Dataholder.widthDoorFrame / CONST_TWO - Dataholder.CONST_FIX_FRAME_LR_WIDTH - Dataholder.CONST_FIX_HANDLE_OFFSET - handleDoor.transform.localScale.x / CONST_TWO,
                // Fixed hight of the handle minus half of bottomframe because of centred pivot, plus half of handle hight because of centred pivot
                Dataholder.CONST_FIX_HANDLE_HIGHT - Dataholder.CONST_FIX_FRAME_B_HIGHT / CONST_TWO + handleDoor.transform.localScale.y / CONST_TWO,
                // Doordepth divided
                CONST_ZERO);
            handleDoor.transform.localPosition = newPos;
        }
    }
}
