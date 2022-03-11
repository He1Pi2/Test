using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public CharacterController player;
    Image healthBar;
    public float maxHealth = 100f;

    void Start()
    {
        healthBar = GetComponent<Image>();
        player.HP = maxHealth;
    }
    void Update()
    {
        healthBar.fillAmount = player.HP / maxHealth;
    }
}

