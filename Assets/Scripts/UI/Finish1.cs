using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish1 : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("ammo", 15);
        Player player = GameObject.Find("Player").GetComponent<Player>();
        Debug.Log(player.getAmmo());
        player.reload_ammo();
        Debug.Log(player.getAmmo() + " 2");
        PlayerPrefs.SetInt("current_lvl", 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject g = collision.gameObject;
            Player player = g.GetComponentInParent<Player>();
            SceneManager.LoadScene("Level2");
            PlayerPrefs.SetInt("current_lvl", 2);
            PlayerPrefs.SetInt("ammo", player.getAmmo());
            Debug.Log(PlayerPrefs.GetInt("ammo", 0));
        }
    }
}
