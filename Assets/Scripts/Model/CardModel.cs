using UnityEngine;

public class Card {

    public string Value { get; set; }
    public string Owner { get; set; }

    public class Suit
    {
        //TODO: implement same as Color
        public enum Values
        {
            Hearts, Spades, Diamonds, Clubs
        }

    }

    public class Color
    {
        public Values Value { get; set; }
        public GameObject Object { get; set; }

        public enum Values {
            Red, Yellow, Green, Blue, Any
        }

        public static Color fromInt()
        {
            return new Color();
        }

        public Color()
        {
            //TODO: implement different constructors form Value and from int
        }

        public int toInt() {
            //TODO: implement
            return 0;
        }
    }

    public Card()
    {
        //implement constructors from CardColor / Suit
    }

    public void Render(Vector3 position, Quaternion rotation) {
        //implement
    }

}
