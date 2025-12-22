using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MakeButton : MonoBehaviour
{
    
   private bool physical;
   private GameObject hero;
   
   void Start()
	{
		Debug.Log("im going to kms");
		string temp = gameObject.name;
		gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
		hero = GameObject.FindGameObjectWithTag("Hero");
	}
   public void AttachCallback(string btn)
	{
		Debug.Log("im going to kms");
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
			Debug.Log("run button presse"); 
		}
	}
}
