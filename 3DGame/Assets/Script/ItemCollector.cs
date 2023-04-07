using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int coin = 0;
    [SerializeField] private TMP_Text textCoins;
    [SerializeField] private AudioSource collectCoinsSound;
    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coin++;
            textCoins.text = "Coins:" + coin;
            collectCoinsSound.Play();
        }
    }
}
