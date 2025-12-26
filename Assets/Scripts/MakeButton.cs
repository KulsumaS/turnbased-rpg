using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MakeButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private bool physical;
    private GameObject hero;

    void Start()
    {
        string temp = gameObject.name;
        hero = GameObject.FindGameObjectWithTag("Hero");
    }

    private void AttachCallback(string btn)
    {
        if (btn.CompareTo("Meleebt") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("melee");
        }
        else if (btn.CompareTo("Rangedbt") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("range");
        }
        else
        {
            hero.GetComponent<FighterAction>().SelectAttack("run");
        }
    }
}
