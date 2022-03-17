using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class Buff
{
	[SerializeField] public EntityStats modification;
	[SerializeField] private float _timeDuration = 0f;
	[SerializeField] public float mTimeDuration { get { return _timeDuration; } set { _timeDuration = value; } }
}
