using UnityEngine;

public class CoinLogic : MonoBehaviour
{

    [SerializeField] private float rotationSpeed = 85f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, rotationSpeed * Time.deltaTime, 0f);
        
    }
}
