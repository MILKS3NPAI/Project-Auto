using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class Value<T> where T : unmanaged, IComparable<T>, IEquatable<T>
{
	private delegate void SetOperation(Value<T> iSource, T iValue);
	private static SetOperation[] Set = new SetOperation[4]
	{new SetOperation(Value<T>.SetNoBounds),
	new SetOperation(Value<T>.SetLowerBounded),
	new SetOperation(Value<T>.SetUpperBounded),
	new SetOperation(Value<T>.SetWhollyBounded)};
	private int _boundLower, _boundUpper, _boundFunction;
	[SerializeField] private T baseValue, bonusValue, upperBound, lowerBound;
	[SerializeField] private float percentBase, percentBonus, percentTotal;
	public bool mBoundLower { get { return _boundLower == 1; } set { _boundLower = value ? 1 : 0; _boundFunction = _boundLower + _boundUpper; mBaseValue = mBaseValue; } }
	public bool mBoundUpper { get { return _boundUpper == 2; } set { _boundLower = value ? 2 : 0; _boundFunction = _boundLower + _boundUpper; mBaseValue = mBaseValue; } }
	public T mUpperBound { get { return upperBound; } set { upperBound = value; mBoundUpper = true; } }
	public T mLowerBound { get { return lowerBound; } set { lowerBound = value; mBoundLower = true; } }
	public T mBaseValue { get { return baseValue; } set { Set[_boundFunction](this, value); } }
	public T mBonusValue { get { return bonusValue; } set { bonusValue = value; } }
	public float mPercentBase { get { return percentBase; } set { percentBase = value; } }
	public float mPercentBonus { get { return percentBonus; } set { percentBonus = value; } }
	public float mPercentTotal { get { return percentTotal; } set { percentTotal = value; } }
	public T mBase { get { return (dynamic)baseValue * percentBase; } }
	public T mBonus { get { return (dynamic)bonusValue * percentBonus; } }
	public T mValue { get { return ((dynamic)mBase + (dynamic)mBonus) * percentTotal; } }
	public delegate void ValueChangedListener();
	public ValueChangedListener onValueChanged;

	public Value()
	{
		baseValue = (dynamic)0;
	}

	public Value(T iBase)
	{
		baseValue = iBase;
	}

	public Value(T iBase, T iUpperBound)
	{
		mUpperBound = iUpperBound;
		mBaseValue = iBase;
	}

	public Value(T iBase, T iLowerBound, T iUpperBound)
	{
		mUpperBound = iUpperBound;
		mLowerBound = iLowerBound;
		mBaseValue = iBase;
	}

	public Value(Value<T> iValue)
	{
		_boundLower = iValue._boundLower;
		_boundUpper = iValue._boundUpper;
		_boundFunction = iValue._boundFunction;
		baseValue = iValue.baseValue;
		bonusValue = iValue.bonusValue;
		percentBase = iValue.percentBase;
		percentBonus = iValue.percentBonus;
		percentTotal = iValue.percentTotal;
		upperBound = iValue.upperBound;
		lowerBound = iValue.lowerBound;
	}

	public static Value<T> operator +(Value<T> iLeft, Value<T> iRight)
	{
		if ((dynamic)iRight.mValue == 0) { return iLeft; }
		Value<T> lReturn = new Value<T>(iLeft);
		lReturn.upperBound += (dynamic)(iRight.upperBound);
		lReturn.lowerBound += (dynamic)(iRight.lowerBound);
		lReturn.mBaseValue += ((dynamic)iRight.baseValue);
		lReturn.bonusValue += ((dynamic)iRight.bonusValue);
		lReturn.percentBase += iRight.percentBase;
		lReturn.percentBonus += iRight.percentBonus;
		lReturn.percentTotal += iRight.percentTotal;
		return lReturn;
	}

	public static Value<T> operator -(Value<T> iLeft, Value<T> iRight)
	{
		if ((dynamic)iRight.mValue == 0) { return iLeft; }
		Value<T> lReturn = new Value<T>(iLeft);
		lReturn.upperBound -= (dynamic)(iRight.upperBound);
		lReturn.lowerBound -= (dynamic)(iRight.lowerBound);
		lReturn.mBaseValue -= ((dynamic)iRight.baseValue);
		lReturn.bonusValue -= ((dynamic)iRight.bonusValue);
		lReturn.percentBase -= iRight.percentBase;
		lReturn.percentBonus -= iRight.percentBonus;
		lReturn.percentTotal -= iRight.percentTotal;
		return lReturn;
	}

	public static Value<T> operator +(Value<T> iValue, T iAmount)
	{
		if ((dynamic)iAmount == 0) { return iValue; }
		Value<T> lReturn = new Value<T>(iValue);
		lReturn.mBaseValue += (dynamic)iAmount;
		return lReturn;
	}

	public static Value<T> operator -(Value<T> iValue, T iAmount)
	{
		if ((dynamic)iAmount == 0) { return iValue; }
		Value<T> lReturn = new Value<T>(iValue);
		lReturn.mBaseValue -= (dynamic)iAmount;
		return lReturn;
	}

	public void OverflowAdd(T iAmount)
	{
		if ((dynamic)iAmount == 0) { return; }
		if (_boundUpper == 0)
		{
			baseValue += (dynamic)iAmount;
			return;
		}
		dynamic lDifference = (dynamic)upperBound - (dynamic)baseValue;
		baseValue += Mathf.Min(lDifference, (dynamic)iAmount);
		bonusValue += Mathf.Max(0, iAmount - lDifference);
	}

	public void OverflowMinus(T iAmount)
	{
		if ((dynamic)iAmount == 0) { return; }
		dynamic lDifference = (dynamic)iAmount - (dynamic)bonusValue;
		bonusValue -= Mathf.Min((dynamic)bonusValue, lDifference);
		baseValue -= Mathf.Max(0, iAmount - lDifference);
	}

	private static void SetNoBounds(Value<T> iSource, T iValue)
	{
		iSource.baseValue = iValue;
	}
	private static void SetUpperBounded(Value<T> iSource, T iValue)
	{
		iSource.baseValue = Mathf.Min((dynamic)iValue, (dynamic)iSource.upperBound);
	}
	private static void SetLowerBounded(Value<T> iSource, T iValue)
	{
		iSource.baseValue = Mathf.Max((dynamic)iValue, (dynamic)iSource.lowerBound);
	}
	private static void SetWhollyBounded(Value<T> iSource, T iValue)
	{
		iSource.baseValue = Mathf.Max((dynamic)iSource.lowerBound, Mathf.Min((dynamic)iValue, (dynamic)iSource.upperBound));
	}
}