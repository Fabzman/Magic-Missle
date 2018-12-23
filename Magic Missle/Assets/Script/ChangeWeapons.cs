using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ChangeWeapons : MonoBehaviour 
{
    //Declare WeaponsArray of GameObjects + set in Unity
    public GameObject[] weaponsSwap;
    public PlayerStats player;
    public GameObject magicShield;
    public Renderer shieldRenderer;

    void Start () 
    {
        Cursor.visible = false;//hide cursor
        player = GetComponentInParent<PlayerStats>();
        //set weapon to default
    }

    void Update () 
    {
        //if Input "1"
        if (Input.GetKeyDown (KeyCode.Alpha1))
        //call function(0);
        {
            weaponsSwap[0].SetActive(true);
            weaponsSwap[1].SetActive(false);
            weaponsSwap[2].SetActive(false);
        }
        //if Input "2"
        if (Input.GetKeyDown(KeyCode.Alpha2))
        //call function(1);
        {
            weaponsSwap[0].SetActive(false);
            weaponsSwap[1].SetActive(true);
            weaponsSwap[2].SetActive(false);
        }
        //if Input "3"
        if (Input.GetKeyDown(KeyCode.Alpha3))
        //call function(2);
        {
            weaponsSwap[0].SetActive(false);
            weaponsSwap[1].SetActive(false);
            weaponsSwap[2].SetActive(true);
        }
        //if Input "4"
        if (Input.GetKeyDown(KeyCode.Alpha4))
        //call function(3);
        {

        }

        //if (Input.GetKey(KeyCode.E))
        //{
        //    player.shield -= Time.deltaTime;
        //    Color materialColor = shieldRenderer.material.color;
        //    materialColor.a = 0.5F;
        //    shieldRenderer.material.color = materialColor;
        //}

        //if (Input.GetKeyUp(KeyCode.E))
        //{
        //    Color materialColor = shieldRenderer.material.color;
        //    materialColor.a = 0.0F;
        //    shieldRenderer.material.color = materialColor;
        //}

        //if (Input.GetKeyDown(KeyCode.E) && player.shield > 0)
        if (Input.GetButtonDown("Fire2") && player.shield > 0)
        {
            shieldRenderer.material.DOFade(0.5F, 1F);
        }
        //else if (Input.GetKeyUp(KeyCode.E))
        else if (Input.GetButtonUp("Fire2"))
        {
            shieldRenderer.material.DOFade(0F, 1F);
        }

        //if (Input.GetKey(KeyCode.E) && player.shield > 0)
        if (Input.GetButtonDown("Fire2") && player.shield > 0)
        {
            player.shield -= Time.deltaTime;
            if (player.shield <= 0)
                shieldRenderer.material.DOFade(0F, 1F);
        }
    }

    //function(passedValue)
        //for (1 to WeaponsArray.Length)
            //if (loopValue == passedValue)
                //WeaponsArray [current element].SetActive(true)
            //else 
                //WeaponsArray [current element].SetActive(false)
}
