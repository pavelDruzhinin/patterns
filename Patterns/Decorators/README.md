## Проблема

У нас есть кофейня Starbuzz, в которой может меняться динамически меню и покупатели могут заказать кофе с любыми добавками, причем каждый продукт и добавки имеют свою стоимость. Если идти "в лоб", то мы должны с каждым разом увеличивать количество классов и усложнять формулу подсчета стоимости заказа.

## Паттерн Декоратор

Динамически наделяет объект новыми возможностями, и является гибкой альтернативой субклассированию в области расширения функциональности. (Под субклассированием скорей всего понимается множественное наследование от классов, которое возможно в Java и в какой-то мере реализовано в C# последней версии)

### Примечание

Пример, в какой-то мере высосан из пальца, так как такую задачу в реальности решает база данных и реализация обычной системы заказов, как в интернет-магазине. 

Лучше примеры приведены в книге это FileInputStream, который декорируется с помощью абстрактного класса FilterInputStream в Java.

Так же сейчас декорирование во многих языках программирования присутсвует в виде реализации аттрибутов, например аттрибут Authorize в ASP.NET MVC.