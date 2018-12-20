using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour {

    [System.Serializable]
public enum PotionType
    {
        AMMO,
        HEALTH,
        SHIELD,
        MEGA_HEALTH,
        POWER_UP
    }

    public PotionType type;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        switch (type)
    //        {
    //            case PotionType.AMMO:
    //                // what happens when you pick up ammo
    //                break;
    //            case PotionType.HEALTH:
    //                // what happens when you pick up health
    //                break;
    //            case PotionType.SHIELD:
    //                // what happens when you pick up shield
    //                break;
    //            case PotionType.MEGA_HEALTH:
    //                // what happens when you pick up mega health
    //                break;
    //            case PotionType.POWER_UP:
    //                // what happens when you pick up PowerUp
    //                break;
    //        }
    //        Destroy(gameObject);
    //    }
    //}

    //[System.Serializable]
    //public enum Pickups
    //{
    //    VALUE1,
    //    VALUE2,
    //    VALUE3,
    //    ETC
    //}

    //public Pickups ammo;
    //public Pickups health;
    //public Pickups shield;
    //public Pickups megaHealth;
    //public Pickups powerUp;
}
