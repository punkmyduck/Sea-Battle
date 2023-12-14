using System;

namespace Sea_Battle
{
    class SeaBattleAILongestLineFinding : SeaBattleAI
    {
        public SeaBattleAILongestLineFinding(SeaBattleField field)
        {
            this.playerField = new SeaBattleField(field);
            ScoutOutTheField();
        }
        private void ScoutOutTheField()
        {
            Random rnd = new Random(1);
            while (destroyedShips != 10)
            {
                int maxClearLength = 0;
                bool secondIsMore = false;
                Point maxPoint = new Point(-1, -1);
                for (int i = 0; i < 10; i++)
                {
                    int curLenght = 0;
                    for (int j = 0; j < 10; j++)
                    {
                        if (playerField.GetFieldCellValue(i, j) == 0 || playerField.GetFieldCellValue(i, j) == 1 || playerField.GetFieldCellValue(i, j) == 4)
                        {
                            curLenght++;
                            if (curLenght > maxClearLength)
                            {
                                maxClearLength = curLenght;
                                maxPoint = new Point(i, j);
                            }
                        }
                        else
                        {
                            curLenght = 0;
                        }
                    }
                }

                for (int j = 0; j < 10; j++)
                {
                    int curLenght = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        if (playerField.GetFieldCellValue(i, j) == 0 || playerField.GetFieldCellValue(i, j) == 1 || playerField.GetFieldCellValue(i, j) == 4)
                        {
                            curLenght++;
                            if (curLenght > maxClearLength)
                            {
                                maxClearLength = curLenght;
                                maxPoint = new Point(i, j);
                                secondIsMore = true;
                            }
                        }
                        else
                        {
                            curLenght = 0;
                        }
                    }
                }

                if (!secondIsMore)
                {
                    TakeAShot(maxPoint.X, rnd.Next(maxPoint.Y - maxClearLength + 1, maxPoint.Y + 1));
                }
                else
                {
                    TakeAShot(rnd.Next(maxPoint.X - maxClearLength + 1, maxPoint.X + 1), maxPoint.Y);
                }
            }
        }
    }
}