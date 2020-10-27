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

enum LinkType
* all-in-all
