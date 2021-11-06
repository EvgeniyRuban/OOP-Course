
# Code Style Guide (STS) #

В 90% случаев предполагается придерживаться стандарта [MS](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/index). Здесь же будут описаны отличия, от этого стандарта.

# ОБЯЗАТЕЛЬНО #
#### 1. Tab vs Space.  ###
Только **табы**.   

*Мотивация*: Именно потому что количество пробелов в табе каждый может настроить под себя, мы используем табы.  


#### 2. Количество символов в строке. ####
**140** символов


#### 3. Фигурные скобки.  ###
**Все что может быть ограничено фигурными скобками**, *за искключением простых лямбда-выражений*, **должно быть** ими **ограничено**.   
**Каждая** фигурная скобка **в новой строке**.

*Мотивация*:
* Однородность кода.  
* Во избежания позитивного (безконфликтного) мержа, который сломает логику.   

 Из-за простоты восприятия, снижается вероятность ошибки когда кто-то закомментирует строчку после if/while и т.п. и следующая строка станет считаться телом оператора. Или когда не заметим проблем после мержа.

*Пример*
```C#
if(Ok) 
    return OkResult;  // Bad

if(Ok) //Good
{    
    return OkResult;
}

```


#### 4. Расположение аргументов. ####
Если при опеределении сигнатуры метода приходится переносить аргументы, то надо переносить каждый, начиная с первого:

```C#
//BAD
Result Foo(int len, double x, double y, double z, Delta delta, ...);

var foorResult = someObje.Foo(len, x, y, z, delta, ...);


//GOOD
Result Foo(
     int len,
     double x,
     double y,
     double z,
     Delta delta,
     ...);

var foorResult = someObje.Foo(
    len,
    x,
    y,
    z,
    delta,
    ...);
```


## Конструирование типов ##
#### 1. Уровни доступа классов. ####
**Все классы**, доступ к которым из вне не предполагается, должны быть помечены как ***internal***.   
Также должны быть помечены все их поля/методы/свойства, которые, в обычной ситуации, были бы помечены как *public*.  

*Мотивация*: У библиотеки должен быть четкий набор «интерфейсных» классов. Все остальные классы должны быть скрыты от клиента.


#### 2. Неявная реализация интерфейсов. ####
Класс может реализывывать интерфейс **неявно**, **только если** помечен как ***internal***. 


#### 3. Закрытость (*sealed*) классов. ####
**Все классы**, для которых, на данном этапе, не предполагается создание наследников, должны быть помечены как ***sealed***.  

*Мотивация*: Необходимо четко разделять что клиент может расширить, а что не должно расширяться за счет наследования. 


#### 4 . Уровни доступа и расположение в коде. ####
Код должен распологаться по уровню доступа в классе следующим образом:
1. **Fields**   
    a. public static   
    b. public   
    c. internal static   
    d. internal    
    e. protected static  
    f. protected  
    g. private static    
    h. private    
2. **Constructor**   
    a. public static  
    ...  
    h. private   
3. **public static**          
    a. properties  
    b. methods    
4. **public**       
    a. properties  
    b. methods  
5. **internal static**         
    a. ...  
6. **internal**     
    a. ...  
7. **protected static**    
    a. ...  
8. **protected**    
    a. ...  
9. **private static**    
    a. properties  
    b. methods  
10. **private**      
    a. properties      
    b. methods      
    
*Пример*
```C#
// !!! Bad !!!
class Persone
{	
        //...
        public Address Position{ get; set; }

 	private readonly string _firstNamename;
	
	protected strign SomeProperty{get;}
	
	public Person(Date dateOfBirth, string firs...)
        {
                ...
        }
	
	private Persone(Date dateOfBirth, string firs...)
	{
	}
	
	
        public string FirstName => _firstName;
        public string LastName
	{
		get => _lastName;
		set{ _lastName= value; }
	}
        
	private readonly Date _dateOfBirth;
	
	private string _lastName;
	 
        private string FormFullInfo()
        {
                ....
        }
        
        public override string ToString()
        {
                ....
        }
        
}

//----------------------------------------------------------------------
// GOOD:
class Persone
{        
	public Date DateOfBirth;
        protected readonly string _firstNamename;
        private string _lastName;


        public Person(Date dateOfBirth, string firs...): this(...)
        {
                ...
        }


	private Person(Date dateOfBirth, string firs...)
        {
                ...
        }

        
        public Address Position{ get; set; }
        
	
	public string FirstName => _firstName;
        
	
	public string LastName
	{
		get => _lastName;
		set{ _lastName= value; }
	}


        public override string ToString()
        {
                ....
        }


        protected strign SomeProperty{get;}
	
	
	protected virtual int Foo()
	{
		....
	}
	
			
	private Persone(Date dateOfBirth, string firs...)
	{
	}
        
	
        private string FormFullInfo()
        {
                ....
        }       
        
        //...        
}
```


