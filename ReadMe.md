# Программа выполняет отслеживание погодных условий.
### В программе используются Asp.Net Core, EntityFramework

#### Настройка перед первым использованием
1. Задать подключение к БД в файле "appsettings.json"
2. Сделать миграцию для создание бд.
	Например, в консоли диспетчеров пакетов "add-migration init".
3. Для заполнения тестовыми данными. Сделать запрос "{applicationUrl}/init".

#### Комады для получения данных через апи:
* погода сейчас в выбранном городе [в определённой стране]:
    + {applicationUrl}/today/{city}
    + {applicationUrl}/today/{city}/{country}
*  погода на пять дней в выбранном городе [в определённой стране]:
    + {applicationUrl}/fivedays/{city}
    + {applicationUrl}/fivedays/{city}/{country}
#### Комады для получения данных из БД:
* Всё содержимое
    + {applicationUrl}/db/all
*Запросы текущей погоды [в определённом городе]
	+ {applicationUrl}/current
	+ {applicationUrl}/current/{city}
* Запросы погоды на пять дней [в определённом городе]
	+ {applicationUrl}/fiveedays
	+ {applicationUrl}/fivedays/{city}
---
Владимир Таранчук
