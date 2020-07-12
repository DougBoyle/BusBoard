namespace BusBoard.Web.Models
{
  public class PostcodeSelection
  {
    public string Postcode { get; set; }
    public int MaxStops { get; set; }
    public int Radius { get; set; }

    public override string ToString() {
      return "Selection: "+ Postcode;
    }
  }
  
}