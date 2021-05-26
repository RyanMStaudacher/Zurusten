using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : PotionAbility
{
    public GameObject fireballPrefab;

    private GameObject playerCamera;
    private bool isOnPlayer = false;

    private GameObject fireball;

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
        if(Input.GetButtonUp("Main Ability") && isOnPlayer)
        {
            CastFireball();
        }
    }

    private void CastFireball()
    {
        fireball = Instantiate(fireballPrefab, playerCamera.transform.position, playerCamera.transform.rotation);
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
