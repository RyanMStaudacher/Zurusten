using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alchemist : MonoBehaviour, IHero
{
    public float health { get; set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string ReturnName()
    {
        return this.GetType().ToString();
    }

    public void Attack1()
    {
        throw new System.NotImplementedException();
    }

    public void Attack2()
    {
        throw new System.NotImplementedException();
    }

    public void UltimateAbility()
    {
        throw new System.NotImplementedException();
    }

    public void UseEquipment1()
    {
        throw new System.NotImplementedException();
    }

    public void UseEquipment2()
    {
        throw new System.NotImplementedException();
    }

    public void UseEquipment3()
    {
        throw new System.NotImplementedException();
    }
}
