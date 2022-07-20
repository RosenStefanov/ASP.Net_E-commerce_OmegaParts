using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OmegaParts.Data;
using OmegaParts.Models;
namespace OmegaParts.Pages;

public class Head_Gasket : PageModel
{
    public  List<Head_Gasket_Model> GasketModels = new List<Head_Gasket_Model>();
    private readonly ApplicationDbContext _context;
    [BindProperty]
    public List<Head_Gasket_Model> AddedGaskets { get; set; }
    [BindProperty]
    public Head_Gasket_Model HeadGasket { get; set; }
    public Head_Gasket(ApplicationDbContext context)
    {
        _context = context;
    }
    
    //Adds the selected head gasket to the cart
    public IActionResult OnPost()
    {
        string ser;
        if (HttpContext.Session.GetString("ListGasket") != null)
        {
            ser = HttpContext.Session.GetString("ListGasket");
            AddedGaskets = JsonSerializer.Deserialize<List<Head_Gasket_Model>>(ser);
        }
        AddedGaskets.Add(HeadGasket);
        ser = JsonSerializer.Serialize(AddedGaskets);
        HttpContext.Session.SetString("ListGasket", ser);
        return RedirectToPage();
    }
    
    //Gets the list of head gaskets from the data base
    public void OnGet()
    {
        GasketModels = _context.Head_Gasket.ToList();
    }
}