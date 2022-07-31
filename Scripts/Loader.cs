using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
	public void LoadLevel(string level)
	{
		Application.LoadLevel(level);
	}

}
