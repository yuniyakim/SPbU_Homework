module Phonebook

let printMenu () =
    printf "Menu:"
    printf "1 – exit"
    printf "2 – add contact"
    printf "3 – find number by name"
    printf "4 – find name by number"
    printf "5 – show all contacts"
    printf "6 – save data to file"
    printf "7 – read data from file"


//Написать программу - телефонный справочник. Она должна уметь хранить имена и номера телефонов, в интерактивном режиме осуществлять следующие операции:
//1. выйти
//2. добавить запись (имя и телефон)
//3. найти телефон по имени
//4. найти имя по телефону
//5. вывести всё текущее содержимое базы
//6. сохранить текущие данные в файл
//7. считать данные из файла