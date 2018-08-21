using UnityEngine;

public class Card
{
    public CardView mCardView;
    public string StringValue { get; set; }
    public Denomination mDenomination;
    public Suit CardSuit { get; set; }
    public string Owner { get; set; }

    public bool isOnScreen = false;
 
    public class Suit
    {
        public string StringSuit;
        //TODO: implement same as Color
        public Values Value { get; set; }
        public GameObject Object { get; set; }

        public enum Values
        {
            Heart, Spades, Diamond, Club
        }
        public Suit(Values suit)
        {
            Value = suit;
            StringSuit = suit.ToString();
        }
    }

    //Номинал
    public class Denomination
    {
        public Values Value { get; set; }
        public GameObject Object { get; set; }
        //public static const string Zero = "0";
        public enum Values
        {
            Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, ACE
        }

        public Denomination(Values denomination)
        {
            Value = denomination;
        }

        public override bool Equals(object o)
        {
            return true;
        }
        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            switch (Value)
            {
                case Values.Zero:
                    return "0";
                case Values.One:
                    return "1";
                case Values.Two:
                    return "2";
                case Values.Three:
                    return "3";
                case Values.Four:
                    return "4";
                case Values.Five:
                    return "5";
                case Values.Six:
                    return "6";
                case Values.Seven:
                    return "7";
                case Values.Eight:
                    return "8";
                case Values.Nine:
                    return "9";
                case Values.Ten:
                    return "10";
                case Values.Jack:
                    return "J";
                case Values.Queen:
                    return "Q";
                case Values.King:
                    return "K";
                case Values.ACE:
                    return "A";
                default:
                    return null;
            }
        }

        public int ToInt()
        {
            switch (Value)
            {
                case Values.Zero:
                    return 0;
                case Values.One:
                    return 1;
                case Values.Two:
                    return 2;
                case Values.Three:
                    return 3;
                case Values.Four:
                    return 4;
                case Values.Five:
                    return 5;
                case Values.Six:
                    return 6;
                case Values.Seven:
                    return 7;
                case Values.Eight:
                    return 8;
                case Values.Nine:
                    return 9;
                case Values.Ten:
                    return 10;
                case Values.Jack:
                    return 11;
                case Values.Queen:
                    return 12;
                case Values.King:
                    return 13;
                case Values.ACE:
                    return 14;
            }
            throw new System.Exception("Denomination doesn't exist!");
        }

        public static Denomination FromInt(int denomination)
        {
            switch (denomination)
            {
                case 0:
                    return new Denomination(Denomination.Values.Zero);
                case 1:
                    return new Denomination(Denomination.Values.One);
                case 2:
                    return new Denomination(Denomination.Values.Two);
                case 3:
                    return new Denomination(Denomination.Values.Three);
                case 4:
                    return new Denomination(Denomination.Values.Four);
                case 5:
                    return new Denomination(Denomination.Values.Five);
                case 6:
                    return new Denomination(Denomination.Values.Six);
                case 7:
                    return new Denomination(Denomination.Values.Seven);
                case 8:
                    return new Denomination(Denomination.Values.Eight);
                case 9:
                    return new Denomination(Denomination.Values.Nine);
                case 10:
                    return new Denomination(Denomination.Values.Ten);
                case 11:
                    return new Denomination(Denomination.Values.Jack);
                case 12:
                    return new Denomination(Denomination.Values.Queen);
                case 13:
                    return new Denomination(Denomination.Values.King);
                case 14:
                    return new Denomination(Denomination.Values.ACE);
            }
            return null;
        }

        public Denomination(int denomination)
        {
            FromInt(denomination);
        }

        public static bool operator < (Denomination denomination, Denomination denomination2)
        {
            return denomination.ToInt() < denomination2.ToInt();
        }

        public static bool operator > (Denomination denomination, Denomination denomination2)
        {
            return denomination.ToInt() > denomination2.ToInt();
        }

        public static bool operator ==(Denomination denomination, Denomination denomination2)
        {
            return denomination.ToInt() == denomination2.ToInt();
        }

        public static bool operator !=(Denomination denomination, Denomination denomination2)
        {
            return denomination.ToInt() != denomination2.ToInt();
        }
    }

    //implement constructors from CardColor / Suit

    public Card(Denomination value, Suit suit)
    {
        mDenomination = value;
        CardSuit = suit;
    }

    public Card()
    {
        
    }

    public Card(Denomination value)
    {
        mDenomination = value;
    }

    public Card(Card card)
    {
        mDenomination = card.mDenomination;
        CardSuit = card.CardSuit;
    }

    public virtual void CreateCard(Vector3 position, Quaternion rotation, GameObject parent = null)
    {
        mCardView = new CardView();
        mCardView.Render("FPC/PlayingCards_" + mDenomination + CardSuit.StringSuit, position, rotation,
            new Vector3(10, 10, 4), parent);
    }
    public void ReplaceCard(Vector3 position, Quaternion rotation)
    {
        mCardView.Replace(position, rotation);
    }
    public void DestroyCard()
    {
        
    }
    public class CardView
    {
        public GameObject cardObject;

        public void Render(string value, Vector3 position, Quaternion rotation, Vector3 localScale, GameObject parent = null)
        {
            cardObject = (GameObject)Object.Instantiate(Resources.Load(value));
            cardObject.tag = "Card";
            cardObject.transform.position = position;
            cardObject.transform.localScale = localScale;
            cardObject.transform.rotation = rotation;
            if (parent != null)
            {
                cardObject.transform.SetParent(parent.transform);
            }
        }

        public void Replace(Vector3 position, Quaternion rotation)
        {
            cardObject.transform.position = position;
            cardObject.transform.rotation = rotation;
        }
        public void Drag(Vector3 mousePos)
        {
            cardObject.transform.position = mousePos;
        }
        public void SelfDestroy()
        {
            Object.Destroy(cardObject);
        }

    }

    }