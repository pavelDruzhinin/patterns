## Проблема

У нас есть пульт управления умным домом, к которому необходимо написать API. Если реализовывать "в лоб", то мы должны будем напрямую на каждую кнопку вкл/выкл "вешать" методы приборов. При изменении нам придется править общий код, в котором присутствуют неизменяемые вещи. Поэтому удобнее воспользоваться паттерном Команда, который позволит инкапсулировать изменяющееся поведение

## Паттерн Команда

Инкапсулирует запрос в виде объекта, делая возможной параметирезацию клиентских объектов с другими запросами, организацию очереди или регистрацию запросов, а так же поддержку отмены операций.