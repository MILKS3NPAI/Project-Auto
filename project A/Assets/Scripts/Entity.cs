using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, Interactable
{
	protected delegate void GameStateAction();
	protected GameStateAction[] gameStateActions = new GameStateAction[Enumeration.ArraySize<GameState>()];
	protected delegate void EntityStateAction();
	protected EntityStateAction[] stateActions = new EntityStateAction[Enumeration.ArraySize<EntityState>()];
	public Vector3 mProjectedPosition { get; set; }
	public Vector3 mPosition { get { return transform.position; } set { transform.position = value; } }
	public Vector2 mPosition2D { get { return mPosition; } set { mPosition = new Vector3(value.x, mPosition.y, value.y); } }
	public bool mBeingMoved { get; protected set; }
	public Rigidbody mBody { get; protected set; }
	public EntityState mState { get { return _state; } set { _state = value; } }
	bool gravity = false;
	[SerializeField] private EntityState _state;

	protected virtual void Awake()
	{
		mBody = GetComponent<Rigidbody>();
		gravity = mBody.useGravity;
		for (int i = 0; i < stateActions.Length; i++)
		{
			stateActions[i] = DoNothing;
		}
		gameStateActions[(int)GameState.PLANNING] = DoPlanningState;
		gameStateActions[(int)GameState.BATTLING] = DoBattlingState;
	}

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
		mProjectedPosition = iController.transform.position + Vector3.up * 2f;
		mBody.useGravity = false;
	}

	public void OnDrag(Controller iController)
	{
		mProjectedPosition = iController.transform.position + Vector3.up * 2f;
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
		StartCoroutine(FinishMovement());
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
			mPosition = Vector3.MoveTowards(mPosition, mProjectedPosition, Time.fixedDeltaTime * Mathf.Max(Vector3.Distance(mPosition, mProjectedPosition), Enumeration.sPieceDragSpeed));
			Debug.Log(mPosition + " moving toward " + mProjectedPosition);
		}
	}

	IEnumerator FinishMovement()
	{
		while (Vector3.Distance(mPosition, mProjectedPosition) >= Time.fixedDeltaTime * Enumeration.sPieceDragSpeed)
		{
			yield return new WaitForFixedUpdate();
		}
		mBeingMoved = false;
		mBody.useGravity = gravity;
	}

	void DoPlanningState() { }

	void DoBattlingState(){
		stateActions[(int)mState]();
	}

	void DoNothing()
	{
	}
}
