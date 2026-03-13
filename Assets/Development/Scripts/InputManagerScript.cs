using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerScript : MonoBehaviour
{
    public CarControlScript car;
    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            car.Moving(1);
        }

        else if (Keyboard.current.sKey.isPressed)
        {
            car.Moving(-1);
        }

        if (Keyboard.current.aKey.isPressed)
        {
            car.Turning(1);
        }

        else if (Keyboard.current.dKey.isPressed)
        {
            car.Turning(-1);
        }
        
    }
}
