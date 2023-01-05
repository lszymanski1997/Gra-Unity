using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish2 : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("current_lvl", 2);
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject g = collision.gameObject;
            Player player = g.GetComponentInParent<Player>();
            SceneManager.LoadScene("Level3");
            PlayerPrefs.SetInt("current_lvl", 3);
            PlayerPrefs.SetInt("ammo", player.getAmmo());
            Debug.Log(PlayerPrefs.GetInt("ammo", 0));
        }
    }
}
