using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
	public Vector2 mPosition2D { get { return new Vector2(transform.position.x, transform.position.z); } protected set { transform.position = new Vector3(value.x, transform.position.y, value.y); } }
	public Interactable selectedObject { get; protected set; }
	public bool mCursorHeld { get { return _cursorHeld; } protected set { _cursorHeld = value; } }
	[SerializeField] bool _cursorHeld = false;
	public Transform handOfGod { get; protected set; }
	public bool mCursorValid { get; protected set; }

	public virtual void Awake()
	{
		InitializeReferences();
	}

	public virtual void InitializeReferences()
	{
		if (handOfGod == null)
		{
			handOfGod = ((GameObject)Instantiate(new GameObject("Hand"), transform)).transform;
			handOfGod.position = transform.position;
		}
	}

	protected virtual void CursorClick(bool iClick)
	{
		Debug.Log("Click? " + iClick);
		mCursorHeld = iClick;
		if (iClick)
		{
			CheckForInteractables();
			if (selectedObject != null)
			{
				selectedObject.OnClick(this);
				//Debug.Log("Clicked on " + selectedObject);
			}
		}
		else
		{
			if (selectedObject != null)
			{
				selectedObject.OnRelease(this);
				//Debug.Log("Released " + selectedObject);
			}
		}
	}

	protected virtual void CursorMove(Vector2 iPosition)
	{
		mPosition2D = iPosition;
		if (mCursorHeld && selectedObject != null)
		{
			selectedObject.OnDrag(this);
		}
	}

	protected virtual void Sell(bool iPressed)
	{
	}

	public virtual void CheckForInteractables()
	{
		selectedObject = GameEngine.CheckForInteractables(transform.position);
		//Debug.Log("Selecting Object: " + selectedObject);
	}
}
