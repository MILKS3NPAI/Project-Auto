using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Enumeration
{
	public static LayerMask INTERACTABLE_MASK = LayerMask.GetMask(new string[] { "Interactable", });
	public static LayerMask GROUND_MASK = LayerMask.GetMask(new string[] { "Terrain", });
	public static float sSelectionRadius = .5f;
	public static float sPieceDragSpeed = 10f;
	public static Vector3 sHexDifX = new Vector3(.5f, 0, 0);
	public static Vector3 sHexDifZ = new Vector3(0, 0, .745f);


	public static unsafe int BoolToInt(bool iBool)
	{
		return (*(byte*)&iBool & 0x0001b);
	}

	public static Array EnumArray<T>()
	{
		return Enum.GetValues(typeof(T));
	}
	public static string[] EnumNames<T>()
	{
		return Enum.GetNames(typeof(T));
	}
	public static string FormattedName<T>(T lValue, bool lCapitalizeAll = true)
	{
		StringBuilder lInitial = new StringBuilder(Enum.GetName(typeof(T), lValue).ToLower());
		lInitial = lInitial.Replace('_', ' ');
		lInitial[0] = Char.ToUpper(lInitial[0]);
		if (lCapitalizeAll)
		{
			for (int i = 1; i < lInitial.Length; i++)
			{
				if (lInitial[i - 1] == ' ')
				{
					lInitial[i] = Char.ToUpper(lInitial[i]);
				}
			}
		}
		return lInitial.ToString();
	}
	public static int ArraySize<T>()
	{
		return Enum.GetValues(typeof(T)).Length;
	}
}
