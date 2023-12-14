namespace Sea_Battle
{
    abstract class SeaBattleAI
    {
        private protected SeaBattleField playerField; // копия поля игрока
        public int destroyedShips = 0; //количество уничтоженных кораблей
        public int shotsCount = 0; //количество выстрелов
        public Point[] shots = new Point[100]; //массив выстрелов по точкам
        public bool[] hit = new bool[100]; //массив попаданий/непопаданий
        public int move = 0; //номер хода
        private protected bool isFourDeckShipDestroyed = false; //флаг уничтожения четырехпалубника
        private protected int ShipLength = 0; //длина текущего корабля
        private protected bool finishOff = true; //флаг добивания кораблей

        public SeaBattleAI()
        {

        }
        //метод добивания кораблей
        private protected void FinishOffTheShip(int x, int y)
        {
            //цикл сканирования вниз
            for (int i = 1; i < 4; i++)
            {
                if (x + i > 9) break; //выход за пределы поля - выход из цикла
                byte b = TakeAShot(x + i, y); //производит выстрел и запоминает знач
                if (b == 0) break; //промах - выход из цикла
                if (b == 1) return; //уничтожен - выход из метода
            }
            //аналогичный цикл сканирования влево
            for (int i = 1; i < 4; i++)
            {
                if (y - i < 0) break;
                byte b = TakeAShot(x, y - i);
                if (b == 0) break;
                if (b == 1) return;
            }
            //аналогичный цикл сканирования вправо
            for (int i = 1; i < 4; i++)
            {
                if (y + i > 9) break;
                byte b = TakeAShot(x, y + i);
                if (b == 0) break;
                if (b == 1) return;
            }
            //аналогичный цикл сканирования вверх
            for (int i = 1; i < 4; i++)
            {
                if (x - i < 0) break;
                byte b = TakeAShot(x - i, y);
                if (b == 0) break;
                if (b == 1) return;
            }
        }
        //метод выстрела по полю
        private protected byte TakeAShot(int m, int n)
        {
            byte returning = 2; //возвращаемое значение 

            //действия, исходя из выстрела по полю
            switch (playerField.ShootIntoFieldCell(m, n))
            {
                case 0: //выстрел в проверенное место, ничего не меняется
                    returning = 0;
                    break;
                case 2: //ранение корабля
                    shots[shotsCount] = new Point(m, n); //запомнили выстрел
                    hit[shotsCount++] = true; //запомнили, что выстрел удачный
                    ShipLength++; //увеличение счетчика длины корабля
                    if (finishOff) FinishOffTheShip(m, n); //добивание корабля
                                                           //в случае того, если
                                                           //поставлен флаг
                    break;
                case 3: //уничтожение корабля
                    shots[shotsCount] = new Point(m, n); //запомнили выстрел
                    hit[shotsCount++] = true; //запомнили, что выстрел удачный
                    destroyedShips++; //увеличение счетчика уничтоженных кораблей
                    ShipLength++; //увеличение счетчика длины корабля
                    if (ShipLength == 4) isFourDeckShipDestroyed = true;
                    //если длина равна 4, то запоминаем, что четырехпалубный уничтожен
                    ShipLength = 0; //обнуляем длину корабля
                    returning = 1;
                    break;
                case 5: //выстрел мимо
                    shots[shotsCount] = new Point(m, n); //запомнили выстрел
                    hit[shotsCount++] = false; //запомнили, что выстрел неудачный
                    returning = 0;
                    break;
            }
            return returning; //выход из метода
        }
    }
}