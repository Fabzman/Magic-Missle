using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour {

    public int ammo;
    public int health;
    public float shield;
    public bool powerUp;
    public TextMeshProUGUI healthCounter;
    public TextMeshProUGUI ammoCounter;
    public TextMeshProUGUI shieldCounter;
    public AudioClip shieldS;
    public AudioClip healthS;
    public AudioClip ammoS;
    public AudioClip powerUPS;
    public AudioClip megaHealthS;

    // Use this for initialization
    void Start ()
    {
        ammoCounter.text = "Ammo: " + ammo.ToString();
        healthCounter.text = "Health: " + health.ToString();
        shieldCounter.text = "Shield: " + shield.ToString("F0");
    }
	
	// Update is called once per frame
	void Update ()
    {

        health = Mathf.Clamp(health, 0, 100);
        ammo = Mathf.Clamp(ammo, 0, 100);
        shield = Mathf.Clamp(shield, 0, 100);

        ammoCounter.text = "Ammo: " + ammo.ToString();
        healthCounter.text = "Health: " + health.ToString();
        shieldCounter.text = "Shield: " + shield.ToString("F0");

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
                    AudioSource.PlayClipAtPoint(ammoS, Camera.main.transform.position);
                    ammoCounter.text = "Ammo: " + ammo.ToString();
                    break;
                case Potions.PotionType.HEALTH:
                    // what happens when you pick up health
                    health += 10;
                    AudioSource.PlayClipAtPoint(healthS, Camera.main.transform.position);
                    healthCounter.text = "Health: " + health.ToString();
                    break;
                case Potions.PotionType.SHIELD:
                    shield += 5;
                    AudioSource.PlayClipAtPoint(shieldS, Camera.main.transform.position);
                    shieldCounter.text = "Shield: " + shield.ToString();
                    // what happens when you pick up shield
                    break;
                case Potions.PotionType.MEGA_HEALTH:
                    // what happens when you pick up mega health
                    health += 100;
                    AudioSource.PlayClipAtPoint(megaHealthS, Camera.main.transform.position);
                    healthCounter.text = "Health: " + health.ToString();
                    break;
                case Potions.PotionType.POWER_UP:
                    // what happens when you pick up PowerUp
                    AudioSource.PlayClipAtPoint(powerUPS, Camera.main.transform.position);
                    powerUp = true;
                    break;
            }

            Destroy(other.gameObject);
        }
    }
}
