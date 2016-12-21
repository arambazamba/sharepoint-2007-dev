using System.Data;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

public class PropertyCollectionBinder
{
    protected DataTable PropertyCollection = new DataTable();
    public PropertyCollectionBinder()
    {
        PropertyCollection.Columns.Add("PropertyName", typeof(string));
        PropertyCollection.Columns.Add("PropertyValue", typeof(string));
    }
    public void AddProperty(string PropertyName, string PropertyValue)
    {
        DataRow newRow = PropertyCollection.Rows.Add();
        newRow["PropertyName"] = PropertyName;
        newRow["PropertyValue"] = PropertyValue;
    }
    public void BindGrid(SPGridView grid)
    {
        SPBoundField fldPropertyName = new SPBoundField();
        fldPropertyName.HeaderText = "Property Name";
        fldPropertyName.DataField = "PropertyName";
        grid.Columns.Add(fldPropertyName);
        SPBoundField fldPropertyValue = new SPBoundField();
        fldPropertyValue.HeaderText = "Value";
        fldPropertyValue.DataField = "PropertyValue";
        grid.Columns.Add(fldPropertyValue);
        grid.DataSource = PropertyCollection.DefaultView;
        grid.DataBind();
    }
}