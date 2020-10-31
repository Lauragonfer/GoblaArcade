﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public GameObject bulletPrefab;
	public GameObject shooter;

	private Transform _firePoint;



	void Awake()
	{
		_firePoint = transform.Find("FirePoint");
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			Shoot();
		}
	}

	public void Shoot()
	{
		if (bulletPrefab != null && _firePoint != null && shooter != null) {
			GameObject myBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;

			Bullet bulletComponent = myBullet.GetComponent<Bullet>();

			if (shooter.transform.localScale.x < 0f) {
				bulletComponent.direction = Vector2.left; // new Vector2(-1f, 0f)
			} else {
				bulletComponent.direction = Vector2.right; // new Vector2(1f, 0f)
			}
		}
	}
}
