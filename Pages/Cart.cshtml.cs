using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OmegaParts.Data;
using OmegaParts.Models;
namespace OmegaParts.Pages;

public class Cart : PageModel
{
    [BindProperty]
    public  List<Clutch_Model> AddedClutches { get; set; }
    public int Index { get; set; }
    [BindProperty]
    public  List<Head_Gasket_Model> AddedGaskets { get; set; }
    private string serclutches;
    [BindProperty]
    public Order_Model order { get; set; }
    private readonly ApplicationDbContext _context;

    public Cart(ApplicationDbContext context)
    {
        _context = context;
    }
    //Saves the order to the database if the validation is correct
    public IActionResult OnPost()
    {
        AddedClutches = new List<Clutch_Model>();
         AddedGaskets = new List<Head_Gasket_Model>();
         
            if (HttpContext.Session.GetString("ListClutch") != null)
            {
                serclutches = HttpContext.Session.GetString("ListClutch");
                AddedClutches = JsonSerializer.Deserialize<List<Clutch_Model>>(serclutches);
            }

            if (HttpContext.Session.GetString("ListGasket") != null)
            {
                serclutches = HttpContext.Session.GetString("ListGasket");
                AddedGaskets = JsonSerializer.Deserialize<List<Head_Gasket_Model>>(serclutches);
            }
            
            foreach (var item in AddedClutches)
            {
                order.Order = order.Order + "Clutch, Brand: " +
                              @item.Brand + ", Make and model: " + @item.Make_and_model + ", Diameter: " + @item.Diam +
                              ", Price: " + @item.Price + "!\n";
            }

            foreach (var item in AddedGaskets)
            {
                order.Order = order.Order + "Head Gasket, Brand: " +
                              @item.Brand + ", Make and model: " + @item.Make_and_model + ", Engine Code: " +
                              @item.Engine_Code + ", Price: " + @item.Price + "!\n";
            }
            
            if (!ModelState.IsValid | order.Order == null)
            {
                return RedirectToPage();
            }

            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToPage("Order_Sent");
        }

    //Gets the items that are added to the cart
    public void OnGet()
    {
        if (HttpContext.Session.GetString("ListClutch") != null)
        {
            serclutches = HttpContext.Session.GetString("ListClutch");
            AddedClutches = JsonSerializer.Deserialize<List<Clutch_Model>>(serclutches);
        }

        if (HttpContext.Session.GetString("ListGasket") != null)
        {
            serclutches = HttpContext.Session.GetString("ListGasket");
            AddedGaskets = JsonSerializer.Deserialize<List<Head_Gasket_Model>>(serclutches);
        }
    }

    //Removes the selected clutch from the cart
    public IActionResult OnPostRemoveClutch()
    {
        
        serclutches = HttpContext.Session.GetString("ListClutch");
        AddedClutches = JsonSerializer.Deserialize<List<Clutch_Model>>(serclutches);
        AddedClutches.RemoveAt(Index);
        serclutches = JsonSerializer.Serialize(AddedClutches);
        HttpContext.Session.SetString("ListClutch", serclutches);
        return RedirectToPage();
    }
    
    //Removes the selected head gasket from the cart
    public IActionResult OnPostRemoveGasket()
    {
        serclutches = HttpContext.Session.GetString("ListGasket");
        AddedGaskets = JsonSerializer.Deserialize<List<Head_Gasket_Model>>(serclutches);
        AddedGaskets.RemoveAt(Index);
        serclutches = JsonSerializer.Serialize(AddedGaskets);
        HttpContext.Session.SetString("ListGasket", serclutches);
        return RedirectToPage();
    }
}