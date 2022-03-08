using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EntityStats
{
	//HP, HP_MAX, MOVE_SPEED, MANA_MAX, MANA, PHYSICAL_ATTACK, MAGIC_ATTACK, ARMOR, MAGIC_RESIST, RANGE
	[SerializeField] private Value<int>[] entityStats = new Value<int>[Enumeration.ArraySize<Stat>()];
	public int mHP { get { return entityStats[(int)Stat.HP].mValue; } }
	public int mMaxHP { get { return entityStats[(int)Stat.HP].mValue; } }
	public int mMoveSpeed { get { return entityStats[(int)Stat.HP].mValue; } }
	public int mMaxMana { get { return entityStats[(int)Stat.HP].mValue; } }
	public int mPhysicalAttack { get { return entityStats[(int)Stat.HP].mValue; } }
	public int mMagicAttack { get { return entityStats[(int)Stat.HP].mValue; } }
	public int mArmor { get { return entityStats[(int)Stat.HP].mValue; } }
	public int mMagicResist { get { return entityStats[(int)Stat.HP].mValue; } }
	public int mRange { get { return entityStats[(int)Stat.HP].mValue; } }

	public int GetStat(Stat iStat)
	{
		return entityStats[(int)iStat].mValue;
	}

	public void SetStat(Stat iStat)
	{

	}
}