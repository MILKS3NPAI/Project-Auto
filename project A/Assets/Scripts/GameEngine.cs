using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
	[SerializeField] private Camera _mainCamera;
	public static Camera sMainCamera { get { return sEngine._mainCamera; } private set { sEngine._mainCamera = value; } }
	private static bool initialized = false;
	public static GameEngine sEngine { get; private set; }
	public static Grid sGrid { get; private set; }

	void Awake()
	{
		sEngine = this;
		Initialize();
	}

	public static void Initialize()
	{
		if (initialized)
		{
			return;
		}
		sMainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		initialized = true;
		sGrid = GameObject.FindObjectOfType<Grid>();
	}

	public static Vector3 WorldToCell(Vector3 iPosition)
	{
		return sGrid.CellToWorld(sGrid.WorldToCell(iPosition));
	}

	public static Interactable CheckForInteractables(Vector3 iPosition)
	{
		Collider[] lResults = Physics.OverlapSphere(iPosition, Enumeration.sSelectionRadius, Enumeration.INTERACTABLE_MASK);
		//Debug.Log("POW!");
		//Debug.DrawLine(iPosition, iPosition + (Vector3.up * 5));
		if (lResults.Length > 0)
		{
			return (Interactable)lResults[0].GetComponent<Entity>();
		}
		return null;
	}

	public static Vector3 MouseToWorld(Vector2 iMousePosition)
	{
		Ray lRay = sMainCamera.ScreenPointToRay(iMousePosition);
		RaycastHit lHit = new RaycastHit();
		Physics.Raycast(lRay, out lHit, 100f, Enumeration.GROUND_MASK);
		return lHit.point;
	}
}
