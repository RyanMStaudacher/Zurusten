using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : PotionAbility
{
    public GameObject fireballPrefab;

    private GameObject playerCamera;
    private bool isOnPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        if(CheckIfOnPlayer())
        {
            playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Main Ability") && isOnPlayer)
        {
            CastFireball();
        }
    }

    private void CastFireball()
    {
        Instantiate(fireballPrefab, playerCamera.transform.position, Quaternion.identity);
    }

    public bool CheckIfOnPlayer()
    {
        if(this.gameObject.CompareTag("Player"))
        {
            isOnPlayer = true;
        }

        return isOnPlayer;
    }
}
