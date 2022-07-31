using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrater : MonoBehaviour
{
	public int			CostUpgrateFireRate;
	public int			CostUpgrateDamage;
	public int			CostUpgrateHealth;

	public Text			CostFireRateText;
	public Text			CostDamageText;
	public Text			CostHealthText;


	void Start()
	{
		CostUpgrateFireRate = PlayerPrefs.GetInt("CostUpgrateFireRate", CostUpgrateFireRate);
		CostUpgrateDamage = PlayerPrefs.GetInt("CostUpgrateDamage", CostUpgrateDamage);
		CostUpgrateHealth = PlayerPrefs.GetInt("CostUpgrateHealth", CostUpgrateHealth);
	}

	public void UpgrateFireRate()
	{
		if(Player.Inst.Cristal >= CostUpgrateFireRate) 
		{
			// Улучшаем скорострельность
			float fireRate = PlayerPrefs.GetFloat("FireRate");
			fireRate -= 0.01f;
			PlayerPrefs.SetFloat("FireRate", fireRate);

			// Обновляем кристалы у игрока
			Player.Inst.AddCristal(-CostUpgrateFireRate);

			// Обновляем цены
			CostUpgrateFireRate += 10;
			PlayerPrefs.SetInt("CostUpgrateFireRate", CostUpgrateFireRate);
			UpdateCostText();

		
		}

	}

	public void UpgrateDamage()
	{
		if(Player.Inst.Cristal >= CostUpgrateDamage) 
		{
			// Улучшаем скорострельность
			float damage = PlayerPrefs.GetFloat("Damage");
			damage += 2;
			PlayerPrefs.SetFloat("Damage", damage);

			// Обновляем кристалы у игрока
			Player.Inst.AddCristal(-CostUpgrateDamage);

			// Обновляем цены
			CostUpgrateDamage += 10;
			PlayerPrefs.SetInt("CostUpgrateDamage", CostUpgrateDamage);
			UpdateCostText();
		}

	}

	public void UpgrateHealth()
	{
		if(Player.Inst.Cristal >= CostUpgrateHealth) 
		{
			// Улучшаем скорострельность
			float health = PlayerPrefs.GetFloat("PlayerHealth");
			health += 2;
			PlayerPrefs.SetFloat("PlayerHealth", health);

			// Обновляем цены
			CostUpgrateHealth += 10;
			PlayerPrefs.SetInt("CostUpgrateHealth", CostUpgrateHealth);
			UpdateCostText();
		}

	}

	public void UpdateCostText()
	{
		CostFireRateText.text = CostUpgrateFireRate.ToString();
		CostDamageText.text = CostUpgrateDamage.ToString();
		CostHealthText.text = CostUpgrateHealth.ToString();
	}



}
