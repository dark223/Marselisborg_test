namespace MarselisborgAPI
{
    public class Refugee
    {
        public Refugee(int? flygtningID, string navn, int alder, int flygtningeCenterID,int? familieid)
        {
            FlygtningID = flygtningID;
            Navn = navn;
            Alder = alder;
            FlygtningeCenterID = flygtningeCenterID;
            FamilieID = familieid;
        }

       public int? FlygtningID { get; set; }
       public string Navn { get; set; }
       public int Alder { get; set; }
       public int FlygtningeCenterID { get;set;}
       public int? FamilieID { get;set;}

    }

public class RefugeeDTO
{
    public RefugeeDTO(string navn, int alder, int flygtningeCenterID, int? familieID)
        {

            Navn = navn;
            Alder = alder;
            FlygtningeCenterID = flygtningeCenterID;
            FamilieID = familieID;
        }

    public string Navn { get; set; }
    public int Alder { get; set; }
    public int FlygtningeCenterID { get; set; }
    public int? FamilieID { get; set; }

    }

}

