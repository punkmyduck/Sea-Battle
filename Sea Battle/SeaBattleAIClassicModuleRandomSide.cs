using System;

namespace Sea_Battle
{
    class SeaBattleAIClassicModuleRandomSide : SeaBattleAI
    {
        private int shift = new Random(1).Next(-2, 2);
        private int side = new Random(1).Next() % 2 == 0 ? 9 : 0;
        public SeaBattleAIClassicModuleRandomSide(SeaBattleField field)
        {
            this.playerField = new SeaBattleField(field);
            ScoutOutTheField();
        }
        private void ScoutOutTheField()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((Math.Abs(side - i) + Math.Abs(side - j)) % 4 == (3 + shift) % 4)
                    {
                        TakeAShot(Math.Abs(side - i), Math.Abs(side - j));
                    }
                    if (destroyedShips == 10) return;
                    if (isFourDeckShipDestroyed) break;
                }
                if (isFourDeckShipDestroyed) break;
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((Math.Abs(side - i) + Math.Abs(side - j)) % 2 == Math.Abs(1 + shift) % 2)
                    {
                        TakeAShot(Math.Abs(side - i), Math.Abs(side - j));
                    }
                    if (destroyedShips == 10) return;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((Math.Abs(side - i) + Math.Abs(side - j)) % 2 == Math.Abs(0 + shift) % 2)
                    {
                        TakeAShot(Math.Abs(side - i), Math.Abs(side - j));
                    }
                    if (destroyedShips == 10) return;
                }
            }
        }
    }
}

