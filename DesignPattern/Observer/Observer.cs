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
옵저버 패턴, 감시자 패턴
델리게이트로 구현 할 수도있다.
https://ko.wikipedia.org/wiki/옵서버_패턴
https://ansohxxn.github.io/design%20pattern/chapter12/
*/
public interface IObserver
{
	public abstract void notify(int num);
}

public interface ISubject
{
	public abstract void registerObserver(IObserver observer);
	public abstract void unregisterObserver(IObserver observer);
	public abstract void notifyObservers();
}

public class ConcreteObserverA : IObserver
{
	Subject sub;
	const string name = "human";
	public int health{get;set;} = 0;
	public ConcreteObserverA(Subject sub)
	{
		this.sub = sub; 
	}
	public void notify(int num)
	{
		health += 10;
		WriteLine("A health += 10");
		WriteLine($"parameter num : {num} ");
		WriteLine($"field value num : {sub.getNum()}");
		return;
	}
}

public class ConcreteObserverB : IObserver
{
	const string name = "vampire";
	public int health{get;set;} = 0;
	public void notify(int num)
	{
		health -= 10;
		WriteLine("B health -= 10");
		WriteLine($"parameter num : {num} ");
		return;
	}
}


public class Subject : ISubject
{
	private int num = -20;
	private List<IObserver> observerCollection = new List<IObserver>();
	public void registerObserver(IObserver observer)
	{
		observerCollection.Add(observer);
	}

	public void unregisterObserver(IObserver observer)
	{
		observerCollection.Remove(observer);
	}
	
	public void notifyObservers()
	{
		foreach (var observer in observerCollection)
		{
			observer.notify(this.getNum());
			Console.WriteLine("--------");
		}
	}

	public int getNum() => num;
}

public class MainClass
{
	static void Main()
	{
		Subject sub = new Subject();
		IObserver a = new ConcreteObserverA(sub);
		IObserver b = new ConcreteObserverB();
		sub.registerObserver(a);
		sub.registerObserver(b);
		sub.notifyObservers();
	}
}