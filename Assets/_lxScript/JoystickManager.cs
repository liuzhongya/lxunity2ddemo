using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickManager : MonoBehaviour {

    public Joystick joystick;
    public Transform moveTarget;
    public float moveSpeed = 10.0f;

	void Start () {
        joystick.OnTouchMove += OnjoystickMove;

	}
	private void OnjoystickMove(JoystickData joysticData)
    {
        float moveX = Mathf.Cos(joysticData.radians) * moveSpeed *
            Time.deltaTime * joysticData.power;
        float moveZ = Mathf.Sin(joysticData.radians) * moveSpeed *
            Time.deltaTime * joysticData.power;

        moveTarget.Translate(new Vector3(moveX, 0, moveZ));

    }


    // Update is called once per frame
    void Update () {
		
	}
}
