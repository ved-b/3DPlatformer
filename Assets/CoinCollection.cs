using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    private int coin = 0;

    public TextMeshProUGUI coinText;

    private void OnTriggerEnter(Collider other){

        if(other.transform.tag == "Coin"){
            coin++;
            coinText.text = "Coins: " + coin.ToString();
            Debug.Log("Coin collected: " + coin);
            Destroy(other.gameObject);
            // Bringing loader back
        }
    }
}
