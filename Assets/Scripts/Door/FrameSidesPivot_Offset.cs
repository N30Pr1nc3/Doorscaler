using UnityEngine;

public class FrameSidesPivot_Offset : MonoBehaviour
{
    [SerializeField] private bool isLeftSide = true;

    const int CONST_TWO_Divider = 2;
    const int CONST_MINUS_ONE_INVERTER = -1;

    [SerializeField] private GameObject doorFrame_B;

    void Update()
    {
        //Testing
        RearrangePos();
    }

    void RearrangePos()
    {
        if (doorFrame_B)
        {
            Vector3 newPos = new Vector3();
            if (isLeftSide) newPos.x = (doorFrame_B.transform.localScale.y / CONST_TWO_Divider) * CONST_MINUS_ONE_INVERTER;
            else newPos.x = doorFrame_B.transform.localScale.y / CONST_TWO_Divider;
            newPos.y = doorFrame_B.transform.localScale.x / CONST_TWO_Divider;
            gameObject.transform.localPosition = newPos;
        }
    }

}
