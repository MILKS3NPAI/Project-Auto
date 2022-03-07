using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[ExecuteInEditMode]
public class BoardBuilder : MonoBehaviour
{
	[SerializeField] bool rebuildBoard = false;
	[SerializeField] GameObject tilePrefab;
	[SerializeField] Vector2Int boardSize = new Vector2Int();
	public Vector2Int mBoardSize { get { return boardSize; } protected set { boardSize = value; } }

	public void OnGUI()
	{
		if (rebuildBoard)
		{
			rebuildBoard = false;
			if (tilePrefab == null)
			{
				Debug.LogError("No tile prefab assigned. Assign one before trying to build the board.", this);
				return;
			}
			int lBreak = 200;
			while (transform.childCount > 0 && lBreak-- > 0)
			{
				GameObject.DestroyImmediate(transform.GetChild(0).gameObject);
			}
			for (int y = 0; y < boardSize.y; y++)
			{
				for (int x = 0; x < boardSize.x; x++)
				{
					GameObject lTile = Instantiate(tilePrefab, transform);
					if (y % 2 == 0)
					{
						lTile.transform.position = (2 * (x * Enumeration.sHexDifX)) + (y * Enumeration.sHexDifZ);
					}
					else
					{
						lTile.transform.position = (2 * (x * Enumeration.sHexDifX)) + (y * Enumeration.sHexDifZ) + Enumeration.sHexDifX;
					}
					if (x % 3 == 0)
					{
						lTile.transform.position = new Vector3(lTile.transform.position.x, .05f, lTile.transform.position.z);
					}
					else if (x % 3 == 1)
					{
						lTile.transform.position = new Vector3(lTile.transform.position.x, -.05f, lTile.transform.position.z);
					}
					else
					{
						lTile.transform.position = new Vector3(lTile.transform.position.x, 0, lTile.transform.position.z);
					}
					lTile.name = x + ", " + y;
				}
			}
		}
	}
}