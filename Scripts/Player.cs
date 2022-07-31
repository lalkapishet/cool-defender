using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	public static Player Inst;

	public float Health;
	public int 	 Cristal;


	public Text	HealthText;
	public Text	CristalText;

	void Awake()
	{
		Inst = this;


		Health = PlayerPrefs.GetFloat("PlayerHealth", 100);
		PlayerPrefs.SetFloat("PlayerHealth", Health);
		HealthText.text = Health.ToString();


		Cristal = PlayerPrefs.GetInt("PlayerCristal", 0);
		CristalText.text = Cristal.ToString();

	}


	public void AddCristal(int cristal)
	{
		Cristal += cristal;

		CristalText.text = Cristal.ToString();
		PlayerPrefs.SetInt("PlayerCristal", Cristal);
	}

	public void TakeDamage(float damage)
	{
		Health -= damage;

		HealthText.text = Health.ToString();
	}

	public void ClearSave()
	{
		PlayerPrefs.DeleteAll();
		Application.LoadLevel(Application.loadedLevel);
	}


}
