﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
	public static KeyCode attackKey = KeyCode.E;
	public static KeyCode freezeAttackKey = KeyCode.Alpha1;
	public static KeyCode breakAttackKey = KeyCode.Alpha2;
	public static KeyCode jumpKey = KeyCode.W;
	public static string HorizontalMovementAxis = "Horizontal";

	[SerializeField]
	private KeyCode attackKeyBinding = attackKey;
	[SerializeField]
	private KeyCode jumpKeyBinding = jumpKey;

	// Called when the values are updated in the editor
	private void OnValidate()
	{
		attackKey = attackKeyBinding;
		jumpKey = jumpKeyBinding;
	}
}