#### 5. Регионы. ####
**НЕиспользовать регионы**.   
*Исключение - специфичные классы, с большим количеством полей (DTO)*.  
  
*Мотивация*: В регионах может прятаться много кода.


#### 6. Стрелки в однострочных методах. #### 
Допускаются стрелки при орпеделении "однострочных" (однооператорных) методов.  
Исключение, когда однострочный превращается в длинный многострочный.
```c#
//GOOD
public int Len(string source) =>srouce?.Length??-1; 

//BAD
public async Task<IReadOnlyCollection<Person>> GetFullName(
	Filter filter,
	string sessionId,
	IUserClientService service)=> (await service.GetPresonsByFilterAsync(filter, sessionId).ConfigureAwait(false))?
		.Select(Map)
		.ToList()
		.AsReadOnly()?? Array.Empty<Person>() as IReadOnlyCollection<Person>;
		
//GOOD
public async Task<IReadOnlyCollection<Person>> GetFullName(
	Filter filter,
	string sessionId,
	IUserClientService service)
{ 
	var result = await service.GetPresonsByFilterAsync(filter, sessionId).ConfigureAwait(false);
	if(result == null)
	{
		return Array.Empty<Person>();
	}
	
	return result.Select(Map).ToList().AsReadOnly()
}

```


#### 7. Магические числа. ####
**Константы**, в худшем случае, должны быть определены статическими полями только для чтения (*const or static readonly*). Правильно - **выносить в конфигурации**.  
**Магические числа** в коде **запрещены**.



# Рекомендуется #
## Форматирование кода ##
#### Пустая строка между частями кода. ####
Между двумя "смежными методами" (методом и полем, методом и свойством, и т.д.) должно быть ДВЕ пустые строки, В то время как между строками кода, там где это нужно, не должно быть более одной пустой строки.

*Мотивация*: Такое расставление пустых строк в коде повышает уровень его воспрятия.

--------------------------------------------------------------------------------------------------------------------
  
    
       
         
--------------------------------------------------------------------------------------------------------------------
# Общие заметки по коду (на подумать) #
#### 1. "Только для чтения" ####
В классах поля должны быть скрыты, доступ предоставляется только через свойста или методы.  
В (readonly) структурах readonly поля должны быть публичными

*Мотивация*: Т.к. свойства являются лишь синтаксическим сахаром (в действительности являются методами), то, в случае классов, скрывая поля и предоставляя к ним доступ посредствам свойст и методов, мы остаемся в парадигме ООП. В случае структур - открытие readonly полей является элементом оптимизации, как и сами структуры.  

*Пример*
```C#
//BAD
class Person
{
	public readonly string FirstName;   
}

//BAD
struct Person
{
	public string FirstName;   
	public string LastName{get;}
	//...
}


//GOOD
class Person
{
        public string FirstName{get;}        
        public string LastName => _lastName;
        //....
        
        private readonly string _lastName;
}

//GOOD
readonly struct Person
{
	public readonly string FirstName;   
	public readonly string LastName;
	//...
	public Person(/*...*/){/*...*/}
}

//GOOD
class Catalog
{
        public IReadOnly<Item> Items => _items.AsReadOnly();        
        //....
}
```

#### 2. Struct vs Class ####
Надо четко понимать, структуры были созданы лишь для оптимизации работы с памятью. Отсюда, надо отдавать им предпочтение, если выполняются условия:  
* Данные не будут изменятся за время жизни "объекта"   
* Объем "полезных" данных близок к 16 байтам  
* Нет частого копирования   

Если вышеуказанные условия выполнены, то дополнительным плюсом будут такие требования:  
* Данные должны храниться близко в памяти (желательно большая часть помещаться в кэш процессора)    
* Данные должны максимально просто и быстро удаляться (т.е. желательно отчисткой стека, а не работой GC).    

При этом, структура должна быть *полностью readonly*: Сама структура и все ее **поля** должны быть readonly. Такого типа структуры не подразумивают наличие свойств, методов, рализации интерфейсов и т.д.  

*Мотивация*: Оптимизация производительности и работы с памятью.

#### 3. Релазиации интерфейсов. ####
При реализации интерфейсов в классах, необходимо делать, по возможности, явную (explicit) реализацию. 

