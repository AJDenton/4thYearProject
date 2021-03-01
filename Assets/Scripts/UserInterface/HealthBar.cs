using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBarImg;
    public float currentHealth;
    public float maxHealth;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        healthBarImg = GetComponent<Image>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Getting the full healkth value from the player script
        maxHealth = player.fullHealth;
        //Getting the health value from the player script
        currentHealth = player.health;
        //Setting the fill amount of the health as the player loses/gains health
        healthBarImg.fillAmount = currentHealth / maxHealth;
    }
}
