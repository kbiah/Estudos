
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using lagrimas.Data;
    using lagrimas.Data.DAL.Cadastros;
    using lagrimas.Modelo.Cadastros;

namespace lagrimas.Controllers
    {
        public class InstituicaoController : Controller
        {
            private readonly IESContext _context;
            private readonly InstituicaoDAL instituicaoDAL;

            public InstituicaoController(IESContext context)
            {
                _context = context;
                instituicaoDAL = new InstituicaoDAL(context);
            }

            // GET: Instituicao
            public async Task<IActionResult> Index()
            {
                return View(await instituicaoDAL.ObterInstituicoesClassificadasPorNome().ToListAsync());
            }

            // GET: Instituicao/Details/5
            public async Task<IActionResult> Details(long? id)
            {
                return await ObterVisaoInstituicaoPorId(id);
            }

            // GET: Instituicao/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Instituicao/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("InstituicaoID,Nome,Endereco")] Instituicao instituicao)
            {
                if (ModelState.IsValid)
                {
                    await instituicaoDAL.GravarInstituicao(instituicao);
                    return RedirectToAction(nameof(Index));
                }
                return View(instituicao);
            }

            // GET: Instituicao/Edit/5
            public async Task<IActionResult> Edit(long? id)
            {
                return await ObterVisaoInstituicaoPorId(id);
            }

            // POST: Instituicao/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(long? id, [Bind("InstituicaoID,Nome,Endereco")] Instituicao instituicao)
            {
                if (id != instituicao.InstituicaoID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        await instituicaoDAL.GravarInstituicao(instituicao);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!await InstituicaoExists(instituicao.InstituicaoID))
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
                return View(instituicao);
            }

            // GET: Instituicao/Delete/5
            public async Task<IActionResult> Delete(long? id)
            {
                return await ObterVisaoInstituicaoPorId(id);
            }

            // POST: Instituicao/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(long? id)
            {
                var instituicao = await instituicaoDAL.EliminarInstituicaoPorId((long)id);
                TempData["Message"] = "Instituição " + instituicao.Nome.ToUpper() + " foi removida";
                return RedirectToAction(nameof(Index));
            }

            private async Task<bool> InstituicaoExists(long? id)
            {
                return await instituicaoDAL.ObterInstituicaoPorId((long)id) != null;
            }

            private async Task<IActionResult> ObterVisaoInstituicaoPorId(long? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var instituicao = await instituicaoDAL.ObterInstituicaoPorId((long)id);
                if (instituicao == null)
                {
                    return NotFound();
                }

                return View(instituicao);
            }
        }
    }


    //// GET: Instituicao/Details/5
    //public async Task<IActionResult> Details(long? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var instituicao = await _context.Instituicoes.Include(d => d.Departamentos).SingleOrDefaultAsync(m => m.InstituicaoID == id);
    //        //var instituicao = await _context.Instituicoes.Where(i => i.InstituicaoID == id).Include(d => d.Departamentos).ToListAsync();
    //        if (instituicao == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(instituicao);
    //    }

    //    // GET: Instituicao/Create
    //    public IActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: Instituicao/Create
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("Nome,Endereco")] Instituicao instituicao)
    //    {
    //        try
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                _context.Add(instituicao);
    //                await _context.SaveChangesAsync();
    //                return RedirectToAction(nameof(Index));
    //            }
    //        }
    //        catch (DbUpdateException)
    //        {
    //            ModelState.AddModelError("", "Não foi possível inserir os dados.");
    //        }
    //        return View(instituicao);
    //    }

    //    // GET: Instituicao/Edit/5
    //    public async Task<IActionResult> Edit(long? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(m => m.InstituicaoID == id);
    //        if (instituicao == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(instituicao);
    //    }

    //    // POST: Instituicao/Edit/5
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(long? id, [Bind("InstituicaoID,Nome,Endereco")] Instituicao instituicao)
    //    {
    //        if (id != instituicao.InstituicaoID)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(instituicao);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!InstituicaoExists(instituicao.InstituicaoID))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(instituicao);
    //    }

    //    // GET: Instituicao/Delete/5
    //    public async Task<IActionResult> Delete(long? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(m => m.InstituicaoID == id);
    //        if (instituicao == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(instituicao);
    //    }

    //    // POST: Instituicao/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(long? id)
    //    {
    //        var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(m => m.InstituicaoID == id);
    //        _context.Instituicoes.Remove(instituicao);
    //        TempData["Message"] = "Instituição " + instituicao.Nome.ToUpper() + " foi removida";
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool InstituicaoExists(long? id)
    //    {
    //        return _context.Instituicoes.Any(e => e.InstituicaoID == id);
    //    }
