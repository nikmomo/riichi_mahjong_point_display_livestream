﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace riichi_display
{
    // The pointHandler class is used to handle point calculations.
    public class pointHandler
    {
        // Declare the fields for the class.
        private int kyutaku;
        private int combo;
        private int finalAddup; // Final adding up point to the player

        // Default constructor initializing kyutaku and combo to zero.
        public pointHandler()
        {
            kyutaku = 0;
            combo = 0;
            finalAddup = 0;
        }

        // Public properties for kyutaku and combo.
        private int Kyutaku { get { 
                var result = kyutaku;
                kyutaku = 0;
                return result; }}
        private int Combo { get { return combo; } }
        public int FinalAddup { get {
                var result = finalAddup;
                finalAddup = 0;
                return result; 
            }}

        // Calculate the total point when ron.
        // point - The base point.
        public int Ron(int point)
        {
            finalAddup = point + kyutaku * 1000 + combo * 300;
            return point + combo * 300;
        }

        // Reset combo and kyutaku to zero.
        public void Reset() { combo = 0; kyutaku = 0; finalAddup = 0; }

        // Calculate the total point when oyatsumo, return the point that requires to pay by everyone
        // point - The base point.
        public int Oyatsumo(int point)
        {
            var result = point / 3;
            if (result % 100 != 0)
                result += 100;
            finalAddup = (ToThousand(result) * 3 ) + combo * 300 +
                kyutaku * 1000;
            return ToThousand(result) + combo * 100;
        }

        // Calculate the total points for both oya and ko when kotsumo.
        // point - The base point.
        public (int oya, int ko) Kotsumo(int point)
        {
            var oyaResult = point / 2;
            var koResult = oyaResult / 2;
            if (oyaResult % 100 != 0)
                oyaResult += 100;
            if (koResult % 100 != 0)
                koResult += 100;
            finalAddup = ToThousand(oyaResult) + (combo * 300) + 
                ToThousand(koResult) * 2 + kyutaku * 1000;
            return (ToThousand(oyaResult) + combo * 100, ToThousand(koResult) + combo * 100);
        }

        // Increase combo by one.
        public void AddCombo() { combo++; }

        // Increase kyutaku by one.
        public void AddKyutaku() { kyutaku++; }

        public int getKyutaku() { return kyutaku; }

        public int getCombo() { return combo; }

        // Rounds a value down to the nearest thousand.
        // value - The value to round down.
        private int ToThousand(int value)
        {
            var result = value / 100;
            return result * 100;
        }

    }
}
