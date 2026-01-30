using UnityEngine;

public class PlayerMask : MonoBehaviour
{
    private bool _isWearingMask;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1) && !_isWearingMask)
        {
            print("1");
            _isWearingMask = false;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) && !_isWearingMask)
        {
            print("2");
            _isWearingMask = false;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3) && !_isWearingMask)
        {
            print("3");
            _isWearingMask = false;
        }
    }
}
