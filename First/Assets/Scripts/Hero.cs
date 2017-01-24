using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hero : MonoBehaviour {

    public int currentHealth;
    public int maxHealth;
    public Text text;

    private GameObject player;


	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = maxHealth;
        text.text = currentHealth.ToString();
	}

    private void Update()
    {
        if(player.transform.position.y < -5 || Input.GetKeyDown(KeyCode.R))
        {
            Death();
        }
    }
    public void TakeDamage (int count, float force)
    {
        currentHealth -= count;
        text.text = currentHealth.ToString();

        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Die, motherfucker, die");
        SceneManager.LoadScene(sceneName);        
    }
}
