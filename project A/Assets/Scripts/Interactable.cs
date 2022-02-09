using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

#pragma warning disable IDE1006 // Naming Styles
public interface Interactable
{
	void OnClick(Controller iController);
	void OnRelease(Controller iController);
	void OnDrag(Controller iController);
	void Button1(Controller iController);
	void Button2(Controller iController);
	void Button3(Controller iController);
	void OnHover(Controller iController);
	void OnSelect(Controller iController);
	void OnHoverLeave(Controller iController);
}