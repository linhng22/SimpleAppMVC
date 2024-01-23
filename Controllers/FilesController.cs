using Microsoft.AspNetCore.Mvc;


namespace SimpleAppMVC.Controllers;

public class FilesController(ILogger<FilesController> logger, IWebHostEnvironment env) : Controller
{
    private readonly ILogger<FilesController> _logger = logger;
    private readonly IWebHostEnvironment _evn = env;

    public IActionResult Index()
    {
        var path = Path.Combine(_evn.ContentRootPath, "TextFiles");

        var files = Directory.GetFiles(path);
        for (int i = 0; i < files.Length; i++)
        {
            files[i] = Path.GetFileName(files[i]);
        }
        ViewBag.files = files;
        return View();
    }


    public IActionResult Contents(string id)
    {
        var filePath = Path.Combine(_evn.ContentRootPath, "TextFiles", id);

        if (System.IO.File.Exists(filePath))
        {
            var fileContent = System.IO.File.ReadAllText(filePath);
            ViewBag.fileContent = fileContent;
            return View();
        }
        else
        {
            return NotFound();
        }
    }

}

