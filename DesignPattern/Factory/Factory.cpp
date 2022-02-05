#include <iostream>
#include <string>

using namespace std;

class Language
{
	public:
		virtual string text() = 0;
		virtual ~Language() // `delete Language` 했을 때, 오버라이드 된 소멸자부터 차례대로 호출한다.
		{
			cout << "Deconstructor Language" << endl;
		}
};

class Korean : public Language
{
	public :
		string text()
		{
			return ("안녕하세요");
		}
	private :
		~Korean()
		{
			cout << "Deconstructor Korean" << endl;
		}

};

class English : public Language
{
	public :
		string text()
		{
			return ("hello");
		}
	private:
		~English()
		{
			cout << "Deconstructor Korean" << endl;
		}
};

class LanguageFactory
{
	public :
		static string ENGLISH;
		static string KOREAN;
	public :
		static Language* getInstance(string lang)
		{
			if (lang == LanguageFactory::ENGLISH)
			{
				return (new English());
			}
			else if (lang == LanguageFactory::KOREAN)
			{
				return (new Korean());
			}
			else
			{
				return nullptr;
			}
		}
};

class Translate
{
	private :
		Language *lang;
	public :
		Translate()
		{

		}
		Translate(Language *lang)
		{
			this->lang = lang;
		}

		void talk(string countryName)
		{
			Language *temp = LanguageFactory::getInstance(countryName);
			cout << temp->text() << endl;
			delete temp;
		}

		void talk()
		{
			if (lang == NULL)
				cout << "Use 'void talk(string countryName)'" << endl;
			else
				cout << this->lang->text() << endl;
		}
};

// static 변수는 클래스 내부에서 값을 할당할 수 없음
// 데이터 영역에서 미리 값을 할당해줘야함
string LanguageFactory::ENGLISH = "en";
string LanguageFactory::KOREAN = "ko";

int main()
{
	Translate *ee = new Translate();
	ee->talk("ko");

	#pragma region "Factory 패턴에서는 절차지향적인 부분의 코드에서 new를 쓰는 것을 허용하지 않을 것 같음, 즉 생성자를 private으로 두는 것이 맞는 패턴으로 생각됨"
	Korean *ko = new Korean();
	#pragma endregion

	Translate *temp = new Translate(ko);
	temp->talk();
	return (0);
}