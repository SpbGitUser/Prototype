
using System;

namespace ConsoleApp.StaticTests
{
    public class Enums
    {
        internal enum T4State
        {
            Alive,
            Dead,
            Schrodinger
        }

        internal enum En
        {
            First = 15,
            Second,
            Third = 54
        }

        [Flags]
        public enum CalcStepTarget
        {
            CalcFactPrice = 1,
            CalcCustomsCost = 2,
            CalcStatisticsCost = 4,

            CalcAll = CalcFactPrice | CalcCustomsCost | CalcStatisticsCost,
            CalcAll1 = CalcFactPrice & CalcCustomsCost & CalcStatisticsCost,
            CalcDefault = CalcAll
        }

    }
}
