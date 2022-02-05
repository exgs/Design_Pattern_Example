using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using static System.Console;
using System.Threading.Tasks;
using System.Collections.Generic;

/*
팩토리 패턴(클래스 버전)
델리게이트로 구현 할 수도있다.
*/

public interface Paper
{
	public abstract void print();
}

public abstract class MoneyPaper : Paper
{
	protected int value;
	public virtual void print()
	{
		WriteLine($"Value: {value}");
	}
}

public class OneThousand : MoneyPaper
{
	public OneThousand()
	{
		value = 1000;
	}

	~OneThousand()
	{
		WriteLine("~OneThousand()");
	}
}

public class TenThousand : MoneyPaper
{
	public TenThousand()
	{
		value = 10000;
	}
	~TenThousand()
	{
		WriteLine("~TenThousand()");
	}
}

public class Bank
{
	private Paper money;

	public void setMoney(MoneyFactory.MoneyType type)
	{
		this.money = MoneyFactory.makeMoney(type);
	}
	
	public void DoStuff()
	{
		WriteLine("I cant do something with money");
		money.print();
	}
}

public class MoneyFactory
{
	public enum MoneyType
	{
		OneThousand,
		TenThousand
	};

	static public Paper makeMoney(MoneyType type)
	{
		Paper temp = null;
		if (type == MoneyFactory.MoneyType.OneThousand)
		{
			temp = new OneThousand();
		}
		else if (type == MoneyFactory.MoneyType.TenThousand)
		{
			temp = new TenThousand();
		}
		return (temp);
	}
}

public class MainClass
{
	static void Main()
	{
		Bank ibk = new Bank();
		ibk.setMoney(MoneyFactory.MoneyType.TenThousand);
		ibk.DoStuff();
	}
}