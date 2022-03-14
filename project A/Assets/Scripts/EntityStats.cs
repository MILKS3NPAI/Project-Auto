using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EntityStats
{
	//HP, HP_MAX, MOVE_SPEED, MANA_MAX, MANA, PHYSICAL_ATTACK, MAGIC_ATTACK, ARMOR, MAGIC_RESIST, RANGE, RAW_SHIELD, PHYSICAL_SHIELD, MAGIC_SHIELD
	[SerializeField] private Value<int>[] entityIntStats = new Value<int>[Enumeration.ArraySize<IntStat>()];
	[SerializeField] private Value<float>[] entityFloatStats = new Value<float>[Enumeration.ArraySize<FloatStat>()];
	public int mHP { get { return entityIntStats[(int)IntStat.HP].mValue; } set { entityIntStats[(int)IntStat.HP].mBaseValue = value; } }
	public int mMaxHP { get { return entityIntStats[(int)IntStat.HP_MAX].mValue; } set { entityIntStats[(int)IntStat.HP_MAX].mBaseValue = value; } }
	public int mMoveSpeed { get { return entityIntStats[(int)IntStat.MOVE_SPEED].mValue; } set { entityIntStats[(int)IntStat.MOVE_SPEED].mBaseValue = value; } }
	public int mMana { get { return entityIntStats[(int)IntStat.MANA].mValue; } set { entityIntStats[(int)IntStat.MANA].mBaseValue = value; } }
	public int mMaxMana { get { return entityIntStats[(int)IntStat.MANA_MAX].mValue; } set { entityIntStats[(int)IntStat.MANA_MAX].mBaseValue = value; } }
	public int mPhysicalAttack { get { return entityIntStats[(int)IntStat.PHYSICAL_ATTACK].mValue; } set { entityIntStats[(int)IntStat.PHYSICAL_ATTACK].mBaseValue = value; } }
	public int mMagicAttack { get { return entityIntStats[(int)IntStat.MAGIC_ATTACK].mValue; } set { entityIntStats[(int)IntStat.MAGIC_ATTACK].mBaseValue = value; } }
	public int mArmor { get { return entityIntStats[(int)IntStat.ARMOR].mValue; } set { entityIntStats[(int)IntStat.ARMOR].mBaseValue = value; } }
	public int mMagicResist { get { return entityIntStats[(int)IntStat.MAGIC_RESIST].mValue; } set { entityIntStats[(int)IntStat.MAGIC_RESIST].mBaseValue = value; } }
	public int mRange { get { return entityIntStats[(int)IntStat.RANGE].mValue; } set { entityIntStats[(int)IntStat.RANGE].mBaseValue = value; } }
	public int mRawShield { get { return entityIntStats[(int)IntStat.RAW_SHIELD].mValue; } set { entityIntStats[(int)IntStat.RAW_SHIELD].mBaseValue = value; } }
	public int mPhysicalShield { get { return entityIntStats[(int)IntStat.PHYSICAL_SHIELD].mValue; } set { entityIntStats[(int)IntStat.PHYSICAL_SHIELD].mBaseValue = value; } }
	public int mMagicShield { get { return entityIntStats[(int)IntStat.MAGIC_SHIELD].mValue; } set { entityIntStats[(int)IntStat.MAGIC_SHIELD].mBaseValue = value; } }
	public float mAttackSpeed { get { return entityFloatStats[(int)FloatStat.ATTACK_SPEED].mValue; } set { entityFloatStats[(int)FloatStat.ATTACK_SPEED].mBaseValue = value; } }
	public float mHP_REGEN { get { return entityFloatStats[(int)FloatStat.HP_REGEN].mValue; } set { entityFloatStats[(int)FloatStat.HP_REGEN].mBaseValue = value; } }
	public float mMANA_REGEN { get { return entityFloatStats[(int)FloatStat.MANA_REGEN].mValue; } set { entityFloatStats[(int)FloatStat.MANA_REGEN].mBaseValue = value; } }

	public EntityStats()
	{
	}

	public EntityStats(EntityStats iSource)
	{
		for (int i = 0; i < entityIntStats.Length; i++)
		{
			entityIntStats[i] = iSource.entityIntStats[i];
		}
		for (int i = 0; i < entityFloatStats.Length; i++)
		{
			entityFloatStats[i] = iSource.entityFloatStats[i];
		}
	}

	public Value<int> GetRawStat(IntStat iStat)
	{
		return entityIntStats[(int)iStat];
	}

	public Value<float> GetRawStat(FloatStat iStat)
	{
		return entityFloatStats[(int)iStat];
	}

	public int GetStat(IntStat iStat)
	{
		return entityIntStats[(int)iStat].mValue;
	}

	public float GetStat(FloatStat iStat)
	{
		return entityFloatStats[(int)iStat].mValue;
	}

	public void SetStat(IntStat iStat, int iValue)
	{
		entityIntStats[(int)iStat].mBaseValue = iValue;
	}

	public void SetStat(FloatStat iStat, float iValue)
	{
		entityFloatStats[(int)iStat].mBaseValue = iValue;
	}

	public static EntityStats operator +(EntityStats iLeft, EntityStats iRight)
	{
		EntityStats lReturn = new EntityStats(iLeft);
		lReturn += iRight;
		return lReturn;
	}
}