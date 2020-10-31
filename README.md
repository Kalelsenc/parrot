# parrot
## Архитектура
* Базовый интерфейс нейрона - INeuron<Input type, Output type>

* Базовый класс слоя - NeuroLay

* Контейнер слоев - NeuroContainer : INeuron<Vector2, String>

<Image src="resources/parrot.png"></Image>


# NeuroLay
 ```
  NeuroLay<ANeuron>
  NeuroLay<SNeuron>
 ```
 Methods
 
* 

# NeuroContainer
Хранит список NueroLay

Получает на вход список Точек, возвращает строку/массив с коээфицентами линейной/квадратичной функции

По умолчанию содержит два слоя:
1) SensorLay
2) SumLay

### Methods
```
setLay<Type>(int size, LinkType)
String/Array run(List<Vector2> array)
```

# Vector2
```
double x, y;
Vector2(double x, double y)
```

# enum LinkType
* all-in-all

### Логика взаимодействия NeuroLay

Передаем слою сенсоров набор элементов
Запускается рекурсию вплоть до последнего слоя
В каждый слой поступает набор данных следующего вида
* id = 1 -> 0.1, 0.5, 0.008, .... , 0.3
* id = 2 -> 0.3, 0.13, 0.28, .... , 0.65
* ....
* id = n -> 0.1, 0.0001, 0.99, .... , 0.24

То есть по сути двумерная матрица, где 1-n -> id нейронов

В следующий слой поступают списки, где говорится, какое значение в какой нейрон передать

Эти значения - обработанные предыдущим слоем входные сигналы

Текущий слой их обрабатывает, пакует в такие же списки и передает дальше

