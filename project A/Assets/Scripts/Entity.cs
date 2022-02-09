using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, Interactable
{
	public Vector3 mProjectedPosition { get; set; }
	public Vector3 mPosition { get { return transform.position; } set { transform.position = value; } }
	public Vector2 mPosition2D { get { return mPosition; } set { mPosition = new Vector3(value.x, mPosition.y, value.y); } }
	public bool mBeingMoved { get; protected set; }

	public void Button1(Controller iController)
	{
		throw new System.NotImplementedException();
	}

	public void Button2(Controller iController)
	{
		throw new System.NotImplementedException();
	}

	public void Button3(Controller iController)
	{
		throw new System.NotImplementedException();
	}

	public void OnClick(Controller iController)
	{
		mBeingMoved = true;
		mProjectedPosition = iController.transform.position;
	}

	public void OnDrag(Controller iController)
	{
		mProjectedPosition = iController.transform.position;
	}

	public void OnHover(Controller iController)
	{
		throw new System.NotImplementedException();
	}

	public void OnHoverLeave(Controller iController)
	{
		throw new System.NotImplementedException();
	}

	public void OnRelease(Controller iController)
	{
		mBeingMoved = false;
	}

	public void OnSelect(Controller iController)
	{
		throw new System.NotImplementedException();
	}

	protected virtual void FixedUpdate()
	{
		DragMove();
	}

	public void DragMove()
	{
		if (mBeingMoved)
		{
			mPosition = Vector3.MoveTowards(mPosition, mProjectedPosition, Time.fixedDeltaTime * Mathf.Max(Vector3.Distance(mPosition, mProjectedPosition), 4f));
			Debug.Log(mPosition + " moving toward " + mProjectedPosition);
		}
	}
}
