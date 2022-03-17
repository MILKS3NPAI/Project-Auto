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
	public int mHP { get { return entityIntStats[(int)IntStat.HP].mValue; } set { SetStat(IntStat.HP, value); } }
	public int mMaxHP { get { return entityIntStats[(int)IntStat.HP_MAX].mValue; } set { SetStat(IntStat.HP_MAX, value); } }
	public int mMoveSpeed { get { return entityIntStats[(int)IntStat.MOVE_SPEED].mValue; } set { SetStat(IntStat.MOVE_SPEED, value); } }
	public int mMana { get { return entityIntStats[(int)IntStat.MANA].mValue; } set { SetStat(IntStat.MANA, value); } }
	public int mMaxMana { get { return entityIntStats[(int)IntStat.MANA_MAX].mValue; } set { SetStat(IntStat.MANA_MAX, value); } }
	public int mPhysicalAttack { get { return entityIntStats[(int)IntStat.PHYSICAL_ATTACK].mValue; } set { SetStat(IntStat.PHYSICAL_ATTACK, value); } }
	public int mMagicAttack { get { return entityIntStats[(int)IntStat.MAGIC_ATTACK].mValue; } set { SetStat(IntStat.MAGIC_ATTACK, value); } }
	public int mArmor { get { return entityIntStats[(int)IntStat.ARMOR].mValue; } set { SetStat(IntStat.ARMOR, value); } }
	public int mMagicResist { get { return entityIntStats[(int)IntStat.MAGIC_RESIST].mValue; } set { SetStat(IntStat.MAGIC_RESIST, value); } }
	public int mRange { get { return entityIntStats[(int)IntStat.RANGE].mValue; } set { SetStat(IntStat.RANGE, value); } }
	public int mRawShield { get { return entityIntStats[(int)IntStat.RAW_SHIELD].mValue; } set { SetStat(IntStat.RAW_SHIELD, value); } }
	public int mPhysicalShield { get { return entityIntStats[(int)IntStat.PHYSICAL_SHIELD].mValue; } set { SetStat(IntStat.PHYSICAL_SHIELD, value); } }
	public int mMagicShield { get { return entityIntStats[(int)IntStat.MAGIC_SHIELD].mValue; } set { SetStat(IntStat.MAGIC_SHIELD, value); } }
	public float mAttackSpeed { get { return entityFloatStats[(int)FloatStat.ATTACK_SPEED].mValue; } set { SetStat(FloatStat.ATTACK_SPEED, value); } }
	public float mHP_REGEN { get { return entityFloatStats[(int)FloatStat.HP_REGEN].mValue; } set { SetStat(FloatStat.HP_REGEN, value); } }
	public float mMANA_REGEN { get { return entityFloatStats[(int)FloatStat.MANA_REGEN].mValue; } set { SetStat(FloatStat.MANA_REGEN, value); } }
	public delegate void IntValueChangeListener(Value<int> iPrevious, Value<int> iNew);
	public delegate void FloatValueChangeListener(Value<float> iPrevious, Value<float> iNew);
	public delegate void IntChangeListener(int iPrevious, int iNew);
	public delegate void FloatChangeListener(float iPrevious, float iNew);
	public IntValueChangeListener[] intValueChanged = new IntValueChangeListener[Enumeration.ArraySize<IntStat>()];
	public FloatValueChangeListener[] floatValueChanged = new FloatValueChangeListener[Enumeration.ArraySize<FloatStat>()];

	protected void CallListener(IntStat iStat, Value<int> iPrev, Value<int> iNew)
	{
		intValueChanged[(int)iStat](iPrev, iNew);
	}

	protected void CallListener(FloatStat iStat, Value<float> iPrev, Value<float> iNew)
	{
		floatValueChanged[(int)iStat](iPrev, iNew);
	}

	public void DeregisterCallback(IntStat iStat, IntValueChangeListener iCallback)
	{
		intValueChanged[(int)iStat] -= iCallback;
	}

	public void DeregisterCallback(IntStat iStat, FloatValueChangeListener iCallback)
	{
		floatValueChanged[(int)iStat] -= iCallback;
	}

	public void RegisterCallback(IntStat iStat, IntValueChangeListener iCallback){
		intValueChanged[(int)iStat] += iCallback;
	}

	public void RegisterCallback(FloatStat iStat, FloatValueChangeListener iCallback)
	{
		floatValueChanged[(int)iStat] += iCallback;
	}

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

	public void SetStat(FloatStat iStat, Value<float> iValue)
	{
		if (iValue == entityFloatStats[(int)iStat]) { return; }
		Value<float> lPrev = new Value<float>(entityFloatStats[(int)iStat]);
		entityFloatStats[(int)iStat] = iValue;
		floatValueChanged[(int)iStat](lPrev, entityFloatStats[(int)iStat]);
	}

	public void SetStat(IntStat iStat, Value<int> iValue)
	{
		if (iValue == entityIntStats[(int)iStat]) { return; }
		Value<int> lPrev = new Value<int>(entityIntStats[(int)iStat]);
		entityIntStats[(int)iStat] = iValue;
		intValueChanged[(int)iStat](lPrev, entityIntStats[(int)iStat]);
	}

	public void SetStat(IntStat iStat, int iValue)
	{
		if (iValue == 0) { return; }
		Value<int> lPrev = new Value<int>(entityIntStats[(int)iStat]);
		entityIntStats[(int)iStat].mBaseValue = iValue;
		intValueChanged[(int)iStat](lPrev, entityIntStats[(int)iStat]);
	}

	public void SetStat(FloatStat iStat, float iValue)
	{
		if (iValue == 0) { return; }
		Value<float> lPrev = new Value<float>(entityFloatStats[(int)iStat]);
		entityFloatStats[(int)iStat].mBaseValue = iValue;
		floatValueChanged[(int)iStat](lPrev, entityFloatStats[(int)iStat]);
	}

	public static EntityStats operator +(EntityStats iLeft, EntityStats iRight)
	{
		EntityStats lReturn = new EntityStats(iLeft);
		lReturn += iRight;
		return lReturn;
	}
}