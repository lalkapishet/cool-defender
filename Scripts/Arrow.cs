using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour 
{
	public float Damage;

	void Start () 
	{
		Damage = PlayerPrefs.GetFloat("Damage", Damage);
		PlayerPrefs.SetFloat("Damage", Damage);

		Destroy(gameObject, 10);
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
	
		if(col.tag == "Enemy")
		{
			col.GetComponent<Enemy>().TakeDamage(Damage);
			Destroy(gameObject);
		}

	}

}
