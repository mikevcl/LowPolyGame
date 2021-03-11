using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindingPlayer : MonoBehaviour
{

	#region Singleton

	public static FindingPlayer instance;

	void Awake()
	{
		instance = this;
	}

	#endregion

	public GameObject player;

}