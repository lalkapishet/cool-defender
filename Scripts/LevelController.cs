using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour 
{
	public static LevelController Inst;

	public static int	Level = 1;

	public Spawner spawner;

	public Text	LevelText;

	[Header("UI")]

	public GameObject	DefeatPanel;
	public GameObject	PassedPanel;

	void Awake()
	{
		Inst = this;

		InvokeRepeating("CheckLevelState", 0.5f, 0.5f);	
	}

	void Start()
	{
		Level = PlayerPrefs.GetInt("Level", 1);

		LevelText.text = Level.ToString();
	}

	void CheckLevelState()
	{
		if(spawner.countSpawnPrefabs == 0) // Если спавнер больше не спавнит
		{
			if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0) // Если врагов на карте больше нет
			{
				PassedLevel(); // Прошли уровень
			}
		}

		if(Player.Inst.Health <= 0)
		{
			DefeatLevel();
		}
	}

	public void DefeatLevel()
	{
		Debug.Log("Проиграл");

		DefeatPanel.SetActive(true);

		CancelInvoke("CheckLevelState");
	}

	public void PassedLevel()
	{
		Debug.Log("Выйграл");

		PassedPanel.SetActive(true);

		Level += 1;

		PlayerPrefs.SetInt("Level", Level);

		CancelInvoke("CheckLevelState");
	}
	
}
