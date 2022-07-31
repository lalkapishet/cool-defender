using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour 
{

	public GameObject 	Arrow;

	public float		FireRate;
	public float		ShotPower;

	float		TimeLastFire;

	void Start()
	{
		FireRate = PlayerPrefs.GetFloat("FireRate", FireRate);
		PlayerPrefs.SetFloat("FireRate", FireRate);
	}

	void Update ()
	{
		if(Input.GetMouseButton(0))
		{
			// ПОВОРОТ
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //положение мыши из экранных в мировые координаты

			float angle = Vector2.Angle(Vector2.up, mousePosition - transform.position);//угол между вектором от объекта к мыше и осью х

			if (transform.position.x < mousePosition.x)
				angle = -angle;

			transform.eulerAngles = new Vector3(0f, 0f, angle); // Поворачиваем арбалет

			// СТРЕЛЬБА
			TimeLastFire += Time.deltaTime;

			if(TimeLastFire >= FireRate) // Сбрасываем таймер и спавнем выстрел
			{
				TimeLastFire = 0;

				GameObject arrow = Instantiate(Arrow, transform.position, Quaternion.identity); // Создаем стрелы

				arrow.GetComponent<Rigidbody2D>().AddForce(transform.up * ShotPower, ForceMode2D.Impulse); // Добавляем импульс стреле

				arrow.transform.eulerAngles = new Vector3(0f, 0f, angle); // Поворачиваем на тот же угол что и арбалет
			}
				
		}
	}






}
