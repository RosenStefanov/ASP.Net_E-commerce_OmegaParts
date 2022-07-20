using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OmegaParts.Data;
using OmegaParts.Models;
namespace OmegaParts.Pages;

public class PrivacyModel : PageModel
{
    public  List<Clutch_Model> ClutchModels = new List<Clutch_Model>();
    private readonly ApplicationDbContext _context;
    [BindProperty]
    public List<Clutch_Model> AddedClutch { get; set; }
    [BindProperty]
    public Clutch_Model ClutchModelss { get; set; }
    public PrivacyModel(ApplicationDbContext context)
    {
        _context = context;
    }
    //Adds the selected clutch to the cart
    public IActionResult OnPost()
    {
        string ser;
        if (HttpContext.Session.GetString("ListClutch") != null)
        {
            ser = HttpContext.Session.GetString("ListClutch");
            AddedClutch = JsonSerializer.Deserialize<List<Clutch_Model>>(ser);
        }
        AddedClutch.Add(ClutchModelss);
        ser = JsonSerializer.Serialize(AddedClutch);
        HttpContext.Session.SetString("ListClutch", ser);
        return RedirectToPage();
    }
    //Gets the list of clutches from the data base
    public void OnGet()
    {
        ClutchModels = _context.Clutches.ToList();
    }
}