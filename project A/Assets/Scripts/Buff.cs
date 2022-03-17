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
	[SerializeField] private bool _unique = false;
	public bool mUnique { get { return _unique; } set { _unique = value; } }
	[SerializeField] private float _timeRemaining = 0f;
	public float mTimeRemaining { get { return _timeRemaining; } }
	public bool mTimed { get { return _timeDuration > 0; } }
	Entity target = null;

	public static void AddToEntity(Entity iEntity, Buff iBuff)
	{
		if (iBuff.target == null)
		{
			iEntity.AddBuff(iBuff);
		}
		else
		{
			iBuff.target.RemoveBuff(iBuff);
			iEntity.AddBuff(iBuff);
		}
		iBuff.target = iEntity;
	}

	public Buff(EntityStats iStatChanges)
	{
		modification = iStatChanges;
	}

	public void Tick(float iTimeDelta)
	{
		if (mTimed)
		{
			_timeRemaining -= iTimeDelta;
			if (_timeRemaining <= 0f)
			{
				target.RemoveBuff(this);
				target = null;
				_timeRemaining = mTimeDuration;
			}
		}
	}
}
