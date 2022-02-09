using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
	private PlayerInput input;

	public override void Awake()
	{
		base.Awake();
		InitializeInput();
	}

	public void InitializeInput()
	{
		if (input == null)
		{
			input = new PlayerInput();
		}
		input.KeyboardAndMouse.MoveCursor.performed += cxt => this.CursorMove(cxt.ReadValue<Vector2>());
		input.KeyboardAndMouse.LeftClick.performed += cxt => CursorClick(cxt.ReadValueAsButton());
		input.KeyboardAndMouse.LeftClick.canceled += cxt => CursorClick(cxt.ReadValueAsButton());
		input.Enable();
		//Debug.Log("Input successfully initialized.");
	}

	protected override void CursorMove(Vector2 iPosition)
	{
		transform.position = GameEngine.MouseToWorld(iPosition);
		//Vector3 lVec = GameEngine.WorldToCell(transform.position);
		//transform.position = new Vector3(lVec.x, lVec.z, lVec.y);
		if (mCursorHeld && selectedObject != null && transform.position != Vector3.zero)
		{
			selectedObject.OnDrag(this);
		}
	}
}
