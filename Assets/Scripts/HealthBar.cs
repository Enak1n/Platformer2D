using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthText;

    Damageable playerDamageable;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            Debug.Log("No player");

        playerDamageable = player.GetComponent<Damageable>();
    }

    void Start()
    {
        healthSlider.value = CalculatesSliderPercentage(playerDamageable.Health, playerDamageable.MaxHealth);
        healthText.text = "HP " + playerDamageable.Health + " / " + playerDamageable.MaxHealth; 
    }

    private void OnEnable()
    {
        playerDamageable.healthChanged.AddListener(OnPlayerHealthChanged);
    }

    private void OnDisable()
    {
        playerDamageable.healthChanged.RemoveListener(OnPlayerHealthChanged);
    }

    private float CalculatesSliderPercentage(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;
    }

    private void OnPlayerHealthChanged(int newHealth, int maxHealth)
    {
        healthSlider.value = CalculatesSliderPercentage(newHealth, maxHealth);
        healthText.text = "HP " + newHealth + " / " + maxHealth;
    }
}
