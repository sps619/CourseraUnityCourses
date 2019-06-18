using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
	Rigidbody2D rgbd;
	Vector2 thrustDirection = new Vector2(1,0);
	const float RotateDegreesPerSecond = 50;
	const float ThrustForce = 2;
	float radiusOfCollider;
	float rotationAxis;
	// Start is called before the first frame update
	void Start()
	{   rgbd = GetComponent<Rigidbody2D>();
		radiusOfCollider = gameObject.GetComponent<CircleCollider2D>().radius;
	}

	// Update is called once per frame
	void FixedUpdate()
	{   ///Checking for thrust input
		if(Input.GetAxis("Thrust") > 0)
		{
			rgbd.AddForce(ThrustForce * thrustDirection, ForceMode2D.Force);
		}
		///Storing Rotate Axis 
		float rotationAxis = Input.GetAxis("Rotate");
		/// Checking for rotation axis
		if(rotationAxis!=0)
		{float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
		if(rotationAxis>0)
		{
		rotationAmount *= 1;
		print("RotationAMount"+rotationAmount);
		}
		else if(rotationAxis<0)
		{
		rotationAmount *= -1;
		print("RotationAMount"+rotationAmount);
		}
		///Rotating the object
		transform.Rotate(Vector3.forward, rotationAmount);
		///Applying the thrust
		thrustDirection = new Vector2(Mathf.Cos(90+transform.eulerAngles.z * Mathf.Deg2Rad ), Mathf.Sin(90+transform.eulerAngles.z * Mathf.Deg2Rad ));
	}}

	///Called when the object gets invisible from the screen
	void OnBecameInvisible()
	{   Vector2 position = transform.position;
		/// For Screen Wrapping
		if(position.x > ScreenUtils.ScreenRight)
			position.x = ScreenUtils.ScreenLeft;
		else if(position.x < ScreenUtils.ScreenLeft)
			position.x = ScreenUtils.ScreenRight;
		if(position.y > ScreenUtils.ScreenTop)
			position.y = ScreenUtils.ScreenBottom;
		else if(position.y < ScreenUtils.ScreenBottom)
			position.y = ScreenUtils.ScreenTop;
		transform.position = position;
	}
}
