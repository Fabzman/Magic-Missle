using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour {

    public int ammo;
    public int health;
    public int shield;
    public bool powerUp;
    public TextMeshProUGUI healthCounter;
    public TextMeshProUGUI ammoCounter;
    public TextMeshProUGUI shieldCounter;

    // Use this for initialization
    void Start ()
    {
        ammoCounter.text = "Ammo: " + ammo.ToString();
        healthCounter.text = "Health: " + health.ToString();
        shieldCounter.text = "Shield: " + shield.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {

        health = Mathf.Clamp(health, 0, 100);
        ammo = Mathf.Clamp(ammo, 0, 100);
        shield = Mathf.Clamp(shield, 0, 100);

        ammoCounter.text = "Ammo: " + ammo.ToString();
        healthCounter.text = "Health: " + health.ToString();
        shieldCounter.text = "Shield: " + shield.ToString();

        //if (health >= 100)
        //      {
        //          return;
        //      }

        //      if (ammo >= 100)
        //      {
        //          return;
        //      }

        //      if (shield >= 100)
        //      {
        //          return;
        //      }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Potion")
        {
            Potions potion = other.GetComponent<Potions>();

            switch (potion.type)
            {
                case Potions.PotionType.AMMO:
                    // what happens when you pick up ammo
                    ammo += 10;
                    ammoCounter.text = "Ammo: " + ammo.ToString();
                    break;
                case Potions.PotionType.HEALTH:
                    // what happens when you pick up health
                    health += 10;
                    healthCounter.text = "Health: " + health.ToString();
                    break;
                case Potions.PotionType.SHIELD:
                    shield += 5;
                    shieldCounter.text = "Shield: " + shield.ToString();
                    // what happens when you pick up shield
                    break;
                case Potions.PotionType.MEGA_HEALTH:
                    // what happens when you pick up mega health
                    health += 100;
                    healthCounter.text = "Health: " + health.ToString();
                    break;
                case Potions.PotionType.POWER_UP:
                    // what happens when you pick up PowerUp
                    powerUp = true;
                    break;
            }

            Destroy(other.gameObject);
        }
    }
}
