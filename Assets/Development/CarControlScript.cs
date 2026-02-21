using UnityEngine;

public class CarControlScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    
    public void Moving(float moveValue)
    {
        Vector3 direction = Vector3.up * moveValue;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    public void Turning(float turnValue)
    {
        var turn = turnValue * turnSpeed;
        transform.Rotate(0,0,turn*Time.deltaTime);
        Debug.Log(turn);
        
    }
}
