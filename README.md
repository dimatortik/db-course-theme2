
# Шаблон репозиторію для виконання курсової роботи з дисципліни "Бази даних"

## Як використовувати

В цьому репозиторії знаходиться шаблон для виконання курсової роботи.

Для виконання курсової роботи необхідно зробити ```fork``` цього репозіторію, склонувати вже власний репозіторій та розміщувати документацію у відповідних діректоріях ```./docs```.

В цьому файлі необхідно вказати назву проекту. Коротку загальну характеристику
проекту, контактні дані виконавця, посилання на репо співвиконавців(за необхідністю).


Шаблон публікування курсової роботи підготовлено з використанням [VuePress](https://vuepress.vuejs.org/), та теми 
[vuepress-theme-hope/vuepress-theme-hope](https://github.com/vuepress-theme-hope/vuepress-theme-hope).

Щоб опублікувати проект у Github Pages:

 - робите коміт у вітці main(master) та пушите його на віддалений репозиторій github, автоматично спрацьовує  workflow та починається процес деплою
  
 - на сторінці github вашого репозиторію переходите в ```Settings```-->```Pages```, в ```Sourse``` обираєте варіант ```Deploy from branch```, в ```Branch``` обираєте ```gh-pages``` та папку ```/root``` та натискаєте ```Save```.


Для відлагодження документації в локальному режимі запускаємо

```bash
    npm run docs:dev
```

Доступ до локально опублікованої версії [http://localhost:8080](http://localhost:8080)



## Додаткова інформація

- [Теми проєктів](./guidelines/themes.md)
- [Методичні вказівки](./guidelines/guidelines.md)
- [Документація vuepress-theme-hope](https://theme-hope.vuejs.press/)
- [Документація Markdown](https://theme-hope.vuejs.press/cookbook/markdown/)

***Happy learning! Happy coding!*** 
