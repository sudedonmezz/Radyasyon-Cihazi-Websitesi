namespace Entities.Models
{
    public class Cart
    {

        public List<CartLine> Lines {get;set;}
        public Cart()
        {
            Lines=new List<CartLine>();
        }

        public virtual void AddItem(Product product,int quantity)
        {
            CartLine? line = Lines.Where(l => l.Product.ProductId == product.ProductId).FirstOrDefault();


            if(line is null)
            {
                Lines.Add(new CartLine()
                {
                    Product=product,
                    Quantity=quantity
                });
            }
            else
            {
                line.Quantity+=quantity;
            }
        }

        public virtual void RemoveLine(Product product)=>
        Lines.RemoveAll(l=>l.Product.ProductId.Equals(product.ProductId));

        public decimal ComputerTotalValue()=> Lines.Sum(e=>e.Product.ProductPrice*e.Quantity);

        public virtual void Clear()=> Lines.Clear();
        
    }
}