Save__Your__Apps - приложение, которое помогает создавать, сохранять приложения, показывать количесвто запросов к приложению. В его написании мне очень помогли такие источники информации как сайт Metanit, раздел Руководство по ASP.NET Core 5, книги: ASP.NET Core Разработка приложений James Chambers, David Paquerre, Simon Timms; Pro ASP.NET Core MVC 2, Adam Freeman; Entity Framework Core 2 для ASP.NET Core MVC для профессионалов
Чтобы открыть образ нужно ввести команду:docker push 47836783209/saveyoourapps:tagname
Ссылка на образ: https://hub.docker.com/repository/docker/47836783209/saveyoourapps
Для работы приложения понадобится база postgres. В файле config нужно прописать свои строки для подключения
Запросы get и post можно делать из поисковой строки или командной, например
Для командной строки curl -i -X "GET" "https://127.0.0.1:порт/api/event/айди приложения"
В поисковой строке: https://localhost:49153/api/event/айди приложения


На случай если приложение не откроется, потому что я за это переживаю, то можно просто посмотреть на красивую картинку:
![image](https://user-images.githubusercontent.com/96973326/171040282-d88cc8ed-ceb5-4cb9-889c-9aef17261ae0.png)
Спасибо!)
