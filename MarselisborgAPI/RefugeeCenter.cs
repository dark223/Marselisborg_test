namespace MarselisborgAPI
{
    public class RefugeeCenter
    {
        public RefugeeCenter(int flytningeCenterID, string by)
        {
            FlytningeCenterID = flytningeCenterID;
            By = by;
        }

      public int FlytningeCenterID { get; set; }
      public string By { get; set; }

    }
}