*Мотивация*: Явная реализация интерфейса способствует тому, чтобы клинет не использовал класс напрямую.   
*Ремарка*: Если некоторый метод, реализующий интерфейс, используется в других метода самого класса, то имеет смысл сделать его приватную/защещенную реализацию, и во всех интерфейсных использовать именно ее.

#### 4. IDisposable. ####
a. Если нет неуправляемх ресурсов **НЕ создавать** финализатора.  
b. Если класс помечен как sealed, и именно он реализует IDisposable, реализовывать интерфейс напрямую.

*Мотивация*: оптимизация работы GC.


#### 5. Readonly коллекции. ####
Если предпологается возвращать (или получать на вход) ограниченной коллекции только для чтения, то в качестве результата надо возвращать (или принимать как аргумент) именно коллекции отнаследованные от одного из интерфейсов семейства IReadOnly*<>.

*Мотивация*: Такой код четко говорит, что возвращается неизменяемая коллекция. Т.е. не изменяется ни ее длинна, ни ее элементы (надо понимать, что состояние отдельного элемента можно изменить, через его методы и свойства). Если же речь о входном параметре, то код говорит что данные не будут изменены. 

#### 6. Работа с IEnumerable<>. ####
Существует два варианта:

1. Как возвращаемый результат, IEnumerable<> стоит использовать, только в том случае, если метод является либо отложенным вычислением, либо генератором. В противном случае, лучше возвращать более конкретные коллекции.
*Пример*:
```C#
//BAD
IEnumerable<int> CreateRange(int len, int defVal)
{
        var result = new int[len];
        for(int i =0; i < len; ++i) 
	{
		result[i] = defVal;
	}
		
	return result;
}

//GOOD 
int[] CreateRange(int len, int defVal) // or IReadOnlyCollection<int> - если хотим вернуть неизменяемую.
{
        var result = new int[len];
        for(int i =0; i < len; ++i) 
	{
		result[i] = defVal;
	}
	
	return result;
}


//GOOD (для примера)
public static IEnumerable<int> FilterOnlyOdd(this IEnumerable<int> source)
{
	foreach(var itr in source) 
	{
        	if(itr % 2 != 0) 
		{
			yield  return itr;
		}
        }
}
```  

2. Если IEnumerable<> приходит в качестве аргумента, если метод **НЕ** явялется "отложенным" вычеслением над входным аргументом, то он **НЕ** должен принимать IEnumerable<>, но если все-таки приходится, то необходимо первым шагом сделать терминирующую операцию над коллекцией, с ограничением на допустимое колличество элементов. 
*Пример*:
```C#
//BAD 
int CountOnlyOdd(IEnumerable<int> source)
{
	long count = 0;
	foreach(var itr in source) 
	{
        	if(itr % 2 != 0) 
		{
			count++;
		}
        }
	
	return count;
}

//GOOD 
int CountOnlyOdd(IEnumerable<int> source) //WARN: лучше принимать на вход ограниченную коллекцию.
{
	var bufSource = source.Take(Int32.Max); //WARN: должно быть разумное ограничение.
	int count = 0;
	foreach(var itr in bufSource) 
	{
        	if(itr % 2 != 0) 
		{
			count++;
		}
        }
	
	return count;
}

```
*Мотивация*:   
	1. IEnumerable<> - это отложенное вычисление  
	2. Нет гарантии что IEnumerable<> это ограниченная коллекция
	

#### 7. Точки возврата. ####
Допускается множественный вовзрат из функции.

#### 8. Разработка async / sycn API ####
При реализации асинхронного API, в каждый метод API добавлять два дополнительных входных параметра: `CancellationToken token` и `bool continueOnCapturedContext`. И реализовывать код в следующем виде:

```c#
public async Task<string> FooAsync(
    /*другие аргументы функции*/,
    CancellationToken token, 
    bool continueOnCapturedContext)
{
    // ...
    await Task.Delay(30, token).ConfigureAwait(continueOnCapturedContext);
    // ...
    return result;
}
```

Первый параметр, `token` - служит для возможности скоординированной отмены.  Второй, `continueOnCapturedContext` - позволяет настроить взаимодействие с контекстом синхронизации внутренних асинхронных вызовов.

#### 9. Смешивание async / sycn. ####
 1. Всеми силами избегайте блокировок. Другими словами, не смешивайте синхронный и асинхронный код без особой необходимости.
 2. Если приходится делать блокировку, то определите, в каком окружении выполняется код:
    * Есть ли контекст синхронизации? Если да, то какой? Какие особенности в работе он создает?
    * Если контекста синхронизации "нет", то, какова будет нагрузка? Какова вероятность что ваша блокировка приведет к "утечки" потоков из пула? Хватит ли того числа потоков, что создается на старте, по умолчанию, или надо выделить больше?
