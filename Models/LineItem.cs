namespace Models
{
    public class LineItem
    {
    public LineItem(){}
    public LineItem(string name, decimal cost, int qty, string location)
    {
        this.Name = name;
        this.Cost = cost;
        this.QTY = qty;
        this.Location = location;
    }

        public string Name {get; set; }
        public decimal Cost {get; set;}
        public int QTY {get; set;}
        public string Location {get; set;}
    }

    
}