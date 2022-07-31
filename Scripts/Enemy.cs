using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
	public float Speed;

	public float Damage;
	public float DamageRate;
	public float DamageBorder;

	public float Health;


	[Header("UI")]

	public Image	HPBarFill;

	float TimeLastDamage;
	float MaxHealth;

	void Start()
	{
		Health = 100 + LevelController.Level * 2;
		Speed += LevelController.Level * 0.01f;
			
		MaxHealth = Health;
	}

	void Update () 
	{
		transform.position += new Vector3(-1, 0, 0) * Speed * Time.deltaTime;

		if(transform.position.x <= DamageBorder)
		{
			Speed = 0; // Останавливаем врага

			TimeLastDamage += Time.deltaTime;

			if(TimeLastDamage >= DamageRate)
			{
				TimeLastDamage = 0;

				Player.Inst.TakeDamage(Damage);
			}

		}
	}

	public void TakeDamage(float damage)
	{
		Health -= damage;

		HPBarFill.fillAmount = Health / MaxHealth;

		if(Health <= 0)
		{
			Player.Inst.AddCristal(LevelController.Level);
			Destroy(gameObject);
		}
	}
}
