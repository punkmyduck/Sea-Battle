using System;
using System.Threading;

namespace Sea_Battle
{
    class SeaBattleAIRandom : SeaBattleAI
    {
        private Random rnd = new Random(1);

        public SeaBattleAIRandom(SeaBattleField field)
        {
            //this.finishOff = false; //запоминаем, что класс не будет добивать корабли
            this.playerField = new SeaBattleField(field); //создаем копию поля игрока
            ScoutOutTheField(); //вызываем метод обстрела
            Thread.Sleep(20); //вызываем "зависание" кода, чтобы при 
            //создании еще одного объекта класса Random, этот объект был уникальным
        }

        //метод разведки поля
        private void ScoutOutTheField()
        {
            while (destroyedShips != 10) //цикл, пока не будут уничтожены все корабли
            {
                TakeAShot(rnd.Next(0, 10), rnd.Next(0, 10)); //выстрел по случайным координатам
            }
        }
    }
}