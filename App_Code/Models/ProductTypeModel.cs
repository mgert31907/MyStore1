using System;

/// <summary>
/// Summary description for ProductTypeTypeModel
/// </summary>
public class ProductTypeTypeModel
{
    public string InsertProductType(ProductType productType)
    {
        try
        {
            GarageDBEntities6 db = new GarageDBEntities6();
            db.ProductTypes.Add(productType);
            db.SaveChanges();
            return productType.Name + "was succesfully inserted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string UpdateProductType(int id, ProductType productType)
    {
        try
        {
            GarageDBEntities6 db = new GarageDBEntities6();
            ProductType p = db.ProductTypes.Find(id);

            p.Name = productType.Name;

            db.SaveChanges();
            return productType.Name + "was succesfully updated";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string DeleteProductType(int id)
    {
        try
        {
            GarageDBEntities6 db = new GarageDBEntities6();
            ProductType productType = db.ProductTypes.Find(id);

            db.ProductTypes.Attach(productType);
            db.ProductTypes.Remove(productType);
            db.SaveChanges();
            return productType.Name + "was succesfully deleted";

        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
}