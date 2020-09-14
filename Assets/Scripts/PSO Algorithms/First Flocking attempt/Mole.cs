﻿using UnityEngine;
using System.Collections;

public class Mole : MonoBehaviour
{

	public float speed;
	//public float turnSpeed = 4.0f;
	Vector3 averageHeading;
	Vector3 averagePosition;
	float neighborDistance = 3.0f;

	bool turning = false;

	// Use this for initialization
	void Start()
	{
		speed = Random.Range(0.5f, 1.0f);
	}

	// Update is called once per frame
	void Update()
	{
		ApplyBoundary();

		if (turning)
		{
			Vector3 direction = Vector3.zero - transform.position;
			transform.rotation = Quaternion.Slerp(transform.rotation,
				Quaternion.LookRotation(direction),
				TurnSpeed() * Time.deltaTime);
			speed = Random.Range(0.5f, 1);
		}
		else
		{
			if (Random.Range(0, 5) < 1)
				ApplyRules();
		}

		transform.Translate(0, 0, Time.deltaTime * speed);
	}

	void ApplyBoundary()
	{
		if (Vector3.Distance(transform.position, Vector3.zero) >= GlobalFlock.mapsize)
		{
			turning = true;
		}
		else
		{
			turning = false;
		}
	}

	void ApplyRules()
	{
		GameObject[] gos;
		gos = GlobalFlock.AllMoles;

		Vector3 vCenter = Vector3.zero;
		Vector3 vAvoid = Vector3.zero;
		float gSpeed = 0.1f;

		Vector3 goalPos = GlobalFlock.goalPos;

		float dist;
		int groupSize = 0;

		foreach (GameObject go in gos)
		{
			if (go != this.gameObject)
			{
				dist = Vector3.Distance(go.transform.position, this.transform.position);
				if (dist <= neighborDistance)
				{
					vCenter += go.transform.position;
					groupSize++;

					if (dist < 0.75f)
					{
						vAvoid = vAvoid + (this.transform.position - go.transform.position);
					}

					Mole anothermole = go.GetComponent<Mole>();
					gSpeed += anothermole.speed;
				}

			}
		}

		if (groupSize > 0)
		{
			vCenter = vCenter / groupSize + (goalPos - this.transform.position);
			speed = gSpeed / groupSize;

			Vector3 direction = (vCenter + vAvoid) - transform.position;
			if (direction != Vector3.zero)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation,
					Quaternion.LookRotation(direction),
					TurnSpeed() * Time.deltaTime);
			}
		}

	}

	float TurnSpeed()
	{
		return Random.Range(0.2f, 0.6f);
	}
}