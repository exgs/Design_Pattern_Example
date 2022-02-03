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
두 가지 특징이 있다.
1. 싱글톤은 프로그램에서 인스턴스가 단 하나
2. 싱글톤은 프로그램에서 전역적으로 접근이 가능해야한다.

static과 싱글톤의 차이
1. static으로 작성하지 않는 이유는 싱글톤일 경우에 클래스의 상속 속성을 계속해서 이용할 수 있다는 점
2. static과 싱글톤의 차이점
	static: 오브젝트 풀링처럼 실행 초기에 초기화된다.
	싱글톤: 처음 인스턴스를 사용하려는 시점에 생성된다.
	프로그램의 성능과 목적에 따라서 선택할 수 있다.

싱글톤은은 전역변수라는 점에서 멀티쓰레드일떄 문제가 더욱 극명하게 나타난다.

*/

public class Singleton
{
	public int age{get;set;}
	public string name{get;set;}
	
	public void printAll()
	{
		WriteLine($"{name}.{age}");
	}

	private Singleton(){}
	private static object obj = new object();
	private static Singleton _instance;
	public static Singleton instance()
	{
		if (_instance == null)
		{
			_instance = new Singleton();
		}
		return _instance;

		/* 멀티쓰레드를 경우에 조금 더 안전하게 사용하고 싶다면
		if (_instance == null)
		{
			lock (obj)
			{
				_instance = new Singleton();
			}
		}
		*/
		return _instance;
	}
}

public class MainClass
{
	static void Main()
	{
		Singleton.instance().age = 28;
		Singleton.instance().name = "yunslee";
		Singleton.instance().printAll();
	}
}
