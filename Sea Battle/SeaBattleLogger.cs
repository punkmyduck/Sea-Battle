using System;
using System.IO;

namespace Sea_Battle
{
    public struct Info
    {
        public int PlayerMovesCount;
        public int ComputerMovesCount;
        public bool isPlayerFirstMove;
        public DateTime Start;
        public DateTime End;
        public bool IsPlayerVictory;
        public bool DidPlayerGiveUp;
        public int PlayerHitsCount;
        public int ComputerHitsCount;
        public string AlgorithmDifficulty;
    }
    class SeaLogger
    {
        private bool isFirstMoveSet = false;
        private Info info = new Info();
        private string path = @"..\..\..\gamelog.txt";
        private string log = "";

        public SeaLogger(string str)
        {
            info.Start = DateTime.Now;
            info.AlgorithmDifficulty = str;
            log += $"Начало игры: {info.Start}\n";
            switch (str)
            {
                case "easy":
                    log += "Сложность - легко\n";
                    break;
                case "normal":
                    log += "Сложность - средне\n";
                    break;
                case "hard":
                    log += "Сложность - сложно\n";
                    break;
            }
        }

        public void AddLine(bool isPlayerMove, int x, int y, byte hit)
        {
            if (hit != 2 && hit != 3 && hit != 5) return;
            if (!isFirstMoveSet)
            {
                info.isPlayerFirstMove = isPlayerMove;
                isFirstMoveSet = true;
            }
            if (isPlayerMove)
            {
                log += "Ход игрока: ";
                info.PlayerMovesCount++;
            }
            else
            {
                log += "Ход компьютера: ";
                info.ComputerMovesCount++;
            }
            log += $"{(char)('A' + x)}{y + 1} - ";
            switch (hit)
            {
                case 2:
                    log += "Ранил\n";
                    if (isPlayerMove) info.PlayerHitsCount++;
                    else info.ComputerHitsCount++;
                    break;
                case 3:
                    log += "Убил\n";
                    if (isPlayerMove) info.PlayerHitsCount++;
                    else info.ComputerHitsCount++;
                    break;
                case 5:
                    log += "Мимо\n";
                    break;
            }
        }

        public void FinishLog(bool isPlayerVictory, bool didPlayerGiveUp)
        {
            info.End = DateTime.Now;
            info.IsPlayerVictory = isPlayerVictory;
            log += $"Конец игры: {info.End}\n" +
                $"Победил {(info.IsPlayerVictory ? "игрок" : "компьютер")}\n" +
                $"Первый выстрел совершил {(info.isPlayerFirstMove ? "игрок" : "компьютер")}\n" +
                $"Игрок сделал {info.PlayerMovesCount} выстрелов. Попаданий - {info.PlayerHitsCount}\n" +
                $"Компьютер сделал {info.ComputerMovesCount} выстрелов. Попаданий -  {info.ComputerHitsCount}\n";
            info.DidPlayerGiveUp = didPlayerGiveUp;
            if (didPlayerGiveUp)
            {
                log += "Игрок сдался\n\n\n";
            }
            else
            {
                log += "\n\n";
            }
            File.AppendAllText(path, log);
        }

        public string GetLog()
        {
            return log;
        }
        public Info GetInfo()
        {
            return info;
        }
    }
}
