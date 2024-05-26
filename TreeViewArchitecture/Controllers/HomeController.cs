using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json;
using System.Xml.Linq;
using TreeViewArchitecture.Data;
using TreeViewArchitecture.Models;

namespace TreeViewArchitecture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataContext _context { get; }
  
        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Nodes
        public async Task<IActionResult> Index()
        {
            var nodes = await _context.Nodes.Include(n => n.ParentNode).ToListAsync();
            ViewBag.TreeNodes = JsonConvert.SerializeObject(nodes);
            return View(nodes);
        }
        //public async Task<IActionResult> Index()
        //{
        //    var jsonOptions = new JsonSerializerOptions
        //    {
        //        ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
        //        MaxDepth = 64 // Optionally increase the maximum depth
        //    };
        //    var nodes = await _context.Nodes.Include(n => n.ParentNode).ToListAsync();
        //    var json = System.Text.Json.JsonSerializer.Serialize(nodes, jsonOptions);
        //    return new JsonResult(nodes, jsonOptions);
        //    return View(json);
        //}
        public async Task<IActionResult> TreeStructure()
        {
            var nodes = await _context.Nodes.FromSqlRaw("EXEC GetActiveNodes").ToListAsync();
            return View(nodes);
        }


        // GET: Nodes/Create
        public IActionResult Create()
        {
            ViewData["ParentNodeId"] = new SelectList(_context.Nodes, "NodeId", "NodeName");
            return View();
        }

        // POST: Nodes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NodeId,NodeName,ParentNodeId,IsActive,StartDate")] NodeModel node)
        {
            if (ModelState.IsValid)
            {
                _context.Add(node);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentNodeId"] = new SelectList(_context.Nodes, "NodeId", "NodeName", node.ParentNodeId);
            return View(node);
        }

        // GET: Nodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var node = await _context.Nodes.FindAsync(id);
            if (node == null)
            {
                return NotFound();
            }
            ViewData["ParentNodeId"] = new SelectList(_context.Nodes, "NodeId", "NodeName", node.ParentNodeId);
            return View(node);
        }

        // POST: Nodes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NodeId,NodeName,ParentNodeId,IsActive,StartDate")] NodeModel node)
        {
            if (id != node.NodeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(node);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NodeExists(node.NodeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentNodeId"] = new SelectList(_context.Nodes, "NodeId", "NodeName", node.ParentNodeId);
            return View(node);
        }

        // GET: Nodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var node = await _context.Nodes
                .Include(n => n.ParentNode)
                .FirstOrDefaultAsync(m => m.NodeId == id);
            if (node == null)
            {
                return NotFound();
            }

            return View(node);
        }

        // POST: Nodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var node = await _context.Nodes.FindAsync(id);
            _context.Nodes.Remove(node);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NodeExists(int id)
        {
            return _context.Nodes.Any(e => e.NodeId == id);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}