using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    private int coin = 0;

    private void OnTriggerEnter(Collider other){

        if(other.transform.tag == "Coin"){
            coin++;
            Debug.Log("Coin collected: " + coin);
            Destroy(other.gameObject);
        }
    }
}
