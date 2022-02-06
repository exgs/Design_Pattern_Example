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

책에서 본 예제처럼 한 번 객체의 메소드 호출을 위해서 new로 생성한 후에 저장하지 않는 것은 너무 많은 객체 생성을 야기할 것 같아서,
	MoneyFactory의 메소드에서 생성한 객체를 Bank의 멤버변수에 할당하는 것으로 클래스의 구조를 변형시켰다.
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