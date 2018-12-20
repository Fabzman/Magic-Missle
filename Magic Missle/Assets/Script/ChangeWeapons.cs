using UnityEngine;
using System.Collections;

public class ChangeWeapons : MonoBehaviour 
{
    //Declare WeaponsArray of GameObjects + set in Unity
    public GameObject[] weaponsSwap;

    void Start () 
    {
        Cursor.visible = false;//hide cursor

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
    }

    //function(passedValue)
        //for (1 to WeaponsArray.Length)
            //if (loopValue == passedValue)
                //WeaponsArray [current element].SetActive(true)
            //else 
                //WeaponsArray [current element].SetActive(false)
}
