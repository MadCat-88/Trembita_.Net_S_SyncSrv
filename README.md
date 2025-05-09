# Синхронний .NET C# SOAP-сервіс з підтримкою системи «Трембіта»

SOAP-сервіс, описаний в даній інструкції, розроблений на мові програмування C# з використанням .Net і є сумісним з системою «Трембіта».

.Net - це безкоштовна платформа з відкритим вихідним кодом для розробки програмного забезпечення, яка підтримує кілька мов програмування, бібліотек та інструментів для створення застосунків під різні операційні системи.

Даний сервіс передбачає отримання з бази даних (реєстру) відомостей про інформаційні об'єкти (користувачів) та управління їх статусом, у тому числі обробку запитів на пошук, отримання, створення, редагування та видалення об'єктів.

Для демонстрації інтеграції з системою «Трембіта» було розроблено [вебклієнт](https://github.com/MadCat-88/Trembita_.Net_S_SyncCli) для роботи з даним вебсервісом.

## Інсталяція сервісу
Для інсталяції вебсервісу необхідно клонувати репозиторій та скомпілювати вебсервіс, наприклад, за допомогою "Microsoft Visual Studio" з урахуванням типу ОС віртуальної машини (фізичного сервера) на якій буде працювати даний вебсервіс.

**Примітка** Для повноцінної працездатносі даного вебсервісу необхідно клонувати репозиторій [синхронного REST-сервісу](https://github.com/MadCat-88/Trembita_.Net_S_SyncSrv)

## Ознайомлення з вебінтерфейсом

Після запуску вебсервісу можна отримати доступ до його вебінтерфейсу за наступною адресою:

- http://[адреса серверу]:8000/Service.svc

## Завантаження WSDL

Після запуску вебсервісу WSDL можна завантажити за адресами: 
- http://[адреса серверу]:8000/Service.svc?wsdl
- http://[адреса серверу]:8000/Service.svc?singleWsdl

## Наповнення бази даних тестовими записами

Для забезпечення зручності тестування розробленого вебсервісу потрібно наповнити його БД тестовими записами.
З цією метою було розроблено окремий скрипт, інсталяція та робота з яким описані [тут](https://github.com/MadCat-88/Trembita_PutFakeData_SOAP)

**Примітка:** При використанні даного скрипта в його налаштуваннях необхідно змінити порт на якому працює вебсервіс.

## Інтеграція вебсервісу з системою «Трембіта»

Системи «Трембіта» не вимагає особливої спеціалізації вебсервісів для роботи з нею. Для повноцінної інтеграції з системою «Трембіта» вебсервіс повинен підтримувати можливість зберігання заголовків системи «Трембіта», які було передані в запиті від вебкліента через ШБО.

Більш детальну інформацію про заголовки наведено в описі [заголовків запитів для SOAP-сервісів](https://github.com/nataLee-git/Services-development-for-Trembita-system/blob/main/SOAP%20services%20development%20for%20Trembita%20system.md#%D0%B7%D0%B0%D0%B3%D0%BE%D0%BB%D0%BE%D0%B2%D0%BA%D0%B8-%D0%B7%D0%B0%D0%BF%D0%B8%D1%82%D1%96%D0%B2-%D0%B4%D0%BB%D1%8F-soap-%D1%81%D0%B5%D1%80%D0%B2%D1%96%D1%81%D1%96%D0%B2-%D0%BD%D0%B5%D0%BE%D0%B1%D1%85%D1%96%D0%B4%D0%BD%D1%96-%D0%B7%D0%B0%D0%B4%D0%BB%D1%8F-%D0%B7%D0%B0%D0%B1%D0%B5%D0%B7%D0%BF%D0%B5%D1%87%D0%B5%D0%BD%D0%BD%D1%8F-%D1%81%D1%83%D0%BC%D1%96%D1%81%D0%BD%D0%BE%D1%81%D1%82%D1%96-%D0%B7-%D1%81%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%BE%D1%8E-%D1%82%D1%80%D0%B5%D0%BC%D0%B1%D1%96%D1%82%D0%B0).

## Використання сервісу

Вебсервіс представляє собою набір з 4 методів, які дозволяють управляти записами про умовних користувачів (Person) в БД:

- [створення нового запису](./docs/using.md#create-person);
- [отримання запису по заданому критерію пошуку](./docs/using.md#get-person-by-parameter);
- [оновлення існуючого запису за кодом УНЗР](./docs/using.md#edit-person);
- [видалення існуючого запису за кодом УНЗР](./docs/using.md#delete-person-by-unzr).

Після встановлення вебсервісу його база даних порожня.
Для демонстрації можливостей вебсервісу першим кроком необхідно створити нові записи в БД. Це можна зробити використовуючи відповідний [вебклієнт](https://github.com/MadCat-88/Trembita_.Net_S_SyncCli), з використанням методу [Person Post](./docs/using.md#person-post) або за допомогою [скрипта наповнення бази даних](./README.MD#наповнення-бази-даних-тестовими-записами).

## Ліцензія

Цей проєкт ліцензується відповідно до умов MIT License.

 ##
Матеріали створено за підтримки проєкту міжнародної технічної допомоги «Підтримка ЄС цифрової трансформації України (DT4UA)».

