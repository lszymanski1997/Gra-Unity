using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish3 : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("current_lvl", 3);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject g = collision.gameObject;
            Player player = g.GetComponentInParent<Player>();
            SceneManager.LoadScene("Menu");
            PlayerPrefs.SetInt("current_lvl", 1);
            PlayerPrefs.SetInt("ammo", 15);
            Debug.Log(PlayerPrefs.GetInt("ammo", 0));
        }
    }
}

